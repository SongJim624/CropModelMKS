// WrapperFortran.h: CWrapperFortran 的声明

#pragma once
#include "resource.h"       // 主符号



#include "Wrapper_i.h"



#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE 平台(如不提供完全 DCOM 支持的 Windows Mobile 平台)上无法正确支持单线程 COM 对象。定义 _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA 可强制 ATL 支持创建单线程 COM 对象实现并允许使用其单线程 COM 对象实现。rgs 文件中的线程模型已被设置为“Free”，原因是该模型是非 DCOM Windows CE 平台支持的唯一线程模型。"
#endif

using namespace ATL;


// CWrapperFortran

class ATL_NO_VTABLE CWrapperFortran :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CWrapperFortran, &CLSID_WrapperFortran>,
	public IDispatchImpl<IWrapperFortran, &IID_IWrapperFortran, &LIBID_WrapperLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CWrapperFortran()
	{
		CoInitialize(NULL);
		idisp = nullptr;
	}

	~CWrapperFortran()
	{
		idisp = nullptr;
		CoUninitialize();
	}

DECLARE_REGISTRY_RESOURCEID(106)


BEGIN_COM_MAP(CWrapperFortran)
	COM_INTERFACE_ENTRY(IWrapperFortran)
	COM_INTERFACE_ENTRY(IDispatch)
END_COM_MAP()



	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
	}

private:
	CComDispatchDriver idisp;

public:

	virtual HRESULT _stdcall Attach(IDispatch* disp)
	{
		idisp.Attach(disp);
		return S_OK;
	};

	virtual HRESULT _stdcall Detach()
	{
		idisp.Detach();
		return S_OK;
	}

	virtual HRESULT _stdcall Inquire(BSTR name, VARIANT* value)
	{
		return idisp.Invoke1(L"Inquire", &CComVariant(name), value);
	}

	virtual HRESULT _stdcall Write(BSTR name, VARIANT value)
	{
		return idisp.Invoke2(L"Write", &CComVariant(name), &value);
	}

	virtual HRESULT _stdcall Receive(VARIANT value)
	{
		return idisp.Invoke1(L"Receive", &value);
	}
};

OBJECT_ENTRY_AUTO(__uuidof(WrapperFortran), CWrapperFortran)
