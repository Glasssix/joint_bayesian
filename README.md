#Joint_Bayesian Face Verification/联合贝叶斯人脸验证
C++实现joint bayesian人脸验证算法

		

##Platform and Dependency/平台及依赖项
- Visual Studio 2013(Windows)
- [eigen3](http://eigen.tuxfamily.org/index.php?title=Main_Page)

##Introduction/介绍
###joingbayesian_cli

joint bayesian算法的C++实现以及C++/CLI封装

###jointbayesian_Csharp

C#测试示例工程，调用C++/CLI封装的dll文件进行训练，测试

###data_normalizationCsharp
原始数据归一化

###thrid_featureCsharp
归一化数据转换为三值特征


##Usage/使用

实现了JointbBayesian_CLI类，提供了2个接口函数供C#调用<br>
* 构造函数：`JointbBayesian_CLI(bool flag,String^ A_path,String^ G_path)`<br>
		输入：`flag`：是否读取A，G矩阵<br>
			`A_path`：A矩阵路径<br>
			`G_path`：G矩阵路径<br>
* 训练：

```
double train_jointbayesian(array<double,2>^ train_dataset, 
array<int>^ train_label, 
int trainM,
int trainN，
array<double, 2>^ test_dataset, 
array<int>^test_label, 
int testM, 
int testN，
double threshold_start, 
double threshold_end, 
double step)
```

<br>
		输入：训练集，测试集，起始阈值及步长<br>
		输出：计算出模型矩阵A,G,并存储为dat文件，返回测试集最佳阈值true<br>
* 批量测试：
```
double test_jointbayesian(array<double, 2>^ test_dataset, 
array<int>^test_label, 
int testM, 
int testN，
double threshold_start, 
double threshold_end, 
double step))
```

* 单对图片测试：`bool testpair_jointbayesian((array<double, 2>^ test_pair, double threshold, int M, int N)`<br>
		输入：`test_pair`：一对测试图片<br>
			`threshold`:由 `performance_jointbayesian()`计算出的最佳阈值<br>
		输出：判定两张图片属于同一人，返回true；否则，返回false<br>
训练阶段，调用`train_jointbayesian`函数<br>
测试阶段，调用`testpair_jointbayesian`函数<br>


##更新日志
###2016.9.22：
1.改进了Su，Sw协方差矩阵计算方法，加快了训练速度。
2.提供了独立的批量测试函数test_jointbayesian;

##Training Dataset/训练集
训练集和标签的dat文件：[训练集](http://pan.baidu.com/s/1dFiGArR)

##Test Results/测试结果
正确率：88.6%<br>
单对图片检测时间：<1ms<br>

##Contributor/贡献者
- Chao Ma
