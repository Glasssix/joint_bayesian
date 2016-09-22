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
         /*   double[,] dataset = new double[102524,160];
            int[] label = new int[102524];
            int i = 0, j = 0;

            //double[,] set = new double[30, 40];
           // int[] label1 = new int[15] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 };
            StreamReader sw1 = new StreamReader("casia_croped_1500_222500_ip1.dat");
            StreamReader sw2 = new StreamReader("casia_croped_label_1500.dat");
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
                        if (j >= 160) j = 0;
                    }
                }
                //Console.Write("\n");
                i++;
                strLine1 = sw1.ReadLine();
                strLine2 = sw2.ReadLine();
            }
            int[] everyclasscount = new int[20000];//记录每种类别的图片数
	        int n_class = 1, cnt = 1;//n_class：种类数 cnt：每种种类的数量
	        for (int z = 0; z <102523; z++){//计算图片种类数（即有多少个不同的人）以及每种图片的个数。
		        if (label[z] != label[z + 1]){
			        everyclasscount[n_class - 1] = cnt;
			        n_class++;
			        cnt = 1;
			        continue;
		        }
		        cnt++;
	        }
	        everyclasscount[n_class - 1] = cnt;
           */

            int i = 0;
            int j = 0;
            //读取lfw测试集
            double[,] testset = new double[11512,160];
            int[] testlabel = new int[5756];
            StreamReader sw3 = new StreamReader("lfw_222500_ip1.dat");
            StreamReader sw4 = new StreamReader("lfw_pair_label.dat");
            string strLine3 = sw3.ReadLine();
            while (!string.IsNullOrEmpty(strLine3))// && !string.IsNullOrEmpty(strLine2))
            {
                //label[i] = int.Parse(strLine2);
                string[] array = strLine3.Split(' ');
                foreach (string str in array)
                {
                    if (str != "")
                    {
                        testset[i, j++] = double.Parse(str);
                        // Console.Write("{0} ",dataset[i, j - 1]);
                        if (j >= 160) j = 0;
                    }
                }
                //Console.Write("\n");
                i++;
                strLine3 = sw3.ReadLine();
               // strLine2 = sw2.ReadLine();
            }
            i = 0;
            j = 0;
            string strLine4 = sw4.ReadLine();
            while (!string.IsNullOrEmpty(strLine4))// && !string.IsNullOrEmpty(strLine2))
            {
                testlabel[i] = int.Parse(strLine4);
                //Console.Write("{0} ", testlabel[i]);
                i++;
                strLine4 = sw4.ReadLine();
            }
            //训练集2
       /*     i = 0;
            j = 0;
            double[,] trainset4038 = new double[9525, 40];
            int[] trainlabel4038 = new int[9525];
            StreamReader sw3 = new StreamReader("trainset4038_thridfeature.dat");
            StreamReader sw4 = new StreamReader("trainlabel4038.dat");
            // StreamReader sw1 = new StreamReader("testdate.txt");
            string strLine3 = sw3.ReadLine();
            string strLine4 = sw4.ReadLine();
            while (!string.IsNullOrEmpty(strLine3))// && !string.IsNullOrEmpty(strLine2))
            {
                trainlabel4038[i] = int.Parse(strLine4);
                string[] array = strLine3.Split(' ');
                foreach (string str in array)
                {
                    if (str != "")
                    {
                        trainset4038[i, j++] = double.Parse(str);
                        // Console.Write("{0} ",dataset[i, j - 1]);
                        if (j >= 40) j = 0;
                    }
                }
                //Console.Write("\n");
                i++;
                strLine3 = sw3.ReadLine();
                strLine4 = sw4.ReadLine();
            }*/
  
            //joint bayes
            Console.WriteLine("training start");
            string Apath=@"C:\Users\machao\Desktop\A.dat";
            string Gpath=@"C:\Users\machao\Desktop\G.dat";
            //string Apath = @"D:\A.dat";
            //string Gpath = @"D:\G.dat";
            JointbBayesian_CLI jointbayesian = new JointbBayesian_CLI(true, Apath, Gpath);
            // Console.WriteLine("1");
            //double thr=jointbayesian.train_jointbayesian(dataset,label, 102524, 160,testset,testlabel,11512,160,-30,20,0.01);//训练
            double thr = jointbayesian.test_jointbayesian(testset, testlabel, 11512, 160, -30, 20, 0.01);
            Console.WriteLine("threshold:{0}",thr);
                     //jointbayesian.test_jointbayesian(testset,testlabel,6400, 40);//测试
                    // double threshold=jointbayesian.performance_jointbayesian(-30, 20, 0.01);//计算阈值

                     //生成单对测试图片
                 /*     double[,] testpair1 = new double[2, 40];
                      double[,] testpair2 = new double[2, 40];
                      for (int a2 = 0; a2 < 40; a2++)
                      {
                          testpair1[0, a2] = dataset[6, a2];
                          testpair1[1, a2] = dataset[7, a2];
                      }
                      for (int a3 = 0; a3 < 40; a3++)
                      {
                          testpair2[0, a3] = dataset[everyclasscount[0], a3];
                          testpair2[1, a3] = dataset[everyclasscount[0]+1, a3];
                      }
                          bool flag = jointbayesian.testPair_jointbayesian(testpair1, -2.7, 2, 40);//测试单对图片
                          Console.Write("Belong to the same person?:");
                          if (flag) Console.WriteLine("yes");
                          else Console.WriteLine("no");
                          Console.WriteLine(" ");
                          bool flag1 = jointbayesian.testPair_jointbayesian(testpair2, -2.7, 2, 40);//测试单对图片
                          Console.Write("Belong to the same person?:");
                          if (flag1) Console.WriteLine("yes");
                          else Console.WriteLine("no");*/
                     Console.ReadLine();
        }
    }
}
