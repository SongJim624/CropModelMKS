#include <map>
#include "Component.h"

typedef bool (*INQUIRE)(const char*, float**, long*);
typedef bool (*WRITE)(const char*, float*, long);

extern "C" unsigned long Initialzie(INQUIRE states, INQUIRE parameters);
extern "C" bool Inquire(unsigned long index, const char* name, float** value, long* size);
extern "C" bool Update(unsigned long index, WRITE write, INQUIRE inquire);
extern "C" void Finalize(unsigned long index);

extern "C" bool Describe(const char* path);
extern "C" bool Convert(const char* xml, const char* file);