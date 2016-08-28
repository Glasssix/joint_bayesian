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
* 构造函数：JointbBayesian_CLI(bool falg,String^ A_path,String^ G_path)<br>
		输入：flag：是否读取A，G矩阵<br>
			A_path：A矩阵路径<br>
			G_path：G矩阵路径<br>
* 训练：double train_jointbayesian(array<double,2>^ train_dataset,array<int>^train_label,int trainM,int trainN，
                                 array<double, 2>^ test_dataset, array<int>^test_label, int testM, int testN，
				double threshold_start, double threshold_end, double step)<br>
		输入：训练集，测试集，起始阈值及步长
		输出：计算出模型矩阵A,G,并存储为dat文件，返回测试集最佳阈值true<br>
* 单对图片测试：bool testpair_jointbayesian((array<double, 2>^ test_pair,double threshold,int M,int N)<br>
		输入：test_pair：一对测试图片<br>
			threshold:由 performance_jointbayesian()计算出的最佳阈值<br>
		输出：判定两张图片属于同一人，返回true；否则，返回false<br>
训练阶段，调用train_jointbayesian函数<br>
测试阶段，调用testpair_jointbayesian函数<br>

##训练集
训练集和标签的dat文件：[训练集](http://pan.baidu.com/s/1dFiGArR)
