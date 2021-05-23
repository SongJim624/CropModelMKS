#include "Library.h"

unsigned long Intialize(INQUIRE states, INQUIRE parameters,  WRITE s)
{
    return reinterpret_cast<unsigned long>(new Plant(states, paramters, s));
}

bool Inquire(unsigned long index, const char* name, float** value, long* size)
{
    return reinterpret_cast<Plant*>(index)->Inquire(name, value, size);
}

bool Update(unsigned long index, WRITE write, INQUIRE inquire)
{
    return reinterpret_cast<Plant*>(index)->Update(write, inquire);
}

void Finalize(unsigned long address)
{
    delete reinterpret_cast<Plant*> (address);
}