#include "Simulator.h"

bool Parameter::Inquire(const char* name, float** value, long* size)
{
    if(parameters.find(std::string(name)) == parameters.end())
    {
        return false;
    }
    else 
    {
        *size = paramters[std::string(name)].size();
        *value = new float[*size];

        for(long i = 0; i < *size; ++i)
        {
            *value[i] = parameters[std::string(name)][i];
        }

        return true;
    }
}

bool Parameter::Change(const char* name, float* value, long size)
{
    if(parameters.find(std::string(name)) == parameters.end())
    {
        return false;
    }
    else
    {
        parameters[std::string(name)] = std::vector<float>(value, value + size);
        return true;
    }
}