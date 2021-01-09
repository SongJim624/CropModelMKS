

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 8.01.0622 */
/* at Tue Jan 19 11:14:07 2038
 */
/* Compiler settings for C:\Users\Song Jim\Desktop\CropModelMKS\Compile Solution\CropModelMKS\CropModelMKS_Optimization_SCEUA\Generated\server.idl:
    Oicf, W1, Zp8, env=Win64 (32b run), target_arch=AMD64 8.01.0622 
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

#ifndef __server_h_h__
#define __server_h_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IAnalyzer_FWD_DEFINED__
#define __IAnalyzer_FWD_DEFINED__
typedef interface IAnalyzer IAnalyzer;

#endif 	/* __IAnalyzer_FWD_DEFINED__ */


#ifndef __Analyzer_FWD_DEFINED__
#define __Analyzer_FWD_DEFINED__

#ifdef __cplusplus
typedef class Analyzer Analyzer;
#else
typedef struct Analyzer Analyzer;
#endif /* __cplusplus */

#endif 	/* __Analyzer_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __IAnalyzer_INTERFACE_DEFINED__
#define __IAnalyzer_INTERFACE_DEFINED__

/* interface IAnalyzer */
/* [dual][oleautomation][uuid][object] */ 


EXTERN_C const IID IID_IAnalyzer;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("4d919fe6-03dc-43cd-b325-8b9b4f9a7eac")
    IAnalyzer : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Analyze( 
            /* [in] */ IDispatch *isimulator) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Configurate( 
            /* [in] */ BSTR configuration) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Description( 
            /* [in] */ BSTR path) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IAnalyzerVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IAnalyzer * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IAnalyzer * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IAnalyzer * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IAnalyzer * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IAnalyzer * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IAnalyzer * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IAnalyzer * This,
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
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Analyze )( 
            IAnalyzer * This,
            /* [in] */ IDispatch *isimulator);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Configurate )( 
            IAnalyzer * This,
            /* [in] */ BSTR configuration);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Description )( 
            IAnalyzer * This,
            /* [in] */ BSTR path);
        
        END_INTERFACE
    } IAnalyzerVtbl;

    interface IAnalyzer
    {
        CONST_VTBL struct IAnalyzerVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IAnalyzer_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IAnalyzer_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IAnalyzer_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IAnalyzer_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IAnalyzer_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IAnalyzer_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IAnalyzer_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define IAnalyzer_Analyze(This,isimulator)	\
    ( (This)->lpVtbl -> Analyze(This,isimulator) ) 

#define IAnalyzer_Configurate(This,configuration)	\
    ( (This)->lpVtbl -> Configurate(This,configuration) ) 

#define IAnalyzer_Description(This,path)	\
    ( (This)->lpVtbl -> Description(This,path) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IAnalyzer_INTERFACE_DEFINED__ */



#ifndef __CropModelMKS_Optimization_SCEUALib_LIBRARY_DEFINED__
#define __CropModelMKS_Optimization_SCEUALib_LIBRARY_DEFINED__

/* library CropModelMKS_Optimization_SCEUALib */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_CropModelMKS_Optimization_SCEUALib;

EXTERN_C const CLSID CLSID_Analyzer;

#ifdef __cplusplus

class DECLSPEC_UUID("5e3da706-74dc-4136-bacd-da70c3feb275")
Analyzer;
#endif
#endif /* __CropModelMKS_Optimization_SCEUALib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  BSTR_UserSize(     unsigned long *, unsigned long            , BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserMarshal(  unsigned long *, unsigned char *, BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserUnmarshal(unsigned long *, unsigned char *, BSTR * ); 
void                      __RPC_USER  BSTR_UserFree(     unsigned long *, BSTR * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


