// dllmain.h: 模块类的声明。

class CManagementScheduleExampleModule : public ATL::CAtlDllModuleT< CManagementScheduleExampleModule >
{
public :
	DECLARE_LIBID(LIBID_ManagementScheduleExampleLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_MANAGEMENTSCHEDULEEXAMPLE, "{44a06f19-414b-42b1-a9af-5520123f745a}")
};

extern class CManagementScheduleExampleModule _AtlModule;
