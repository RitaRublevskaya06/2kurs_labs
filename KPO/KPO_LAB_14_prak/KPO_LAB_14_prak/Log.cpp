#include "stdafx.h"
#include "Log.h"
#include <cstdarg>
#include <cstring>
using namespace std;

namespace Log {
    LOG getlog(wchar_t logfile[]) {
        LOG log;
        log.stream = new ofstream;
        log.stream->open(logfile);
        if (!log.stream->is_open()) {
            throw ERROR_THROW(112);
        }
        wcscpy_s(log.logfile, logfile);
        return log;
    }

    void WriteLine(LOG log, const char* format, ...) {
        va_list args;
        va_start(args, format);

        char buffer[1024];
        vsnprintf(buffer, sizeof(buffer), format, args);

        *log.stream << buffer << std::endl;

        va_end(args);
    }

    void WriteLine(LOG log, const wchar_t* format, ...) {
        va_list args;
        va_start(args, format);

        wchar_t buffer[1024];
        vswprintf(buffer, sizeof(buffer), format, args);

        char converted[1024];
        wcstombs_s(nullptr, converted, buffer, sizeof(converted));

        *log.stream << converted << std::endl;

        va_end(args);
    }

    void WriteLog(LOG log) {
        char date[100];
        tm local;
        time_t currentTime;
        currentTime = time(NULL);
        localtime_s(&local, &currentTime);
        strftime(date, 100, "%d.%m.%Y %H:%M:%S", &local);
        *log.stream << "--- Протокол --- Дата: " << date << endl;
    }

    void WriteParm(LOG log, Parm::PARM parm) {
        char buf[PARM_MAX_SIZE];
        size_t size_one = 0;
        *log.stream << "--- Параметры ---" << endl;
        wcstombs_s(&size_one, buf, parm.log, PARM_MAX_SIZE);
        *log.stream << "-log: " << buf << endl;
        wcstombs_s(&size_one, buf, parm.out, PARM_MAX_SIZE);
        *log.stream << "-out: " << buf << endl;
        wcstombs_s(&size_one, buf, parm.in, PARM_MAX_SIZE);
        *log.stream << "-in: " << buf << endl;
    }

    void WriteIn(LOG log, In::IN in) {
        *log.stream << "Исходные данные: " << endl;
        *log.stream << "Количество символов: " << in.size << endl;
        *log.stream << "Количество строк: " << in.lines << endl;
        *log.stream << "Проигнорировано символов: " << in.ignor << endl;
    }

    void WriteError(LOG log, Error::ERROR error) {
        *log.stream << "Ошибки: " << endl;
        *log.stream << "Ошибка " << error.id << ": " << error.message << endl;
        if (error.inext.line != -1) {
            *log.stream << "Строка: " << error.inext.line << " Символ: " << error.inext.col << endl;
        }
    }

    void Close(LOG log) {
        log.stream->close();
        delete log.stream;
    }
}
