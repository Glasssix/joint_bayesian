// jointbayesian_cli.h
//这是对jointbayesian C++实现的C++/CLI封装
#pragma once

using namespace System;
using namespace Runtime::InteropServices;
#include<time.h>
#include "joint_bayesian.h"

namespace jointbayesian_cli {

	public ref class JointbBayesian_CLI
	{
	public:
		JointbBayesian_CLI(bool falg,String^ A_path,String^ G_path);
		~JointbBayesian_CLI();

		double train_jointbayesian(array<double,2>^ train_dataset,array<int>^train_label,int trainM,int trainN,\
									 array<double, 2>^ test_dataset, array<int>^test_label, int testM, int testN,\
									 double threshold_start, double threshold_end, double step);//训练模型，测试并返回最佳阈值
		bool testPair_jointbayesian(array<double, 2>^ test_pair, double threshold, int M, int N);//测试单对图片

	private:
		JointBayesian* jointbayesian;
	};
}
