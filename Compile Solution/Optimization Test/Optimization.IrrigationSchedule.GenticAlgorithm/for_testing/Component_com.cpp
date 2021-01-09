#include "Component_com.hpp"

Component::Component()
{
  g_pModule->InitializeComponentInstanceEx(&m_hinst);
}
Component::~Component()
{
  if (m_hinst)
    g_pModule->TerminateInstance(&m_hinst);
}

HRESULT __stdcall Component::Analyze(/*[in]*/VARIANT simulator) {
  return( CallComFcn( "Analyze", 0, 0, 1, &simulator ) );
}

HRESULT __stdcall Component::Configurate(/*[in]*/VARIANT path) {
  return( CallComFcn( "Configurate", 0, 0, 1, &path ) );
}

HRESULT __stdcall Component::Description(/*[in]*/VARIANT path) {
  return( CallComFcn( "Description", 0, 0, 1, &path ) );
}
HRESULT __stdcall Component::MCRWaitForFigures()
{
  mclWaitForFiguresToDie(m_hinst);
  return(S_OK);
}
