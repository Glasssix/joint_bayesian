using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using jointbayesian_cli;
namespace jointbayesian_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //生成训练集
            double[,] dataset = new double[391908,40];
            int[] label = new int[391908];
            int i = 0, j = 0;

            double[,] set = new double[30, 40];
            int[] label1 = new int[15] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 };
            StreamReader sw1 = new StreamReader("dataset.dat");
            StreamReader sw2 = new StreamReader("label.dat");
           // StreamReader sw1 = new StreamReader("testdate.txt");
            string strLine1 = sw1.ReadLine();
            string strLine2 = sw2.ReadLine();
            while (!string.IsNullOrEmpty(strLine1))// && !string.IsNullOrEmpty(strLine2))
            {
                label[i]=int.Parse(strLine2);
                string[] array = strLine1.Split(' ');
                foreach (string str in array)
                {
                    if (str != "")
                    {
                        dataset[i,j++] = double.Parse(str);
                       // Console.Write("{0} ",dataset[i, j - 1]);
                        if (j >= 40) j = 0;
                    }
                }
                //Console.Write("\n");
                i++;
                strLine1 = sw1.ReadLine();
                strLine2 = sw2.ReadLine();
            }
            int[] everyclasscount = new int[20000];//记录每种类别的图片数
	        int n_class = 1, cnt = 1;//n_class：种类数 cnt：每种种类的数量
	        for (int z = 0; z <391907; z++){//计算图片种类数（即有多少个不同的人）以及每种图片的个数。
		        if (label[z] != label[z + 1]){
			        everyclasscount[n_class - 1] = cnt;
			        n_class++;
			        cnt = 1;
			        continue;
		        }
		        cnt++;
	        }
	        everyclasscount[n_class - 1] = cnt;
                //生成测试集
                 double[,] testset = new double[42296, 40];
                 int[] testlabel = new int[21148];
                 int pcnt = 0, count = 0;
                 for (int d = 0; d < 10574; d++) testlabel[d] = 1;
                 for (int k =10574; k <21148; k++) testlabel[k] = 0;
                 for (int l = 0; l < 10575; l++)
                 {//正例
                     if (l != 3749)
                     {
                         for (int x = 0; x < 40; x++)
                         {
                             testset[pcnt, x] = dataset[count, x];
                             testset[pcnt+1, x] = dataset[count + 1, x];
                         }
                         pcnt += 2;
                     }
                     count += everyclasscount[l];
                 }
                 int count1 = 0, count2 = 0, count3 = 0,count4=5288;
                 for (int xw1 = 0; xw1 < 5288; xw1++) count2 += everyclasscount[xw1];
                 count3 = count2;
                 for (int m = 0; m < 5287; m++)
                 {//反例
                     for (int y = 0; y < 40; y++)
                     {
                         testset[pcnt, y] = dataset[count1, y];
                         testset[pcnt+1, y] = dataset[count2, y];
                     }
                     pcnt += 2;
                     count1 += everyclasscount[m];
                     count2 += everyclasscount[count4++];
                 }
                count1=0;
                count2=everyclasscount[0];
                 for (int y1 = 0,y2=0,y3=1; y1 < 2643; y1++)
                 {
                     for (int y = 0; y < 40; y++)
                     {
                         testset[pcnt, y] = dataset[count1, y];
                         testset[pcnt+1, y] = dataset[count2, y];
                     }
                     pcnt += 2;
                     count1 += everyclasscount[y2++];
                     count1 += everyclasscount[y2++];
                     count2 += everyclasscount[y3++];
                     count2 += everyclasscount[y3++];
                 }
                 count1 = count3;
                 count2 = count3 + everyclasscount[5288];
                 for (int y5 = 0,y6=5288,y7=5289; y5 < 2643; y5++)
                 {
                     for (int y = 0; y < 40; y++)
                     {
                         testset[pcnt, y] = dataset[count1, y];
                         testset[pcnt+1, y] = dataset[count2, y];
                     }
                     pcnt += 2;
                     count1 += everyclasscount[y6++];
                     count1 += everyclasscount[y6++];
                     count2 += everyclasscount[y7++];
                     count2 += everyclasscount[y7++];
                 }
                 for (int y = 0; y < 40; y++)
                 {
                     testset[pcnt, y] = dataset[391786, y];
                     testset[pcnt+1, y] = dataset[391702, y];
                 }
               /*  StreamWriter sw3 = new StreamWriter("testset.dat");
                 StreamWriter sw4 = new StreamWriter("testlabel.dat");
                 for (int b1 = 0; b1 < 21148; b1++)
                 {
                     sw4.WriteLine(testlabel[b1]);
                 }
                 for (int b2 = 0; b2 < 42296; b2++)
                 {
                     for (int y = 0; y < 40; y++) sw3.Write("{0} ",testset[b2, y]);
                     sw3.Write("\n");
                 }
                 sw3.Close();
                 sw4.Close();*/
                 //joint bayes
                 Console.WriteLine("training start");
            string Apath=@"C:\Users\machao\Desktop\A.dat";
            string Gpath=@"C:\Users\machao\Desktop\G.dat";
            JointbBayesian_CLI jointbayesian = new JointbBayesian_CLI(false, Apath, Gpath);
                 Console.WriteLine("1");
                 double thr=jointbayesian.train_jointbayesian(dataset,label, 391908, 40,testset,testlabel,42296,40,-30,20,0.01);//训练
                 Console.WriteLine("threshold{0}",thr);
                     //jointbayesian.test_jointbayesian(testset,testlabel,6400, 40);//测试
                     //double threshold=jointbayesian.performance_jointbayesian(-30, 20, 0.01);//计算阈值

                     //生成单对测试图片
                     /* double[,] testpair1 = new double[2, 40];
                      double[,] testpair2 = new double[2, 40];
                      for (int a2 = 0; a2 < 40; a2++)
                      {
                          testpair1[0, a2] = dataset[0, a2];
                          testpair1[1, a2] = dataset[1, a2];
                      }
                      for (int a3 = 0; a3 < 40; a3++)
                      {
                          testpair2[0, a3] = dataset[everyclasscount[0], a3];
                          testpair2[1, a3] = dataset[everyclasscount[0]+1, a3];
                      }
                          bool flag = jointbayesian.testPair_jointbayesian(testpair1, -4.75, 2, 40);//测试单对图片
                          Console.Write("Belong to the same person?:");
                          if (flag) Console.WriteLine("yes");
                          else Console.WriteLine("no");
                          Console.WriteLine(" ");
                          bool flag1 = jointbayesian.testPair_jointbayesian(testpair2, -4.75, 2, 40);//测试单对图片
                          Console.Write("Belong to the same person?:");
                          if (flag1) Console.WriteLine("yes");
                          else Console.WriteLine("no");*/
                     Console.ReadLine();
        }
    }
}
