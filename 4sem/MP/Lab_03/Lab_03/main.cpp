#include "stdafx.h"
#include <iostream>
#include <iomanip> 
#include "Salesman.h"
#define N 5

using namespace std;


int main()
{
	setlocale(LC_ALL, "rus");
	int d[N][N] = { //0     1     2     3   4        
					{ INF,  20,   31,  INF, 10 },    //  0
					{ 10,   INF,  25,  58,  74 },    //  1
					{ 12,   30,   INF, 86,  59 },    //  2 
					{ 27,   48,   40,  INF, 30 },    //  3
					{ 83,   76,   52,  23,  INF } }; //  4  
	int r[N];   /// ��������� 
	int s = salesman(
		N,          /// [in]  ���-�� ������� 
		(int*)d,    /// [in]  ������ [n*n] ���������� 
		r           /// [out] ������ [n] ������� 0 x x x x  

	);
	cout << "\t\t--- ������ ������������ --- ";
	cout << "\n\n����������  �������: " << N;
	cout << "\n������� ���������� : ";

	for (int i = 0; i < N; i++)
	{
		cout << "\n";
		for (int j = 0; j < N; j++)

			if (d[i][j] != INF) cout << setw(3) << d[i][j] << " ";

			else cout << setw(3) << "INF" << " ";
	}

	cout << "\n����������� �������: ";
	for (int i = 0; i < N; i++)
		cout << r[i] + 1 << "-->";

	cout << 1;
	cout << "\n����� ��������     : " << s << "\n";
	system("pause");
	return 0;

}