

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 8.01.0622 */
/* at Tue Jan 19 11:14:07 2038
 */
/* Compiler settings for C:\Users\Song Jim\Desktop\Optimization Test\Optimization.IrrigationSchedule.GenticAlgorithm\for_testing\GenticAlgorithm_idl.idl:
    Oicf, W1, Zp8, env=Win64 (32b run), target_arch=IA64 8.01.0622 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif /* __RPCNDR_H_VERSION__ */

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __GenticAlgorithm_idl_h__
#define __GenticAlgorithm_idl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __ICore_FWD_DEFINED__
#define __ICore_FWD_DEFINED__
typedef interface ICore ICore;

#endif 	/* __ICore_FWD_DEFINED__ */


#ifndef __Core_FWD_DEFINED__
#define __Core_FWD_DEFINED__

#ifdef __cplusplus
typedef class Core Core;
#else
typedef struct Core Core;
#endif /* __cplusplus */

#endif 	/* __Core_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"
#include "mwcomtypes.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __ICore_INTERFACE_DEFINED__
#define __ICore_INTERFACE_DEFINED__

/* interface ICore */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_ICore;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("ED5F5063-9845-4103-A21A-E0B46778FC8C")
    ICore : public IDispatch
    {
    public:
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_MWFlags( 
            /* [retval][out] */ IMWFlags **ppvFlags) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_MWFlags( 
            /* [in] */ IMWFlags *pvFlags) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE Analyze( 
            /* [in] */ VARIANT simulator) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE Configurate( 
            /* [in] */ VARIANT path) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE Description( 
            /* [in] */ VARIANT path) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE MCRWaitForFigures( void) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct ICoreVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICore * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICore * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICore * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ICore * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ICore * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ICore * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ICore * This,
            /* [annotation][in] */ 
            _In_  DISPID dispIdMember,
            /* [annotation][in] */ 
            _In_  REFIID riid,
            /* [annotation][in] */ 
            _In_  LCID lcid,
            /* [annotation][in] */ 
            _In_  WORD wFlags,
            /* [annotation][out][in] */ 
            _In_  DISPPARAMS *pDispParams,
            /* [annotation][out] */ 
            _Out_opt_  VARIANT *pVarResult,
            /* [annotation][out] */ 
            _Out_opt_  EXCEPINFO *pExcepInfo,
            /* [annotation][out] */ 
            _Out_opt_  UINT *puArgErr);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_MWFlags )( 
            ICore * This,
            /* [retval][out] */ IMWFlags **ppvFlags);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_MWFlags )( 
            ICore * This,
            /* [in] */ IMWFlags *pvFlags);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Analyze )( 
            ICore * This,
            /* [in] */ VARIANT simulator);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Configurate )( 
            ICore * This,
            /* [in] */ VARIANT path);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Description )( 
            ICore * This,
            /* [in] */ VARIANT path);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *MCRWaitForFigures )( 
            ICore * This);
        
        END_INTERFACE
    } ICoreVtbl;

    interface ICore
    {
        CONST_VTBL struct ICoreVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICore_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ICore_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ICore_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ICore_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define ICore_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define ICore_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define ICore_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define ICore_get_MWFlags(This,ppvFlags)	\
    ( (This)->lpVtbl -> get_MWFlags(This,ppvFlags) ) 

#define ICore_put_MWFlags(This,pvFlags)	\
    ( (This)->lpVtbl -> put_MWFlags(This,pvFlags) ) 

#define ICore_Analyze(This,simulator)	\
    ( (This)->lpVtbl -> Analyze(This,simulator) ) 

#define ICore_Configurate(This,path)	\
    ( (This)->lpVtbl -> Configurate(This,path) ) 

#define ICore_Description(This,path)	\
    ( (This)->lpVtbl -> Description(This,path) ) 

#define ICore_MCRWaitForFigures(This)	\
    ( (This)->lpVtbl -> MCRWaitForFigures(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __ICore_INTERFACE_DEFINED__ */



#ifndef __GenticAlgorithm_LIBRARY_DEFINED__
#define __GenticAlgorithm_LIBRARY_DEFINED__

/* library GenticAlgorithm */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_GenticAlgorithm;

EXTERN_C const CLSID CLSID_Core;

#ifdef __cplusplus

class DECLSPEC_UUID("ACF23C1D-B420-4757-9C6C-F1965F288550")
Core;
#endif
#endif /* __GenticAlgorithm_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  VARIANT_UserSize(     unsigned long *, unsigned long            , VARIANT * ); 
unsigned char * __RPC_USER  VARIANT_UserMarshal(  unsigned long *, unsigned char *, VARIANT * ); 
unsigned char * __RPC_USER  VARIANT_UserUnmarshal(unsigned long *, unsigned char *, VARIANT * ); 
void                      __RPC_USER  VARIANT_UserFree(     unsigned long *, VARIANT * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


