#include "stdafx.h"
#include "Log.h"
#include <iostream>
#include <ctime>

namespace Log
{
    // ������� ��� ��������� ������� ����������� �� �����
    LOG getlog(wchar_t logfile[])
    {
        LOG temp; // ��������� ��������� ��� �������� ���������� � ����
        // ������� ����� ��� ����� ����� � ������� char
        char* outFile = new char[wcslen(logfile) + 1];
        // ����������� ��� ����� �� wchar_t � char
        wcstombs_s(NULL, outFile, wcslen(logfile) + 1, logfile, wcslen(logfile) + 1);
        temp.stream = new std::ofstream; // ������� ����� ��� ������ � ����
        temp.stream->open(outFile); // ��������� ���� ��� ������
        // �������� �� ������ �������� �����
        if (!temp.stream->is_open())
        {
            ERROR_THROW(112); // ������ �������� �����
        }
        // �������� ��� ����� � ��������� �����������
        wcscpy_s(temp.logfile, logfile);
        return temp; // ���������� ������ �����������
    };

    // ������� ��� ������ ������ � ��� (� �������������� �������� ���� char)
    void WriteLine(LOG log, char* c, ...)
    {
        char** p = &c; // ��������� �� ������ ������� ���������

        // ���������� ��� ���������� ������ � ���
        while (*p != "")
        {
            (*log.stream) << *p; // ���������� ������� ������
            p += 1; // ��������� � ���������� ���������
        }
    };

    // ������� ��� ������ ������ � ��� (� �������������� �������� ���� wchar_t)
    void WriteLine(LOG log, wchar_t* c, ...)
    {
        wchar_t** p = &c; // ��������� �� ������ ������� ���������
        char buffer[50]; // ����� ��� �������������� ��������

        // ���������� ��� ���������� ������ � ���
        while (*p != L"")
        {
            wcstombs(buffer, *p, sizeof(buffer)); // ����������� ������ � char
            (*log.stream) << buffer; // ���������� � ���
            p += 1; // ��������� � ���������� ���������
        }
    };

    // ������� ��� ������ ��������� ����� � ���
    void WriteLog(LOG log)
    {
        char buffer[PARM_MAX_SIZE]; // ����� ��� �������� ��������� �����

        time_t rawtime; // ���������� ��� �������� �������
        struct tm* timeinfo; // ��������� ��� �������� ���������� � �������

        time(&rawtime); // �������� ������� �����
        timeinfo = localtime(&rawtime); // ����������� � ��������� �����

        // ����������� ��������� �����
        strftime(buffer, PARM_MAX_SIZE, "%d.%m.%Y %H:%M:%S", timeinfo);
        // ���������� ��������� ���� � ��������� ������
        (*log.stream) << "\n--� �������� �� \n" << buffer << " �� \n";
    };

    // ������� ��� ������ ���������� � ���
    void WriteParm(LOG log, Parm::PARM parm)
    {
        char inInfo[PARM_MAX_SIZE]; // ����� ��� ������� ����������
        char outInfo[PARM_MAX_SIZE]; // ����� ��� �������� ����������
        char logInfo[PARM_MAX_SIZE]; // ����� ��� ���������� � ����

        // ����������� ������� ��������� �� wchar_t � char
        wcstombs(inInfo, parm.in, sizeof(inInfo));
        wcstombs(outInfo, parm.out, sizeof(outInfo));
        wcstombs(logInfo, parm.log, sizeof(logInfo));

        // ���������� ��������� � ���
        (*log.stream) << "--� ��������� �� \n"
            << " -in: " << inInfo << "\n"
            << " -out: " << outInfo << "\n"
            << " -log: " << logInfo << "\n";
    };

    // ������� ��� ������ ���������� � ����� � ���
    void WriteIn(LOG log, In::IN in)
    {
        // ���������� ���������� ��������, ����� � ����������� �������� � ���
        (*log.stream) << "--� ��������� �� \n"
            << "���������� ��������: " << in.size << "\n"
            << "�����: " << in.lines << "\n"
            << "���������: " << in.ignor << "\n";
        // ��������� ���������� �� �������� ��������
        (*log.stream) << "������� ��������: " << in.spaces << "\n";

    };

    // ������� ��� ������ ���������� �� ������ � ���
    void WriteError(LOG log, Error::ERROR error)
    {
        // ���� ������� ���������� � ������, ��� ��������� ������
        if (error.inext.line != -1)
        {
            *log.stream << "������ � ������:\t" << error.inext.buff << std::endl; // ���������� ���������� ������
            *log.stream << "������: " << error.inext.line << " �������: " << error.inext.col << std::endl; // ���������� ����� ������ � �������
        }
        *log.stream << "������: " << error.id << ":" << error.message << std::endl; // ���������� ��� � ��������� �� ������
    }

    // ������� ��� �������� ������ �����������
    void Close(LOG log)
    {
        log.stream->close(); // ��������� �����
    }
};



