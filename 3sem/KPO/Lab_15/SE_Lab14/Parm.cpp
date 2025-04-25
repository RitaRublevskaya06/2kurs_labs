#include "stdafx.h"
#include "Parm.h"
#include "Error.h"

namespace Parm
{
    PARM getparm(int argc, wchar_t* argv[])
    {
        PARM parm;

        // Логические переменные для поиска -in, -out, -log
        bool in_find = false, out_find = false, log_find = false;

        for (int i = 1; i < argc; i++)
        {
            if (wcslen(argv[i]) >= PARM_MAX_SIZE - 1) { throw ERROR_THROW(104); } // Учитываем нуль-терминатор

            if (wcsstr(argv[i], PARM_IN))
            {
                wcscpy_s(parm.in, _countof(parm.in), argv[i] + wcslen(PARM_IN));
                in_find = true;
            }
            else if (wcsstr(argv[i], PARM_OUT))
            {
                wcscpy_s(parm.out, _countof(parm.out), argv[i] + wcslen(PARM_OUT));
                out_find = true;
            }
            else if (wcsstr(argv[i], PARM_LOG))
            {
                wcscpy_s(parm.log, _countof(parm.log), argv[i] + wcslen(PARM_LOG));
                log_find = true;
            }
        }

        if (!in_find) throw ERROR_THROW(100);

        if (!out_find)
        {
            wcscpy_s(parm.out, _countof(parm.out), parm.in);
            wcscat_s(parm.out, _countof(parm.out), PARM_OUT_DEFAULT_EXT);
        }

        if (!log_find)
        {
            wcscpy_s(parm.log, _countof(parm.log), parm.in);
            wcscat_s(parm.log, _countof(parm.log), PARM_LOG_DEFAULT_EXT);
        }

        // Проверка на дублирование имен
        if ((wcscmp(parm.in, parm.out) == 0) ||
            (wcscmp(parm.in, parm.log) == 0) ||
            (wcscmp(parm.out, parm.log) == 0)) {
            wcout << L"Ошибка: Параметры не могут иметь одинаковое имя." << endl;
            throw ERROR_THROW(105);
        }

        return parm;
    }
}
