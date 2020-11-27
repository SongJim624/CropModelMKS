// dllmain.h: 模块类的声明。

class CCropModelMKSPlantNoneModule : public ATL::CAtlDllModuleT< CCropModelMKSPlantNoneModule >
{
public :
	DECLARE_LIBID(LIBID_CropModelMKSPlantNoneLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_CROPMODELMKSPLANTNONE, "{c6705f1f-3c9d-45e5-990d-6222fcd45cbf}")
};

extern class CCropModelMKSPlantNoneModule _AtlModule;
