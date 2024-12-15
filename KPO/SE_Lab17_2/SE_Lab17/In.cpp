#include "stdafx.h"
using namespace std;

namespace In
{

    // ������� ��� �������� ������ �������� �� ������
    void removeExtraSpaces(std::string& input, int& spaces) // ������� ������ ������� �� ������� ������.
    {
        bool insideQuotes = false; // ���������� ��� ������������, ��������� �� �� ������ �������
        bool firstLine = true; // ���� ��� ������������ ������ ������

        // �������� �� ������� ������� � ������
        for (size_t i = 0; i < input.length(); ++i)
        {
            // ���������, �� ��������� �� �� �������
            if (input[i] == '\'')
            {
                insideQuotes = !insideQuotes; // ������ ��������� ������ �������
            }
            // ���� �� �� ������ ������� � ��������� ������
            if (!insideQuotes && input[i] == ' ')
            {
                size_t spacesToRemove = 0; // ������� ��� ���������������� ��������
                // ������� ���������� ���������������� �������� ����� �������� �������
                while (i + spacesToRemove < input.length() && input[i + spacesToRemove] == ' ')
                {
                    ++spacesToRemove;
                }
                // ���� ������� ����� ������ �������, ������� ��
                if (spacesToRemove > 1)
                {
                    input.erase(i + 0, spacesToRemove - 1);
                    spaces += spacesToRemove - 1; // ����������� ������� ��������� ��������
                    //input.erase(i + 1, spacesToRemove - 1);
                    //spaces += spacesToRemove - 1; // ����������� ������� ��������� ��������
                }
                // ������� ������, ���� �� �� ������ ��� ����� ������
                if (i == 0 || i == input.length() - 1)
                {
                    input.erase(i, 1);
                    spaces++; // ����������� ������� ��������� ��������
                }
                // ������� ������ ������ � ������ ������
                if (firstLine && i == 0 && spacesToRemove == 1)
                {
                    input.erase(i, 0);
                    //input.erase(i, 1);
                    //spaces++; // ����������� ������� ��������� ��������
                }
                // ���������� ���� ������ ������
                if (input[i] == '\n') {
                    firstLine = false;
                }
                // ��������� � ���������� ������� ����� �������� ��������
                i += spacesToRemove - 1;
            }
        }
    }

    // ������� ��� �������� �������� ������ ���������� � ������
    void removeSpacesAroundOperators(std::string& input, int& spaces) // ������� ������� ������ ���������� �� ������� ������.
    {
        const std::string operators = ";,}{()=+-/*"; // ������ ����������

        // �������� �� ������� ������� � ������
        for (size_t i = 0; i < input.length(); ++i)
        {
            // ���������, �������� �� ������� ������ ����������
            if (operators.find(input[i]) != std::string::npos)
            {
                // ������� ������� ����� ����������
                while (i > 0 && std::isspace(input[i - 1]))
                {
                    input.erase(i - 1, 1); // ������� ������
                    spaces++; // ����������� ������� ��������� ��������
                    --i; // �������� ������ �����
                }
                // ������� ������� ����� ���������
                while (i + 1 < input.length() && std::isspace(input[i + 1]))
                {
                    input.erase(i + 1, 1); // ������� ������
                    spaces++; // ����������� ������� ��������� ��������
                }
            }
        }
    }

    //// ������� ��� �������� ������ �������� �� ������
    //void removeExtraSpaces(std::string& input, int& spaces) // ������� ������ ������� �� ������� ������.
    //{
    //    bool insideQuotes = false; // ���������� ��� ������������, ��������� �� �� ������ �������
    //    bool firstLine = true; // ���� ��� ������������ ������ ������

    //    // �������� �� ������� ������� � ������
    //    for (size_t i = 0; i < input.length(); ++i)
    //    {
    //        // ���������, �� ��������� �� �� �������
    //        if (input[i] == '\'')
    //        {
    //            insideQuotes = !insideQuotes; // ������ ��������� ������ �������
    //        }
    //        // ���� �� �� ������ ������� � ��������� ������
    //        if (!insideQuotes && input[i] == ' ')
    //        {
    //            size_t spacesToRemove = 0; // ������� ��� ���������������� ��������
    //            // ������� ���������� ���������������� �������� ����� �������� �������
    //            while (i + spacesToRemove < input.length() && input[i + spacesToRemove] == ' ')
    //            {
    //                ++spacesToRemove;
    //            }
    //            // ���� ������� ����� ������ �������, ������� ��
    //            if (spacesToRemove > 1)
    //            {
    //                input.erase(i + 1, spacesToRemove - 1);
    //                spaces += spacesToRemove - 1; // ����������� ������� ��������� ��������
    //            }
    //            // ������� ������, ���� �� �� ������ ��� ����� ������
    //            if (i == 0 || i == input.length() - 1)
    //            {
    //                input.erase(i, 1);
    //                spaces++; // ����������� ������� ��������� ��������
    //            }
    //            // ������� ������ ������ � ������ ������
    //            if (firstLine && i == 0 && spacesToRemove == 1)
    //            {
    //                input.erase(i, 1);
    //                spaces++; // ����������� ������� ��������� ��������
    //            }
    //            // ���������� ���� ������ ������
    //            if (input[i] == '\n') {
    //                firstLine = false;
    //            }
    //            // ��������� � ���������� ������� ����� �������� ��������
    //            i += spacesToRemove - 1;
    //        }
    //    }
    //}

