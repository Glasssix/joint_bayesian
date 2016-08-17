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
            double[,]testset=new double[400,40];
            int[] label = new int[391908];
            int[]testlabel=new int[200];
            int i = 0, j = 0;
            StreamReader sw1 = new StreamReader("dataset.dat");
            StreamReader sw2 = new StreamReader("label.dat");
            string strLine1 = sw1.ReadLine();
            string strLine2 = sw2.ReadLine();
            while (!string.IsNullOrEmpty(strLine1) && !string.IsNullOrEmpty(strLine2))
            {
                label[i]=int.Parse(strLine2);
                string[] array = strLine1.Split(' ');
                foreach (string str in array)
                {
                    if (str != "")
                    {
                        dataset[i,j++] = double.Parse(str);
                        if (j >= 40) j = 0;
                    }
                }
                i++;
                strLine1 = sw1.ReadLine();
                strLine2 = sw2.ReadLine();
            }
           Console.WriteLine("i:{0},label[i]:{1},dataset[i,39]:{2}", i-1, label[i-1], dataset[i-1, 39]);
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
                Console.WriteLine("class:{0}", n_class);
                //生成测试集
                int pcnt = 0, count = 0;
                for (int d = 0; d < 100; d++) testlabel[d] = 1;
                for (int k = 100; k < 200; k++) testlabel[k] = 0;
                for (int l = 0; l < 200; l+=2)
                {//正例
                    for(int x=0;x<40;x++){
                        testset[l,x] = dataset[count,x];
                        testset[l+1, x] = dataset[count + 1,x];
                    }
                    count += everyclasscount[pcnt++];
                }
                for (int m = 200; m < 400; m++)
                {//反例
                    for(int y=0;y<40;y++) testset[m,y] = dataset[count,y];
                    count += everyclasscount[pcnt++];
                }
            //训练
            JointbBayesian_CLI jointbayesian = new JointbBayesian_CLI();
            //jointbayesian.train_jointbayesian(dataset,label, 391908, 40);
            Console.WriteLine("test");
            jointbayesian.test_jointbayesian(testset, testlabel,400, 40);
            jointbayesian.performance_jointbayesian(-30, 20, 0.01);
            Console.ReadLine();
        }
        static void read_dat(string filepath)
        {
            //string filepath = "dataset.dat";
            if (File.Exists(filepath))
            {
                StreamReader sw = new StreamReader(filepath);
                 string strLine = sw.ReadLine();
                    while (!string.IsNullOrEmpty(strLine))
                    {
                        string[] array = strLine.Split(' ');
                            foreach (string str in array)
                            {
                                if (str != "")
                                {
                                    double a = double.Parse(str);
                                    Console.WriteLine(a);
                                }
                            }
                        strLine = sw.ReadLine();
                    }
            }
        }
    }
}
