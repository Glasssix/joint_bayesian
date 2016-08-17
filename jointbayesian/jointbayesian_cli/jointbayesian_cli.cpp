// 这是主 DLL 文件。


#include "jointbayesian_cli.h"


namespace jointbayesian_cli{
	JointbBayesian_CLI::JointbBayesian_CLI(){
		jointbayesian = new JointBayesian();
	}
	JointbBayesian_CLI::~JointbBayesian_CLI(){
		delete jointbayesian;
	}
	void JointbBayesian_CLI::train_jointbayesian(array<double, 2>^ train_dataset, array<int>^train_label, int M, int N){
		int* label = new int[M];
		double* dataset= new double[M*N];
		//C++/CLIarray数组->C++数组
		for (int i = 0; i < M; i++){
		label[i] = train_label[i];
		for (int j = 0; j < N; j++)dataset[i*N+j] = train_dataset[i, j];
		}
		jointbayesian->jointbayesian_train(dataset,label,M,N);
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
	void JointbBayesian_CLI::performance_jointbayesian(double threshold_start, double threshold_end, double step){
		jointbayesian->jointbayesian_performance(threshold_start, threshold_end, step);
	}
}




