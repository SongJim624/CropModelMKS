#include "Core_com.hpp"

Core::Core()
{
  g_pModule->InitializeComponentInstanceEx(&m_hinst);
}
Core::~Core()
{
  if (m_hinst)
    g_pModule->TerminateInstance(&m_hinst);
}

HRESULT __stdcall Core::Analyze(/*[in]*/VARIANT simulator) {
  return( CallComFcn( "Analyze", 0, 0, 1, &simulator ) );
}

HRESULT __stdcall Core::Configurate(/*[in]*/VARIANT path) {
  return( CallComFcn( "Configurate", 0, 0, 1, &path ) );
}

HRESULT __stdcall Core::Description(/*[in]*/VARIANT path) {
  return( CallComFcn( "Description", 0, 0, 1, &path ) );
}
HRESULT __stdcall Core::MCRWaitForFigures()
{
  mclWaitForFiguresToDie(m_hinst);
  return(S_OK);
}
