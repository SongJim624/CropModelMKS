!
!  CropModelMKS_Fortran_DemonstrationGlobal.f90 - This file contains the global data and functions
!  for the COM Server
!
!  Generated by the Intel(R) Visual Fortran COM Server Wizard on
!  11/19/20 at 12:32:32.
!
!   DO NOT EDIT THIS FILE!
!
!  This file is re-generated every time the object hierarchy is changed.
!

!
!  M O D U L E S
!

!  Module containg DLL global data

module CropModelMKS_Fortran_Demonstration_Global
    use ifwinty
    use kernel32
    use IClassFactory_Types

    integer(HANDLE) ghinst
    integer         gCntLock
    type (T_RTL_CRITICAL_SECTION) gGlobalCriticalSection
    !  Per Class
    integer(int_ptr_kind()) gComponentIClassFactory
    type (IClassFactory_Data), pointer :: gpComponentCFData
    integer(int_ptr_kind()) gComponentITypeInfo

    ! Type Library GUID		
    type (guid), parameter :: GUID_TypeLib_CropModelMKS_Fortran_Demonstration = &
        GUID(#053432a3, #3461, #4df1, &
        char('87'X)//char('5a'X)//char('6b'X)//char('2f'X)// &
        char('bc'X)//char('ba'X)//char('23'X)//char('1d'X))

  contains

    integer function ServerLock ()
        integer(LONG) r
        r = InterlockedIncrement (loc(gCntLock)) 
        ServerLock = gCntLock
    end function

    integer function ServerUnlock ()
        integer(LONG) r
        r = InterlockedDecrement (loc(gCntLock)) 
        ServerUnlock = gCntLock
    end function

end module CropModelMKS_Fortran_Demonstration_Global

