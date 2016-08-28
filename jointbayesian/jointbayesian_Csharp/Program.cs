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
                //Console.WriteLine("class:{0}", n_class);
                //训练集
             /*   double[,] trainset1 = new double[40960, 40];
                int[] trainlabel1 = new int[40960];
                for (int i1 = 0,count1=0,i3=0; i1 <40960; i1++)
                {
                    if (i1 % 4 == 0)
                    {
                        for(int i2=0;i2<40;i2++){
                            trainset1[i1, i2] = dataset[count1, i2];
                            trainset1[i1+1, i2] = dataset[count1+1, i2];
                            trainset1[i1+2, i2] = dataset[count1+2, i2];
                            trainset1[i1 + 3, i2] = dataset[count1 + 3, i2];
                        }
                        trainlabel1[i1] = i3;
                        trainlabel1[i1+1] = i3;
                        trainlabel1[i1+2] = i3;
                        trainlabel1[i1+3] = i3;
                        count1 += everyclasscount[i3++];
                    }
                }*/
                //生成测试集
                double[,] testset = new double[6400, 40];
                int[] testlabel = new int[3200];
                int pcnt = 0, count = 0;
                for (int d = 0; d < 1600; d++) testlabel[d] = 1;
                for (int k =1600; k < 3200; k++) testlabel[k] = 0;
                for (int l = 0; l < 3200; l+=2)
                {//正例
                    for(int x=0;x<40;x++){
                        testset[l,x] = dataset[count,x];
                        testset[l+1, x] = dataset[count + 1,x];
                    }
                    count += everyclasscount[pcnt++];
                }
                for (int m = 3200; m < 6400; m++)
                {//反例
                    for(int y=0;y<40;y++) testset[m,y] = dataset[count,y];
                    count += everyclasscount[pcnt++];
                }

            //joint bayes
            JointbBayesian_CLI jointbayesian = new JointbBayesian_CLI(true,"A.dat","G.dat");
            //jointbayesian.train_jointbayesian(trainset1,trainlabel1, 40960, 40);//训练
            Console.WriteLine("test");
            //jointbayesian.test_jointbayesian(testset,testlabel,6400, 40);//测试
            //double threshold=jointbayesian.performance_jointbayesian(-30, 20, 0.01);//计算阈值

            //生成单对测试图片
            double[,] testpair1 = new double[2, 40];
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
                else Console.WriteLine("no");
            Console.ReadLine();
        }
    }
}
