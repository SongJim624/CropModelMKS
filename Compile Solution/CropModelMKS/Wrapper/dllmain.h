// dllmain.h: 模块类的声明。

class CWrapperModule : public ATL::CAtlDllModuleT< CWrapperModule >
{
public :
	DECLARE_LIBID(LIBID_WrapperLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_WRAPPER, "{97851893-618e-43d2-ab68-c8dee0fb6c94}")
};

extern class CWrapperModule _AtlModule;
