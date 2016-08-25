// 这是主 DLL 文件。


#include "jointbayesian_cli.h"


namespace jointbayesian_cli{
	JointbBayesian_CLI::JointbBayesian_CLI(){
		jointbayesian = new JointBayesian();
	}
	JointbBayesian_CLI::~JointbBayesian_CLI(){
		delete jointbayesian;
	}
	bool JointbBayesian_CLI::train_jointbayesian(array<double, 2>^ train_dataset, array<int>^train_label, int M, int N){
		int* label = new int[M];
		double* dataset= new double[M*N];
		//C++/CLIarray数组->C++数组
		for (int i = 0; i < M; i++){
		label[i] = train_label[i];
		for (int j = 0; j < N; j++)dataset[i*N+j] = train_dataset[i, j];
		}
		int flag=jointbayesian->jointbayesian_train(dataset,label,M,N);
		return flag;
	}
	void JointbBayesian_CLI::test_jointbayesian(array<double, 2>^ test_dataset, array<int>^test_label, int M, int N){
		int* label = new int[M];
		double* dataset = new double[M*N];
		//C++/CLIarray数组->C++数组
		for (int i = 0; i < M; i++){
			if(i<200)label[i] = test_label[i];
			for (int j = 0; j < N; j++)dataset[i*N + j] = test_dataset[i, j];
		}
		jointbayesian->jointbayesian_test(dataset, label, M, N);
	}
	double JointbBayesian_CLI::performance_jointbayesian(double threshold_start, double threshold_end, double step){
		double thr=jointbayesian->jointbayesian_performance(threshold_start, threshold_end, step);
		return thr;
	}
	bool JointbBayesian_CLI::testPair_jointbayesian(array<double, 2>^test_pair, double threshold, int M, int N){
		double* testpair = new double[2*N];
		for (int i = 0; i < 2; i++){
			for (int j = 0; j < N; j++){
				testpair[i*N + j] = test_pair[i, j];
			}
		}
		bool flag = jointbayesian->jointbayesian_testPair(testpair, threshold, M, N);
		return flag;
	}
}




