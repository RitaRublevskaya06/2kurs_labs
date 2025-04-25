#include<iostream>
#include<chrono>

using namespace std;

void hanoi(int n, int i, int k, int nr)
{
    if (n == 1) {
        cout << "ѕереместить диск " << n << " с " << i << " на " << k << " стержень." << endl;
        return;
    }
    else {
        int j = (i + k) % nr;
        if (j == 0) {
            j = nr;
        }
        hanoi(n - 1, i, j, nr);
        cout << "ѕереместить диск " << n << " с " << i << " на " << k << " стержень." << endl;
        hanoi(n - 1, j, k, nr);
    }
}

int main() {

    setlocale(LC_ALL, "RUS");

    int n;
    cout << "¬ведите количество дисков: ";
    cin >> n;

    int i;
    cout << "¬ведите начальный стержень: ";
    cin >> i;

    int k;
    cout << "¬ведите конечный стержень: ";
    cin >> k;

    int nr;
    cout << "¬ведите количество стержней: ";
    cin >> nr;

    auto start = chrono::high_resolution_clock::now();

    hanoi(n, i, k, nr);

    int nv = (1 << n) - 1;

    auto end = chrono::high_resolution_clock::now();
    chrono::duration<double> elapsed = end - start;
    cout << "¬рем€ выполнени€: " << elapsed.count() << " секунд." << endl;
    cout << "„исло ходов: " << nv << endl;

    return 0;
}