    //// ������� ��� �������� �������� ������ ���������� � ������
    //void removeSpacesAroundOperators(std::string& input) // ������� ������� ������ ���������� �� ������� ������.
    //{
    //    const std::string operators = ";,}{()=+-/*"; // ������ ����������

    //    // �������� �� ������� ������� � ������
    //    for (size_t i = 0; i < input.length(); ++i)
    //    {
    //        // ���������, �������� �� ������� ������ ����������
    //        if (operators.find(input[i]) != std::string::npos)
    //        {
    //            // ������� ������� ����� ����������
    //            while (i > 0 && std::isspace(input[i - 1]))
    //            {
    //                input.erase(i - 1, 1); // ������� ������
    //                --i; // �������� ������ �����
    //            }
    //            // ������� ������� ����� ���������
    //            while (i + 1 < input.length() && std::isspace(input[i + 1]))
    //            {
    //                input.erase(i + 1, 1); // ������� ������
    //            }
    //        }
    //    }
    //}

    IN getin(wchar_t infile[]) // ������� ��� ������ ������ �� ����� � �� ���������.
    {
        ifstream fin; // ������� ����� ��� ������ �����.
        char* outFile = new char[wcslen(infile) + 1]; // ������� ����� ��� ����� ����� � ������� char.
        wcstombs_s(NULL, outFile, wcslen(infile) + 1, infile, wcslen(infile) + 1); // ����������� ��� ����� �� wchar_t � char.
        fin.open(infile); // ��������� ���� ��� ������.
        if (fin.bad()) // ���������, �� ��������� �� ������ ��� �������� �����.
        {
            throw ERROR_THROW(116); // ���� ������, ����������� ����������.
        }
        if (!fin.is_open()) // ���� ���� �� ��������.
        {
            throw ERROR_THROW(110); // ����������� ����������.
        }

        IN resultIn; // ������� ��������� ��� �������� ������ �� �����.
        resultIn.size = 0; // �������������� ��������� ������ ������.
        resultIn.lines = 0; // �������������� ���������� �����.
        int position = 0; // ���������� ��� ������������ ������� � ������.
        int ch; // ���������� ��� �������� �������� �������.
        std::string currentLine; // ������ ��� ���������� ��������.
        std::string buffer; // ����� ��� ���������� ����� �� �����.

        while (std::getline(fin, buffer)) // ��������� ������ �� �����.
        {
            resultIn.lines++; // ����������� ���������� �����.
            for (int i = 0; i < buffer.length(); i++) // �������� �� �������� ��������� ������.
            {
                ch = buffer[i]; // �������� ������� ������.

                if (ch == fin.eof()) // ���� �������� ����� �����.
                {
                    break; // ������� �� �����.
                }

                switch (resultIn.code[(unsigned char)ch]) // ������ ������� � ������� ������� resultIn.code.
                {
                case IN::F: // ���� ������ �������� ������, ������ ��� ������ �������������, �� ��� �������������.
                {
                    resultIn.text.push_back(currentLine); // ��������� ������� ������ � ���������.
                    throw ERROR_THROW_IN(111, resultIn.lines, ++position, buffer, resultIn.text); // ����������� ���������� ��� ������.
                    break;
                }
                case IN::I: // ���� ������ ������������.
                {
                    resultIn.ignor++; // ����������� ������� ������������ ��������.
                    position++; // ����������� ������� ������� � ������� ������.
                    break;
                }
                case IN::T: // ���� ������ �������� ��������� ��������.
                {
                    currentLine += ch; // ��������� ������ � ������� ������.
                    position++; // ����������� ������� ������� � ������.
                    resultIn.size++; // ����������� ������ ������.
                    break;
                }
                default: // ���� ������ �� �������� �� � ���� �� ���������.
                {
                    currentLine += resultIn.code[(unsigned char)ch]; // ��������� ����������� ������.
                    resultIn.size++; // ����������� ������ ������.
                    position++; // ����������� ������� �������.
                    break;
                }
                }
            }

            if (!currentLine.empty()) // ���� ������� ������ �� ������.
            {
                resultIn.size++; // ����������� ������ ������.
                position++; // ����������� ������� �������.
                position = 0; // ���������� ������� ����� ��������� ������.
                currentLine += resultIn.code[IN_CODE_ENDL]; // ��������� ������ ����� ������.
                removeExtraSpaces(currentLine, resultIn.spaces); // ������� ������ ������� � ������.
                removeSpacesAroundOperators(currentLine, resultIn.spaces); // ������� ������� ������ ����������.
                resultIn.text.push_back(currentLine); // ��������� ������� ������ � ���������.
                currentLine.clear(); // ������� ������ ��� ��������� ��������.
            }
        }

        fin.close();
        return resultIn;
    }
}
