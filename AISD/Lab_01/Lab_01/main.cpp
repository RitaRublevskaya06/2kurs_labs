#include <iostream>
#include <chrono>

using namespace std;

void hanoi(int n, int i, int k) {
    if (n == 1) {
        cout << "Переместить диск " << n << " с " << i << " стержня на " << k << " стержень." << endl;
        return;
    }
    
    else {
        hanoi(n - 1, i, 6 - i - k);
        cout << "Переместить диск " << n << " с " << i << " на " << k << " стержень." << endl;
        hanoi(n - 1, 6 - i - k, k);
    }
}

int main() {
    setlocale(LC_ALL, "RUS");
    int n;
    int i, k;

    while (true) {
        cout << "Введите количество дисков: ";
        cin >> n;
        if (n <= 0) {
        cout << "Ошибка: количество дисков должно быть больше и не равно 0. Попробуйте снова." << endl;
        }
        else {
            break;
        }
    }

    while (true) {
        cout << "Введите исходный стержень: ";
        cin >> i;

        if (i < 1 || i > 3) {
            cout << "Ошибка: стержни должны быть в диапазоне от 1 до 3. Попробуйте снова." << endl;
        }
        else {
            break; 
        }
    }

    while (true) {
        cout << "Введите конечный стержень: ";
        cin >> k;

        if (k < 1 || k > 3) {
            cout << "Ошибка: стержни должны быть в диапазоне от 1 до 3. Попробуйте снова." << endl;
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
    cout << "Время выполнения: " << elapsed.count() << " секунд." << endl;
    cout << "Число ходов: " << nm << endl;

    return 0;
}
