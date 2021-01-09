#ifndef Optimization_For_Example_Component_com_HPP
#define Optimization_For_Example_Component_com_HPP 1

#include <windows.h>
#include "Optimization_For_Example_idl.h"
#include "mclmcrrt.h"
#include "mclcom.h"
#include "mclcommain.h"
#include "mclcomclass.h"

class Component : public CMCLClassImpl<IComponent, &IID_IComponent, Component, 
                                        &CLSID_Component>
{
public:
  Component();
  ~Component();

  HRESULT __stdcall Analyze(/*[in]*/VARIANT simulator); 

  HRESULT __stdcall Configurate(/*[in]*/VARIANT path); 

  HRESULT __stdcall Description(/*[in]*/VARIANT path); 
  HRESULT __stdcall MCRWaitForFigures();
};
#endif
