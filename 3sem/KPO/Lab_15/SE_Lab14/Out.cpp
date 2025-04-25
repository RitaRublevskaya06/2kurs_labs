#include "stdafx.h"
#include "Out.h"
#include "In.h"
#include "Error.h"

using namespace std;

namespace Out
{
    OUT getout(const wchar_t* outfile) {
        OUT out;
        out.stream = new std::ofstream(outfile, std::ios::out | std::ios::trunc); // ��������� ���� �� ������
        if (!out.stream->is_open()) {
            delete out.stream;
            throw ERROR_THROW(112);
        }
        wcscpy_s(out.outfile, _countof(out.outfile), outfile);
        return out;
    }

    void WriteOut(OUT& out, const In::IN& in) {
        if (out.stream && out.stream->is_open()) {
            // ����������� unsigned char* � char*
            for (size_t i = 0; i < in.size; ++i) {
                *out.stream << static_cast<char>(in.text[i]);
            }
        }
    }

    void WriteError(OUT& out, const Error::ERROR& error) {
        if (out.stream && out.stream->is_open()) {
            *out.stream << "--- ������ --- " << endl;
            *out.stream << "������ " << error.id << ": " << error.message << endl;

            if (error.inext.line != -1) {
                *out.stream << "������ " << error.inext.line << " �������: " << error.inext.col << endl << endl;
            }
        }
    }

    void Close(OUT& out) {
        if (out.stream) {
            if (out.stream->is_open()) {
                out.stream->close();
            }
            delete out.stream;
            out.stream = nullptr;
        }
    }
}
