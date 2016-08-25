#joint_bayesian人脸识别
C++实现joint bayesian人脸识别算法
		C++/CL封装

##平台及依赖项
		VS2013      
		eigen3      

##介绍

###jointbayesian_Csharp

VS2013C#工程，调用C++/CLI封装的dll文件进行训练，测试

###joingbayesian_cli

对C++算法的C++/CLI封装



##使用

实现了JointbBayesian_CLI类，提供了4个接口函数供C#调用<br>

* 训练：bool train_jointbayesian(array<double,2>^ train_dataset,array<int>^train_label,int M,int N)<br>
　　　　输入：train_dataset:训练集，二维M*N数组<br>
　　　　      train_label:训练集标签，一维M*1数组<br>
　　　　输出：计算出模型矩阵A,G,并存储为dat文件，训练成功返回true<br>

* 批量测试：void test_jointbayesian(array<double, 2>^ test_dataset, array<int>^test_label, int M, int N)<br>
		输入：test_dataset：测试集，二维M*N数组<br>
				label:测试集标签，一维M*1数组<br>
		输出：计算出测试集的ratio,存储在类中，由performance_jointbayesian（）使用<br>
* 性能计算：double performance_jointbayesian(double threshold_start, double threshold_end, double step）<br>
        输入：threshold_start：阈值起始值 <br>
              threshold_end:阈值结束值<br>
              step:步进长度<br>
		输出：当前测试集下的最佳阈值并返回此值
* 单对图片测试：bool testpair_jointbayesian((array<double, 2>^ test_pair,double threshold,int M,int N)
				输入：test_pair：一对测试图片<br>
					  threshold:由 performance_jointbayesian()计算出的最佳阈值
				输出：判定两张图片属于同一人，返回true；否则，返回false
训练阶段，调用train_jointbayesian函数<br>
批量测试阶段，调用test_jointbayesian和performance_jointbayesian函数<br>


