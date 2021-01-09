#include "mwcomtypes.h"
#include "mclmcrrt.h"
#include "mclcom.h"
#include "mclcommain.h"
#include "Core_com.hpp"
#include "GenticAlgorithm_idl_i.c"
#include "mwcomutil_i.c"
#include "mwcomtypes_i.c"

#ifdef __cplusplus
extern "C" { // sbcheck:ok:extern_c
#endif
#ifdef __cplusplus
}
#endif


static bool _mcr_initialize_fcn(HMCRINSTANCE* inst,
                                const char* path_to_component,
                                mclCtfStream ctfStream)
{
    {
        if (ctfStream) {
            return mclInitializeComponentInstanceEmbedded(inst,
                nullptr,
                nullptr,
                ctfStream);
        } else {
            return false;
        }
    }      
  return false;

}
static bool _mcr_terminate_fcn(HMCRINSTANCE* inst)
{
  return mclTerminateInstance(inst);
}
static CMCLModule g_Module(_mcr_initialize_fcn, _mcr_terminate_fcn, true);
CMCLModule* g_pModule = &g_Module;

static _MCLOBJECT_MAP_ENTRY objectmap[] = 
{
  {
      &CLSID_Core, Core::RegisterClass, Core::UnregisterClass, Core::GetClassObject, 
    "Core", "GenticAlgorithm.Core", "GenticAlgorithm.Core.1_0"
  },
  {
    nullptr, nullptr, nullptr, nullptr, "", "", ""
  }
};

extern "C" { // sbcheck:ok:extern_c

BOOL WINAPI DllMain( HINSTANCE hInstance, DWORD dwReason, void *pv )
{
  return g_pModule->InitMain(objectmap, &LIBID_GenticAlgorithm, 1, 0, hInstance, 
                             dwReason, pv);
}

HRESULT __stdcall DllCanUnloadNow()
{
    return (g_pModule->GetLockCount()==0) ? S_OK : S_FALSE;
}

HRESULT __stdcall DllGetClassObject(REFCLSID clsid, REFIID iid, void **ppv )
{
    return g_pModule->GetClassObject( clsid, iid, ppv );
}

HRESULT __stdcall DllRegisterServer()
{
    return g_pModule->UpdateRegistry( TRUE );
}

HRESULT __stdcall DllUnregisterServer()
{
    return g_pModule->UpdateRegistry( FALSE );
}

}
