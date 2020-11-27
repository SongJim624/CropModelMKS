// dllmain.h: 模块类的声明。

class CPlantWaterDrivenExampleModule : public ATL::CAtlDllModuleT< CPlantWaterDrivenExampleModule >
{
public :
	DECLARE_LIBID(LIBID_PlantWaterDrivenExampleLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_PLANTWATERDRIVENEXAMPLE, "{97d12f7e-3311-4d3d-b6d6-892ac7b66c03}")
};

extern class CPlantWaterDrivenExampleModule _AtlModule;
