#include <string>
#include <map>
#include <list>
#include <array>
#include <string>

struct Time
{
public:    
    std::array<unsigned long, 6> data;
    const std::array<unsigned long, 6> base;
    const std::array<unsigned long, 6> solar;
    const std::array<unsigned long, 6> lunar;
public:
    long Julian();
    void Add(const unsigned long& value, const unsigned long& unit);
};

bool operator != (const Time& A, const Time& B);
bool operator == (const Time& A, const Time& B);
bool operator > (const Time& A, const Time& B);
bool operator < (const Time& A, const Time& B);

//
class Parameter
{
private:
    std::map<std::string, std::vector<float>> parameters;

public:
    Parameter();

    void Inquire(const char* name, float** value, long* size);
    void Change(const char* name, float * value, long size);
};

class State
{
private:
    std::map<std::string, std::vector<std::vector<float>>> states;

public:
    State();

    bool Inquire(const char* name, float* value, long* size);
};

//The component should be varied with the paltform.
class Component
{
private:
    long index;

public:
    //Load and Initialize the crop model
    Component();
    
    bool Update();
    bool Inquire(const std::string& name, float* value, long* size);
};

class Simulator
{
private:
    Time start, end, now;

private:
    std::map<std::string, Component*> libraries;
    std::map<std::string, std::string> dictionary;

    bool Inquire(const char* name, float** value, long* size);

    void Initialize();
public:
    Simulator(const char* configuration);
    ~Simulator();

    void Simulate(long till);

    void Inquire(const char* name, float** value, long* size);
    void Change(const char* lib, const char* name, float* value, long size);
};