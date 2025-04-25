#include<iostream>
#include<chrono>

using namespace std;

void hanoi(int n, int i, int k, int nr)
{
    if (n == 1) {
        cout << "����������� ���� " << n << " � " << i << " �� " << k << " ��������." << endl;
        return;
    }
    else {
        int j = (i + k) % nr;
        if (j == 0) {
            j = nr;
        }
        hanoi(n - 1, i, j, nr);
        cout << "����������� ���� " << n << " � " << i << " �� " << k << " ��������." << endl;
        hanoi(n - 1, j, k, nr);
    }
}

int main() {

    setlocale(LC_ALL, "RUS");

    int n;
    cout << "������� ���������� ������: ";
    cin >> n;

    int i;
    cout << "������� ��������� ��������: ";
    cin >> i;

    int k;
    cout << "������� �������� ��������: ";
    cin >> k;

    int nr;
    cout << "������� ���������� ��������: ";
    cin >> nr;

    auto start = chrono::high_resolution_clock::now();

    hanoi(n, i, k, nr);

    int nv = (1 << n) - 1;

    auto end = chrono::high_resolution_clock::now();
    chrono::duration<double> elapsed = end - start;
    cout << "����� ����������: " << elapsed.count() << " ������." << endl;
    cout << "����� �����: " << nv << endl;

    return 0;
}
