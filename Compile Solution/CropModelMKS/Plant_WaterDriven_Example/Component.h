// Component.h: CComponent 的声明

#pragma once
#pragma comment(lib, "comsuppw.lib")
#pragma comment(lib, "kernel32.lib")
#include "resource.h"       // 主符号



#include "PlantWaterDrivenExample_i.h"



#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE 平台(如不提供完全 DCOM 支持的 Windows Mobile 平台)上无法正确支持单线程 COM 对象。定义 _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA 可强制 ATL 支持创建单线程 COM 对象实现并允许使用其单线程 COM 对象实现。rgs 文件中的线程模型已被设置为“Free”，原因是该模型是非 DCOM Windows CE 平台支持的唯一线程模型。"
#endif

using namespace ATL;
#include <string>
#include <comutil.h>
#include "..\..\..\Sources\Components\Plant.WaterDriven.Example\Core.h"

// CComponent

class ATL_NO_VTABLE CComponent :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CComponent, &CLSID_Component>,
	public IDispatchImpl<IComponent, &IID_IComponent, &LIBID_PlantWaterDrivenExampleLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CComponent() : core(nullptr){}
	~CComponent() { delete core; core = nullptr; }

DECLARE_REGISTRY_RESOURCEID(106)


BEGIN_COM_MAP(CComponent)
	COM_INTERFACE_ENTRY(IComponent)
	COM_INTERFACE_ENTRY(IDispatch)
END_COM_MAP()



	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease(){}

private:
	Core<float>* core;

public:

	virtual HRESULT _stdcall Initialize(IDispatch* istates, IDispatch* iparameters)
	{
		//if (core != nullptr) { delete core; core = nullptr; }
		core = new Core<float>(istates, iparameters);
		return S_OK;
	}

	virtual HRESULT _stdcall Update(IDispatch* istates)
	{
		return core->Update(ATL::CComDispatchDriver(istates));
	}

	virtual HRESULT _stdcall Inquire(BSTR name, IDispatch* istates)
	{
		std::string n = _bstr_t(name);
		return core->Inquire(n, ATL::CComDispatchDriver(istates));
	}

	virtual HRESULT _stdcall Description(BSTR path)
	{
		Describe<float>(std::string(_bstr_t(path)));
		return S_OK;
	}

	virtual HRESULT _stdcall Convert(BSTR file_path, BSTR xml_path)
	{
		return ::Convert(std::string(_bstr_t(file_path)), std::string(_bstr_t(xml_path)));
	}
};

OBJECT_ENTRY_AUTO(__uuidof(Component), CComponent)