//#include "stdafx.h"
//#include "Log.h"
//#include <iostream>
//#include <ctime>
//
//namespace Log
//{
//    // ������� ��� ��������� ������� ����������� �� �����
//    LOG getlog(wchar_t logfile[])
//    {
//        LOG temp; // ��������� ��������� ��� �������� ���������� � ����
//        // ������� ����� ��� ����� ����� � ������� char
//        char* outFile = new char[wcslen(logfile) + 1];
//        // ����������� ��� ����� �� wchar_t � char
//        wcstombs_s(NULL, outFile, wcslen(logfile) + 1, logfile, wcslen(logfile) + 1);
//        temp.stream = new std::ofstream; // ������� ����� ��� ������ � ����
//        temp.stream->open(outFile); // ��������� ���� ��� ������
//        // �������� �� ������ �������� �����
//        if (!temp.stream->is_open())
//        {
//            ERROR_THROW(112); // ������ �������� �����
//        }
//        // �������� ��� ����� � ��������� �����������
//        wcscpy_s(temp.logfile, logfile);
//        return temp; // ���������� ������ �����������
//    };
//
//    // ������� ��� ������ ������ � ��� (� �������������� �������� ���� char)
//    void WriteLine(LOG log, char* c, ...)
//    {
//        char** p = &c; // ��������� �� ������ ������� ���������
//
//        // ���������� ��� ���������� ������ � ���
//        while (*p != "")
//        {
//            (*log.stream) << *p; // ���������� ������� ������
//            p += 1; // ��������� � ���������� ���������
//        }
//    };
//
//    // ������� ��� ������ ������ � ��� (� �������������� �������� ���� wchar_t)
//    void WriteLine(LOG log, wchar_t* c, ...)
//    {
//        wchar_t** p = &c; // ��������� �� ������ ������� ���������
//        char buffer[50]; // ����� ��� �������������� ��������
//
//        // ���������� ��� ���������� ������ � ���
//        while (*p != L"")
//        {
//            wcstombs(buffer, *p, sizeof(buffer)); // ����������� ������ � char
//            (*log.stream) << buffer; // ���������� � ���
//            p += 1; // ��������� � ���������� ���������
//        }
//    };
//
//    // ������� ��� ������ ��������� ����� � ���
//    void WriteLog(LOG log)
//    {
//        char buffer[PARM_MAX_SIZE]; // ����� ��� �������� ��������� �����
//
//        time_t rawtime; // ���������� ��� �������� �������
//        struct tm* timeinfo; // ��������� ��� �������� ���������� � �������
//
//        time(&rawtime); // �������� ������� �����
//        timeinfo = localtime(&rawtime); // ����������� � ��������� �����
//
//        // ����������� ��������� �����
//        strftime(buffer, PARM_MAX_SIZE, "%d.%m.%Y %H:%M:%S", timeinfo);
//        // ���������� ��������� ���� � ��������� ������
//        (*log.stream) << "\n--� �������� �� \n" << buffer << " �� \n";
//    };
//
//    // ������� ��� ������ ���������� � ���
//    void WriteParm(LOG log, Parm::PARM parm)
//    {
//        char inInfo[PARM_MAX_SIZE]; // ����� ��� ������� ����������
//        char outInfo[PARM_MAX_SIZE]; // ����� ��� �������� ����������
//        char logInfo[PARM_MAX_SIZE]; // ����� ��� ���������� � ����
//
//        // ����������� ������� ��������� �� wchar_t � char
//        wcstombs(inInfo, parm.in, sizeof(inInfo));
//        wcstombs(outInfo, parm.out, sizeof(outInfo));
//        wcstombs(logInfo, parm.log, sizeof(logInfo));
//
//        // ���������� ��������� � ���
//        (*log.stream) << "--� ��������� �� \n"
//            << " -in: " << inInfo << "\n"
//            << " -out: " << outInfo << "\n"
//            << " -log: " << logInfo << "\n";
//    };
//
//    // ������� ��� ������ ���������� � ����� � ���
//    void WriteIn(LOG log, In::IN in)
//    {
//        // ���������� ���������� ��������, ����� � ����������� �������� � ���
//        (*log.stream) << "--� ��������� �� \n"
//            << "���������� ��������: " << in.size << "\n"
//            << "�����: " << in.lines << "\n"
//            << "���������: " << in.ignor << "\n";
//    };
//
//    // ������� ��� ������ ���������� �� ������ � ���
//    void WriteError(LOG log, Error::ERROR error)
//    {
//        // ���� ������� ���������� � ������, ��� ��������� ������
//        if (error.inext.line != -1)
//        {
//            *log.stream << "������ � ������:\t" << error.inext.buff << std::endl; // ���������� ���������� ������
//            *log.stream << "������: " << error.inext.line << " �������: " << error.inext.col << std::endl; // ���������� ����� ������ � �������
//        }
//        *log.stream << "������: " << error.id << ":" << error.message << std::endl; // ���������� ��� � ��������� �� ������
//    }
//
//    // ������� ��� �������� ������ �����������
//    void Close(LOG log)
//    {
//        log.stream->close(); // ��������� �����
//    }
//};
