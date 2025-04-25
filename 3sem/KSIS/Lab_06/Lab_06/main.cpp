#include <iostream>

using namespace std;

char* LongToChar(unsigned long num)
{
    // �������������� ����� � �������� �����
    char* buffer = new char[36]; // ����� + ����� + ����� ������
    int buffIndex = 34;
    int pointIndex = 0;
    while (buffIndex >= 0) {
        if (pointIndex != 8) {
            buffer[buffIndex--] = (num % 2 == 0) ? '0' : '1';
            num /= 2;
        }
        else {
            buffer[buffIndex--] = '.';
            pointIndex = -1;
        }
        pointIndex++;
    }
    buffer[35] = '\0';

    // �������� �������������� � ���������� ������� ���������
    char* ip = new char[16]; // 3 * 4 + 3 ����� + ����� ������
    int ipIndex = 0;

    char* buff = new char[9];
    buffIndex = 0;

    int newNum;
    for (int j = 0; j < 4; j++) {
        int i;
        for (i = j * 8 + j; i < 8 * (j + 1) + j; i++) {
            buff[buffIndex++] = buffer[i];
        }
        buffIndex = 0;
        newNum = 0;

        for (int i = 0; i < 8; i++) {
            newNum += (buff[i] - '0') * pow(2, 7 - i);
        }

        do {
            buff[buffIndex++] = newNum % 10 + '0';
            newNum /= 10;
        } while (newNum > 0);
        buff[buffIndex] = '\0';
        reverse(buff, buff + strlen(buff));

        for (int i = 0; i < buffIndex; i++) {
            ip[ipIndex++] = buff[i];
        }
        buffIndex = 0;

        if (j != 3) {
            ip[ipIndex++] = '.';
        }
        else {
            ip[ipIndex] = '\0';
        }
    }

    return ip;
}

bool CheckAddress(char* ip_)
{
    int points = 0,  // ���������� ����� 
        numbers = 0;  // �������� ������ 
    char* buff = new char[3]; // ����� ��� ������ ������

    for (int i = 0; ip_[i] != '\0'; i++) // ��� ������ IP-������ 
    {
        if (ip_[i] <= '9' && ip_[i] >= '0') // ���� ����� 
        {
            if (numbers > 3) return false; // ���� ������ ���� ����� � ������ � ������ 

            buff[numbers++] = ip_[i]; //����������� � ����� 
        }
        else
            if (ip_[i] == '.') // ���� ����� 
            {
                if (atoi(buff) > 255) { // ��������� �������� ������ 
                    return false;
                }
                if (numbers == 0) { //���� ����� ��� - ������ 
                    return false;
                }
                numbers = 0;
                points++;
                delete[]buff;
                buff = new char[3];
            }
            else return false;
    }
    if (points != 3) { // ���� ���������� ����� � IP-������ �� 3 - ������ 
        return false;
    }
    if (numbers == 0 || numbers > 3) {
        return false;
    }
    return true;
}


unsigned long CharToLong(char* ip_)
{
    unsigned long out = 0; // ����� ��� IP-������ 
    char* buff;
    buff = new char[3]; // ����� ��� �������� ������ ������  

    for (int i = 0, j = 0, k = 0; ip_[i] != '\0'; i++, j++)
    {
        if (ip_[i] != '.') { //���� �� ����� 
            buff[j] = ip_[i]; // �������� ������ � �����
        }
        if (ip_[i] == '.' || ip_[i + 1] == '\0') // ���� ��������� ����� ��� ��������� 
        {
            out <<= 8;   //�������� ����� �� 8 ��� 
            if (atoi(buff) > 255) { // �c�� ����� ������ 255 � ������
                return NULL;
            }
            out += (unsigned long)atoi(buff); //������������� � �������� � �����
            k++;
            j = -1;
            delete[]buff;
            buff = new char[3];
        }
    }
    return out;
}

bool CheckMask(unsigned long mask)
{
    char* buffer = new char[33]; // ����� + ������� + ����� ������
    int index = 31;
    while (index >= 0) {
        buffer[index--] = (mask % 2 == 0) ? '0' : '1';
        mask /= 2;
    }
    buffer[32] = '\0';

    int difference = 0;

    for (int i = 0; i < 31; i++) {
        if (buffer[i] != buffer[i + 1]) {
            difference++;
        }
    }
    delete[] buffer;
    return difference == 1;
}

int main()
{
    setlocale(LC_CTYPE, "Ru");
    unsigned long ip, mask, host, subnet, broadcast;
    char* ip_, * mask_;
    bool flag = true;
    ip_ = new char[16];
    mask_ = new char[16];
    do
    {
        if (!flag) cout << "������� ����� �����!" << endl;
        cout << "IP: ";
        cin >> ip_;
    } while (!(flag = CheckAddress(ip_)));
    ip = CharToLong(ip_);
    flag = true;

    do
    {
        if (!flag) cout << "������������ �����!" << endl;
        flag = true;
        do
        {
            if (!flag) cout << "������� ������� �����!" << endl;
            cout << "�����: ";
            cin >> mask_;
        } while (!(flag = CheckAddress(mask_)));
        mask = CharToLong(mask_);
    } while (!(flag = CheckMask(mask)));

    subnet = ip & mask;
    char* subnet_ = LongToChar(subnet);
    cout << "ID �������: " << subnet_ << endl;

    host = ip & ~mask;
    char* host_ = LongToChar(host);
    cout << "ID �����: " << host_ << endl;

    broadcast = ip & mask | ~mask;
    char* broadcast_ = LongToChar(broadcast);
    cout << "broad-cast �����: " << broadcast_ << endl;

    delete[] ip_;
    delete[] mask_;
    delete[] subnet_;
    delete[] host_;
    delete[] broadcast_;

    system("pause");
    return 0;
}