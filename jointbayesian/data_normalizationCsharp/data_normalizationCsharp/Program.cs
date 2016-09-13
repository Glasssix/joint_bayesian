using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using System.Math;

namespace data_normalizationCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            int j = 0;
            double[,] trainset4038 = new double[391908, 40];
            double[] maxArray = new double[391908];
            double maxnum=0;
            //int s = System.Math.Abs(j);
            //StreamReader sw3 = new StreamReader(@"C:\Users\machao\Desktop\lfw_train\trainset4038_feature.dat");
            //StreamWriter sw4 = new StreamWriter(@"C:\Users\machao\Desktop\lfw_train\trainset4038_normalization.dat");
            StreamReader sw3 = new StreamReader(@"C:\Users\machao\Desktop\jointbayesian\jointbayesian_Csharp\bin\Release\dataset.dat");
            StreamWriter sw4 = new StreamWriter(@"C:\Users\machao\Desktop\jointbayesian\jointbayesian_Csharp\bin\Release\dataset_normalization.dat");
            string strLine3 = sw3.ReadLine();
            while (!string.IsNullOrEmpty(strLine3))// && !string.IsNullOrEmpty(strLine2))
            {
                // Console.Write("3");
                string[] array = strLine3.Split(' ');
                foreach (string str in array)
                {
                    if (str != "")
                    {
                        trainset4038[i, j++] = double.Parse(str);
                        maxnum = maxnum>System.Math.Abs(trainset4038[i, j-1])?maxnum:System.Math.Abs(trainset4038[i, j-1]);
                        if (j >= 40) j = 0;
                    }
                }
                maxArray[i] = maxnum;
                maxnum = 0;
                i++;
                strLine3 = sw3.ReadLine();
                //strLine4 = sw4.ReadLine();
            }
            for (int k = 0; k < 391908; k++)
            {
                for (int l = 0; l < 40; l++)
                {
                    trainset4038[k, l] = trainset4038[k, l] / maxArray[k];
                    sw4.Write("{0} ",trainset4038[k, l]);
                }
                sw4.Write("\n");
            }
            sw3.Close();
            sw4.Close();
            Console.WriteLine("end");
            Console.ReadLine();
        }
    }
}
