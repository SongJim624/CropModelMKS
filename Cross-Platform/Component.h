
class Component
{
public:
    Component(INQUIRE states, INQUIRE parameters, WRITE s);
    virtual ~Component();

    virtual bool Inquire(const char* name, float**value, long*size) = 0;
    virtual bool Update(WRITE write, INQUIRE inquire) = 0;
};