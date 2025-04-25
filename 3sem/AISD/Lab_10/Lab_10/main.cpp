#include <iostream>
#include <vector>
#include <iomanip>
#include <limits>
#include <cmath>
#include <algorithm>
#include <ctime>

using namespace std;

// ��������� ��� �������� ���������� � �������
struct Ant {
    vector<int> path;
    double distance;
};

// ������� ��� ��������� ������� ����������
vector<vector<double>> generateDistanceMatrix(int N) {
    vector<vector<double>> distanceMatrix(N, vector<double>(N));
    srand(time(0));

    for (int i = 0; i < N; ++i) {
        for (int j = 0; j < N; ++j) {
            if (i == j)
                distanceMatrix[i][j] = 0;
            else
                distanceMatrix[i][j] = rand() % 100 + 1; 
        }
    }
    return distanceMatrix;
}

// ������� ��� ������ ������� ����������
void printDistanceMatrix(const vector<vector<double>>& D) {
    cout << "������� ����������:" << endl;
    for (const auto& row : D) {
        for (const auto& dist : row) {
            cout << setw(4) << dist << '\t';
        }
        cout << endl;
    }
}

// ������� ���������� ���������� �� ��������
double calculatePathDistance(const vector<int>& path, const vector<vector<double>>& D) {
    double totalDistance = 0.0;
    for (size_t i = 0; i < path.size() - 1; ++i) {
        totalDistance += D[path[i]][path[i + 1]];
    }
    totalDistance += D[path.back()][path[0]];
    return totalDistance;
}

// �������� ������� ����������� ���������
void antColonyOptimization(int N, const vector<vector<double>>& D, double pheromoneInit, double alpha, double beta, int iterations) {
    vector<vector<double>> pheromone(N, vector<double>(N, pheromoneInit));
    double bestDistance = numeric_limits<double>::max();
    vector<int> bestPath;

    for (int iter = 0; iter < iterations; ++iter) {
        vector<Ant> ants(N);

        for (auto& ant : ants) {
            int startCity = rand() % N;
            ant.path.push_back(startCity);
            vector<bool> visited(N, false);
            visited[startCity] = true;

            for (int step = 1; step < N; ++step) {
                int currentCity = ant.path.back();
                double total = 0.0;
                vector<double> probabilities(N, 0.0);

                for (int city = 0; city < N; ++city) {
                    if (!visited[city]) {
                        probabilities[city] = pow(pheromone[currentCity][city], alpha) * pow(1.0 / D[currentCity][city], beta);
                        total += probabilities[city];
                    }
                }

                for (int city = 0; city < N; ++city) {
                    if (!visited[city]) {
                        probabilities[city] /= total;
                    }
                    else {
                        probabilities[city] = 0;
                    }
                }

                double r = ((double)rand() / (RAND_MAX));
                double cumulativeProbability = 0.0;
                int nextCity = -1;

                for (int city = 0; city < N; ++city) {
                    cumulativeProbability += probabilities[city];
                    if (cumulativeProbability >= r) {
                        nextCity = city;
                        break;
                    }
                }

                ant.path.push_back(nextCity);
                visited[nextCity] = true;
            }
            ant.distance = calculatePathDistance(ant.path, D);

            if (ant.distance < bestDistance) {
                bestDistance = ant.distance;
                bestPath = ant.path;
            }
        }

        cout << "---------------------------- �������� " << iter + 1 << " -------------------------------- ";
        cout << "\n������ �������: ";
        for (int city : bestPath) {
            cout << city << " ";
        }
        cout << " | ����������: " << bestDistance << endl;
    }
}

int main() {
    setlocale(LC_ALL, "rus");
    int N;
    cout << "������� ���������� �������: ";
    cin >> N;

    vector<vector<double>> D = generateDistanceMatrix(N);
    printDistanceMatrix(D);

    double pheromoneInit, alpha, beta;
    int iterations;

    cout << "������� ��������� �������� ��������� �� ������ �����: ";
    cin >> pheromoneInit;
    cout << "������� �������� ����� (����������� ������� ���������): ";
    cin >> alpha;
    cout << "������� �������� ���� (����������� ������� ����������): ";
    cin >> beta;
    cout << "������� ���������� �������� ���������: ";
    cin >> iterations;

    antColonyOptimization(N, D, pheromoneInit, alpha, beta, iterations);

    return 0;
}