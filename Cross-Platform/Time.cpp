#include "Simulator.h"

void Time::Add(const unsigned long& value, const unsigned long& unit)
{
    data[unit] += value;

    if(unit == 0)
    {
        return;
    }
    else if(unit == 2)
    {        
        while(remain != 0)
        {
            if(solar.find(data[1]))
            {
               if(data[unit] + remain > 31)
               {
                   remain -= 32 - data[unit];
                   data[unit] = 1;
                   Time::Add(1,  1);
               }
            }
            else if(lunar.find(data[1]))
            {

            }
            else if(data[0] % 4 == 0)
            {

            }
            else
            {
                data[unit] += value;
            }

        }
    }
    else
    {
        unsigned long amount = data[unit] / base[unit];
        data[unit] %= base[unit];

        Time::Add(amount, unit - 1);
    }
}

bool operator != (const Time& A, const Time& B)
{
    bool status = true ;

    for(unsigned long i = 0; i < 6; ++i)
    {
        status = status && A.data[i] != B.data[i]; 
    }    

    return status;
}

bool operator == (const Time& A, const Time& B)
{
    bool status = true ;

    for(unsigned long i = 0; i < 6; ++i)
    {
        status = status && A.data[i] == B.data[i]; 
    }    

    return status;
}

bool operator > (const Time& A, const Time& B)
{
    bool status = true ;

    for(unsigned long i = 0; i < 6; ++i)
    {
        status = status && A.data[i] > B.data[i]; 
    }    

    return status;
}

bool operator < (const Time& A, const Time& B)
{
    bool status = true ;

    for(unsigned long i = 0; i < 6; ++i)
    {
        status = status && A.data[i] < B.data[i]; 
    }    

    return status;
}