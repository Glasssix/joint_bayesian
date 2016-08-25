// jointbayesian_cli.h
//这是对jointbayesian C++实现的C++/CLI封装
#pragma once

using namespace System;
//using namespace System::xml;

#include "joint_bayesian.h"

namespace jointbayesian_cli {

	public ref class JointbBayesian_CLI
	{
	public:
		JointbBayesian_CLI();
		~JointbBayesian_CLI();

		bool train_jointbayesian(array<double,2>^ train_dataset,array<int>^train_label,int M,int N);//C#接口，训练模型
		void test_jointbayesian(array<double, 2>^ test_dataset, array<int>^test_label, int M, int N);//测试模型
		double performance_jointbayesian(double threshold_start, double threshold_end, double step);//模型精度
		bool testPair_jointbayesian(array<double, 2>^ test_pair, double threshold, int M, int N);//测试单对图片


	private:
		JointBayesian* jointbayesian;
	};
}
