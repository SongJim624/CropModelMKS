// dllmain.h: 模块类的声明。

class CEnvironmentWaterBalanceExampleModule : public ATL::CAtlDllModuleT< CEnvironmentWaterBalanceExampleModule >
{
public :
	DECLARE_LIBID(LIBID_EnvironmentWaterBalanceExampleLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_ENVIRONMENTWATERBALANCEEXAMPLE, "{4d5e0fe6-57f1-4595-905d-365632ac13eb}")
};

extern class CEnvironmentWaterBalanceExampleModule _AtlModule;
