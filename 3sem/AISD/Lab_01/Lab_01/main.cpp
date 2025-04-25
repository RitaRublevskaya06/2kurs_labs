#include <iostream>
#include <chrono>

using namespace std;

void hanoi(int n, int i, int k) {
    if (n == 1) {
        cout << "����������� ���� " << n << " � " << i << " ������� �� " << k << " ��������." << endl;
        return;
    }
    
    else {
        hanoi(n - 1, i, 6 - i - k);
        cout << "����������� ���� " << n << " � " << i << " �� " << k << " ��������." << endl;
        hanoi(n - 1, 6 - i - k, k);
    }
}

int main() {
    setlocale(LC_ALL, "RUS");
    int n;
    int i, k;

    while (true) {
        cout << "������� ���������� ������: ";
        cin >> n;
        if (n <= 0) {
        cout << "������: ���������� ������ ������ ���� ������ � �� ����� 0. ���������� �����." << endl;
        }
        else {
            break;
        }
    }

    while (true) {
        cout << "������� �������� ��������: ";
        cin >> i;

        if (i < 1 || i > 3) {
            cout << "������: ������� ������ ���� � ��������� �� 1 �� 3. ���������� �����." << endl;
        }
        else {
            break; 
        }
    }

    while (true) {
        cout << "������� �������� ��������: ";
        cin >> k;

        if (k < 1 || k > 3) {
            cout << "������: ������� ������ ���� � ��������� �� 1 �� 3. ���������� �����." << endl;
        }
        else {
            break; 
        }
    }

    auto start = chrono::high_resolution_clock::now();
    hanoi(n, i, k);
    int nm = (1 << n) - 1;
    auto end = chrono::high_resolution_clock::now();
    chrono::duration<double> elapsed = end - start;
    cout << "����� ����������: " << elapsed.count() << " ������." << endl;
    cout << "����� �����: " << nm << endl;

    return 0;
}
