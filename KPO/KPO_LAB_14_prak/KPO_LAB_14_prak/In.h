#pragma once
#define IN_MAX_LEN_TEXT 1024*1024
#define IN_CODE_ENDL '\n' 

#define MAX_LEN_LINE 1000
namespace In
{
	void dell_in(char* str, int index);
	struct IN
	{
		enum
		{
			T = 1024,
			F = 2048,
			I = 4096
		};

		int size,
			lines,
			ignor;

		unsigned char* text;

		int code[256] =
		{   
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::T, IN::F, IN::F, IN::I, IN::F, IN::F,
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
			IN::T, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::T, IN::I, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
			IN::F, IN::F, IN::F, IN::F, IN::T, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::T, IN::F, IN::F, IN::T,
			IN::F, IN::F, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,

			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::T, IN::F, IN::F, IN::T,
			IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
			IN::F, IN::F, IN::T, IN::F, IN::F, IN::T, IN::F, IN::F, IN::T, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,
			IN::T, IN::F, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F

		};


		IN() {
			// пробел     0          2          4          R           U          B          L         E          V           S          K            A         Y          A
			code[32] = code[48] = code[50] = code[52] = code[82] = code[85] = code[66] = code[76] = code[69] = code[86] = code[83] = code[75] = code[65] = code[89] = code[65] =
			//   M        A           R          G         A          R           I          T          A                   
			code[77] = code[65] = code[82] = code[71] = code[65] = code[82] = code[73] = code[84] = code[65] = 
			//   r         u            b            l         e          v           s           k           a           y          a
			code[114] = code[117] = code[98] = code[108] = code[101] = code[118] = code[115] = code[107] = code[97] = code[121] = code[97] =
			//   m         a            r            g         a          r           i           t           a          
			code[109] = code[97] = code[114] = code[103] = code[197] = code[114] = code[105] = code[116] = code[97] =
			//   Р         У            Б           Л          Е            В          С           К           А           Я         
			code[208] = code[211] = code[193] = code[203] = code[197] = code[194] = code[209] = code[202] = code[192] = code[223] = 
			//   М         А           Р          Г           А           Р            И           Т           А               
			code[204] = code[192] = code[208] = code[195] = code[192] = code[208] = code[200] = code[210] = code[192] =
			//   р         у            б           л         е            в            с           к            а          я         
			code[240] = code[243] = code[225] = code[235] = code[229] = code[226] = code[241] = code[234] = code[224] = code[255] =
			//   м         а           р          г           а            р           и           т           а          -     
			code[236] = code[224] = code[240] = code[227] = code[224] = code[240] = code[232] = code[242] = code[224] = code[45] = IN::T;

			code[81] = '!';
			code[88] = IN::I;

		}

	};
	
	IN getin(wchar_t infile[]);
}
