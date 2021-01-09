// dllmain.h: 模块类的声明。

class CToolsModule : public ATL::CAtlDllModuleT< CToolsModule >
{
public :
	DECLARE_LIBID(LIBID_ToolsLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_TOOLS, "{b7563413-869a-4b64-ad18-a131a6085bc7}")
};

extern class CToolsModule _AtlModule;
