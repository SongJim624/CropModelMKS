// Simulator.h: CSimulator 的声明

#pragma once
#include "resource.h"       // 主符号



#include "Wrapper_i.h"



#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE 平台(如不提供完全 DCOM 支持的 Windows Mobile 平台)上无法正确支持单线程 COM 对象。定义 _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA 可强制 ATL 支持创建单线程 COM 对象实现并允许使用其单线程 COM 对象实现。rgs 文件中的线程模型已被设置为“Free”，原因是该模型是非 DCOM Windows CE 平台支持的唯一线程模型。"
#endif

using namespace ATL;


// CSimulator

class ATL_NO_VTABLE CSimulator :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CSimulator, &CLSID_Simulator>,
	public IDispatchImpl<ISimulator, &IID_ISimulator, &LIBID_WrapperLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CSimulator(){}

DECLARE_REGISTRY_RESOURCEID(107)


BEGIN_COM_MAP(CSimulator)
	COM_INTERFACE_ENTRY(ISimulator)
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
	CComDispatchDriver simulator;

public:
	virtual HRESULT _stdcall Attach(IDispatch* isimulator)
	{
		simulator.Attach(isimulator);
		return S_OK;
	}

	virtual HRESULT _stdcall Inquire(BSTR name, LONG index, VARIANT* value)
	{
		return simulator.Invoke2(L"Inquire", &CComVariant(name), &CComVariant(index), value);
	}

	virtual HRESULT _stdcall Change(BSTR lib, LONG index, BSTR name, VARIANT value)
	{
		CComVariant args[4] = { CComVariant(lib), CComVariant(index), CComVariant(name), value };
		return simulator.InvokeN(L"Change", args, 4);
	}

	virtual HRESULT _stdcall Detach()
	{
		simulator.Detach();
		return S_OK;
	}
};

OBJECT_ENTRY_AUTO(__uuidof(Simulator), CSimulator)
