// 这是主 DLL 文件。


#include "jointbayesian_cli.h"


namespace jointbayesian_cli{
	JointbBayesian_CLI::JointbBayesian_CLI(bool flag, String^ A_path, String^ G_path){
		char* strA = (char*)(void*)Marshal::StringToHGlobalAnsi(A_path);
		char* strG = (char*)(void*)Marshal::StringToHGlobalAnsi(G_path);
		jointbayesian = new JointBayesian(flag,strA,strG);
	}
	JointbBayesian_CLI::~JointbBayesian_CLI(){
		delete jointbayesian;
	}
	double JointbBayesian_CLI::train_jointbayesian(array<double, 2>^ train_dataset, array<int>^train_label, int trainM, int trainN, \
												   array<double, 2>^ test_dataset, array<int>^test_label, int testM, int testN, \
												   double threshold_start, double threshold_end, double step){
		clock_t start_time0 = clock();
		int* label = new int[trainM];
		double* dataset = new double[trainM*trainN];
		//C++/CLIarray数组->C++数组
		for (int i = 0; i < trainM; i++){
			label[i] = train_label[i];
			for (int j = 0; j < trainN; j++)dataset[i*trainN + j] = train_dataset[i, j];
		}
		int flag = jointbayesian->jointbayesian_train(dataset, label, trainM, trainN);
		clock_t end_time0 = clock();
		cout << "Training time is: " << static_cast<double>(end_time0 - start_time0) / CLOCKS_PER_SEC * 1000 << "ms" << endl;//输出运行时间

		clock_t start_time1 = clock();
		int* tlabel = new int[testM / 2];
		double* tdataset = new double[testM*testN];
		//C++/CLIarray数组->C++数组
		for (int i = 0; i < testM; i++){
			if (i<testM / 2)tlabel[i] = test_label[i];
			for (int j = 0; j < testN; j++)tdataset[i*testN + j] = test_dataset[i, j];
		}
		jointbayesian->jointbayesian_test(tdataset, tlabel, testM, testN);
		clock_t end_time1 = clock();
		cout << "Testing time is: " << static_cast<double>(end_time1 - start_time1) / CLOCKS_PER_SEC * 1000 << "ms" << endl;//输出运行时间

		clock_t start_time2 = clock();
		double thr = jointbayesian->jointbayesian_performance(threshold_start, threshold_end, step);
		clock_t end_time2 = clock();
		cout << "Performance time is: " << static_cast<double>(end_time2 - start_time2) / CLOCKS_PER_SEC * 1000 << "ms" << endl;//输出运行时间
		return thr;
	}

	double JointbBayesian_CLI::test_jointbayesian(array<double, 2>^ test_dataset, array<int>^test_label, int testM, int testN, \
		double threshold_start, double threshold_end, double step){

		clock_t start_time1 = clock();
		int* tlabel = new int[testM / 2];
		double* tdataset = new double[testM*testN];
		//C++/CLIarray数组->C++数组
		for (int i = 0; i < testM; i++){
			if (i<testM / 2)tlabel[i] = test_label[i];
			for (int j = 0; j < testN; j++)tdataset[i*testN + j] = test_dataset[i, j];
		}
		jointbayesian->jointbayesian_test(tdataset, tlabel, testM, testN);
		clock_t end_time1 = clock();
		cout << "Testing time is: " << static_cast<double>(end_time1 - start_time1) / CLOCKS_PER_SEC * 1000 << "ms" << endl;//输出运行时间

		clock_t start_time2 = clock();
		double thr = jointbayesian->jointbayesian_performance(threshold_start, threshold_end, step);
		clock_t end_time2 = clock();
		cout << "Performance time is: " << static_cast<double>(end_time2 - start_time2) / CLOCKS_PER_SEC * 1000 << "ms" << endl;//输出运行时间
		return thr;
	}

	bool JointbBayesian_CLI::testPair_jointbayesian(array<double, 2>^test_pair, double threshold, int M, int N){
		clock_t start_time = clock();
		double* testpair = new double[2*N];
		for (int i = 0; i < 2; i++){
			for (int j = 0; j < N; j++){
				testpair[i*N + j] = test_pair[i, j];
			}
		}
		bool flag = jointbayesian->jointbayesian_testPair(testpair, threshold, M, N);
		clock_t end_time = clock();
		cout << "Pair_testing time is: " << static_cast<double>(end_time - start_time) / CLOCKS_PER_SEC * 1000 << "ms" << endl;//输出运行时间
		return flag;
	}
}




