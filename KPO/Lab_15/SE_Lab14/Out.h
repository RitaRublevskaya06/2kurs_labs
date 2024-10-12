#pragma once

#include "In.h"
#include "Parm.h"
#include "Error.h"

namespace Out {
    struct OUT {
        std::ofstream* stream;
        wchar_t outfile[256]; 
    };

    OUT getout(const wchar_t* outfile);
    void WriteOut(OUT& out, const In::IN& in);
    void WriteError(OUT& out, const Error::ERROR& error);
    void Close(OUT& out);
}
