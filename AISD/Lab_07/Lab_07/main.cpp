#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

void createLIS(const vector<int>& first_vector, const vector<vector<int>>& prev, vector<int>& currentLIS, vector<vector<int>>& fullLIS, int index) {

    currentLIS.push_back(first_vector[index]);

    if (prev[index].empty()) {
        vector<int> lis(currentLIS.rbegin(), currentLIS.rend());
        fullLIS.push_back(lis);
    }
    else {
        for (int prevIndex : prev[index]) {
            createLIS(first_vector, prev, currentLIS, fullLIS, prevIndex);
        }
    }

    currentLIS.pop_back();
}

vector<vector<int>> findAllLIS(const vector<int>& first_vector) {
    int n = first_vector.size();
    vector<int> d(n, 1);
    vector<vector<int>> prev(n); 

    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < i; ++j) {
            if (first_vector[j] < first_vector[i] && d[j] + 1 > d[i]) {
                d[i] = d[j] + 1;
                prev[i].clear();
                prev[i].push_back(j);
            }
            else if (first_vector[j] < first_vector[i] && d[j] + 1 == d[i]) {
                prev[i].push_back(j);
            }
        }
    }


    int maxLength = *max_element(d.begin(), d.end());


    vector<vector<int>> fullLIS; 
    vector<int> currentLIS; 

    for (int i = 0; i < n; ++i) {
        if (d[i] == maxLength) {
            createLIS(first_vector, prev, currentLIS, fullLIS, i);
        }
    }
    return fullLIS;
}

int main() {
    setlocale(LC_ALL, "RUS");
    int N;

    cout << "Введите N: ";
    cin >> N;

    vector<int> start_vector(N);
    cout << "Введите элементы последовательности: ";
    for (int i = 0; i < N; ++i) {
        cin >> start_vector[i];
    }

    vector<vector<int>> fullLIS = findAllLIS(start_vector);

    cout << "Все максимальные возрастающие подпоследовательности: " << endl;
    for (const auto& lis : fullLIS) {
        for (int num : lis) {
            cout << num << " ";
        }
        cout << endl;
    }

    cout << "Количество возрастающих подпоследовательностей: " << fullLIS.size() << endl;

    return 0;
}