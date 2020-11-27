// dllmain.h: 模块类的声明。

class CCropModelMKSClimateDefaultModule : public ATL::CAtlDllModuleT< CCropModelMKSClimateDefaultModule >
{
public :
	DECLARE_LIBID(LIBID_CropModelMKSClimateDefaultLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_CROPMODELMKSCLIMATEDEFAULT, "{8c0618fe-2575-4174-874a-3167a325d9a7}")
};

extern class CCropModelMKSClimateDefaultModule _AtlModule;
