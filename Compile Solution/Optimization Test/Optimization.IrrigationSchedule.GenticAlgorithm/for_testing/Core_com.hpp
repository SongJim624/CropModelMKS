#ifndef GenticAlgorithm_Core_com_HPP
#define GenticAlgorithm_Core_com_HPP 1

#include <windows.h>
#include "GenticAlgorithm_idl.h"
#include "mclmcrrt.h"
#include "mclcom.h"
#include "mclcommain.h"
#include "mclcomclass.h"

class Core : public CMCLClassImpl<ICore, &IID_ICore, Core, &CLSID_Core>
{
public:
  Core();
  ~Core();

  HRESULT __stdcall Analyze(/*[in]*/VARIANT simulator); 

  HRESULT __stdcall Configurate(/*[in]*/VARIANT path); 

  HRESULT __stdcall Description(/*[in]*/VARIANT path); 
  HRESULT __stdcall MCRWaitForFigures();
};
#endif
