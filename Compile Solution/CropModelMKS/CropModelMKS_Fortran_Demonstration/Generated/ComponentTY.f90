!
!  ComponentTY.f90 - This module contains definitions of the Component class
!
!  Generated by the Intel(R) Visual Fortran COM Server Wizard on
!  11/19/20 at 12:32:32.
!
!   DO NOT EDIT THIS FILE!
!
!  This file is re-generated every time the object hierarchy is changed.
!

module Component_Types

    use Component_USE
    use ifwinty

    !  Strings used in registering class
    character*16, parameter :: Component_CLASS_NAME = ("Component Class")
    character*34, parameter :: Component_PROGID = ("CropModelMKS.Fortran.Demonstration")
    character*3,  parameter :: Component_VERSION = ("1.0")
    character*10, parameter :: Component_THREADING_MODEL = ("APARTMENT")

    ! CLSIDs        
    type (guid), parameter :: CLSID_Component = &
        GUID(#e52c829a, #2ca2, #42d8, &
        char('b5'X)//char('f7'X)//char('86'X)//char('22'X)// &
        char('5b'X)//char('cf'X)//char('c4'X)//char('c8'X))
                                                
    ! IIDs      
    ! Per Interface
    type (guid), parameter :: IID_IComponent = &
        GUID(#a784e5c9, #0a9d, #4a6e, &
        char('83'X)//char('e0'X)//char('2c'X)//char('6e'X)// &
        char('c7'X)//char('6e'X)//char('ed'X)//char('38'X))

    !  This is the per-instance data of the class
    ! Per Interface
    type IComponent_Ptr
        sequence
        type (IComponent_Vtbl), pointer :: pVtbl
        type (Component_InternalData), pointer :: pInternalData
    end type IComponent_Ptr

    type Component_InternalData
        sequence
        type (Component_InstanceData), pointer :: pInstanceData
        type (Component_Data), pointer :: pStart
        integer(SIZE_T) refCount
    end type Component_InternalData

    type Component_Data
        sequence
    ! Per Interface
        type (IComponent_ptr) IComponent_InternalData
        type (Component_InternalData) InternalData
    end type Component_Data

    ! Per Interface
    !  All methods must return integer(LONG) (an HRESULT)
    !  All methods must take as their first argument, the instance
    !  data type by reference
    type IComponent_Vtbl
        sequence
        ! IUnknown Methods
        integer(INT_PTR_KIND()) QueryInterface
        integer(INT_PTR_KIND()) AddRef
        integer(INT_PTR_KIND()) Release
        ! IDispatch Methods
        integer(INT_PTR_KIND()) GetTypeInfoCount
        integer(INT_PTR_KIND()) GetTypeInfo
        integer(INT_PTR_KIND()) GetIDsOfNames
        integer(INT_PTR_KIND()) Invoke
        !  IComponent Methods
        integer(INT_PTR_KIND()) Update
        integer(INT_PTR_KIND()) Initialize
        integer(INT_PTR_KIND()) Inquire
        integer(INT_PTR_KIND()) Description
        integer(INT_PTR_KIND()) Convert
    end type IComponent_Vtbl

  contains

    !  IUnknown implementation for all interfaces of the class

    function Component_QueryInterface (pData, riid, ppv) result (r)
        !dec$ attributes stdcall :: Component_QueryInterface
        use ifwinty
        use ifcom
        implicit none

        type (IComponent_Ptr) pData
        !dec$ attributes reference :: pData
        type(guid), intent(in) :: riid
        !dec$ attributes reference :: riid
        integer(int_ptr_kind()), intent(out) :: ppv
        !dec$ attributes reference :: ppv
        integer(long) r

        r = S_OK
        ppv = NULL

        !  Ensure that they are requesting a supported interface
        !  NOTE:  All requests for IUnknown MUST return the same pointer (per COM)
        if (COMIsEqualGUID(riid, IID_IUnknown)) then
            ppv = loc(pData % pInternalData % pStart % IComponent_InternalData)
        !  Per interface
        else if (COMIsEqualGUID(riid, IID_IComponent)) then
            ppv = loc(pData % pInternalData % pStart % IComponent_InternalData)
        else if (COMIsEqualGUID(riid, IID_IDispatch)) then
            ppv = loc(pData % pInternalData % pStart % IComponent_InternalData)
        end if

        if (ppv == NULL) then
            r = E_UNEXPECTED 
            return
        end if

        pData % pInternalData % refCount = &
            pData % pInternalData % refCount + 1

    end function 

    function Component_AddRef (pData) result (r)
        !dec$ attributes stdcall :: Component_AddRef
        use ifwinty
        implicit none

        type (IComponent_Ptr) pData
        !dec$ attributes reference :: pData
        integer r

        pData % pInternalData % refCount = &
            pData % pInternalData % refCount + 1
        r = pData % pInternalData % refCount

    end function 

    function Component_Release (pData) result (r)
        !dec$ attributes stdcall :: Component_Release
        use ifwinty
        use CropModelMKS_Fortran_Demonstration_global
        implicit none

        type (IComponent_Ptr) pData
        !dec$ attributes reference :: pData
        integer r

        type (Component_Data),  pointer :: pComponentData
        integer status

        pData % pInternalData % refCount = &
            pData % pInternalData % refCount - 1
        r = pData % pInternalData % refCount
        if (pData % pInternalData % refCount == 0) then
            !  Time to delete ourself....
            pComponentData => pData % pInternalData % pStart
            !  Call the "destructor"
            call Component_DESTRUCTOR(pComponentData % InternalData % pInstanceData)
            !  Per interface
            deallocate (pComponentData % IComponent_InternalData % pVtbl)
            deallocate (pComponentData % InternalData % pInstanceData)
            deallocate (pComponentData)
            status = ServerUnlock()
        end if

    end function 


    !  IDispatch implementation for IComponent

    function Component_GetTypeInfoCount(pData, pctinfo) result (hresult)
        !dec$ attributes stdcall :: Component_GetTypeInfoCount
        implicit none
        type (IComponent_Ptr) pData
        !dec$ attributes reference :: pData
        integer(long), intent(out) :: pctinfo
        !dec$ attributes reference :: pctinfo
        integer(long) hresult

        hresult = S_OK
        pctinfo = 1

    end function

    function Component_GetTypeInfo(pData, iTInfo, lcid, ppTInfo) result (hresult)
        !dec$ attributes stdcall :: Component_GetTypeInfo
        use ifwinty
        use CropModelMKS_Fortran_Demonstration_global
        use kernel32
        use oleaut32
        use ifcom
        implicit none
        type (IComponent_Ptr) pData
        !dec$ attributes reference :: pData
        integer, intent(in) :: iTInfo
        !dec$ attributes value :: iTInfo
        integer, intent(in) :: lcid
        !dec$ attributes value :: lcid
        integer(int_ptr_kind()), intent(out) :: ppTInfo
        !dec$ attributes reference :: ppTInfo
        integer(long) hresult

        interface
            function GetTypeInfoOfGuid(pITypeLib, rguid, ppTInfo) result (hresult)
                !dec$ attributes default :: GetTypeInfoOfGuid
                !dec$if defined(_X86_)
                !dec$ attributes stdcall, alias:'_GetTypeInfoOfGuid@8' :: GetTypeInfoOfGuid
                !dec$ else
                !dec$ attributes stdcall, alias:'GetTypeInfoOfGuid' :: GetTypeInfoOfGuid
                !dec$ endif
                use ifwinty
                integer(int_ptr_kind()) pITypeLib
                !dec$ attributes value :: pITypeLib
                TYPE (guid), intent(in) :: rguid 
                !dec$ attributes reference :: rguid
                integer(int_ptr_kind()), intent(out) :: ppTInfo
                !dec$ attributes reference :: ppTInfo
                integer(long) hresult
            end function
        end interface
        POINTER(GetTypeInfoOfGuid_PTR, GetTypeInfoOfGuid)	! routine pointer

        integer(int_ptr_kind()) pITypeLib    ! ITypeLib*
        integer(int_ptr_kind()) $VTBL		 ! ITypeLib Function Table
        pointer($VPTR, $VTBL)
        integer res

        hresult = S_OK
        if (iTInfo /= 0) then
            hresult = TYPE_E_ELEMENTNOTFOUND
            return
        end if
        ppTInfo = gComponentITypeInfo
        
        !  Get the type information if we don't already have it
        !  NOTE:  This code will always return the ITypeInfo of the
        !         first LCID that is found
        if (gComponentITypeInfo == NULL) then
            call EnterCriticalSection(loc(gGlobalCriticalSection))
            if (gComponentITypeInfo == NULL) then
                hresult = LoadRegTypeLib(GUID_TypeLib_CropModelMKS_Fortran_Demonstration, 1, 0, lcid, pITypeLib)
                if (hresult < 0) then
                    call LeaveCriticalSection(loc(gGlobalCriticalSection))
                    return
                end if
                $VPTR = pITypeLib
                $VPTR = $VTBL + (6 * INT_PTR_KIND()) ! Add GetTypeInfoOfGuid routine offset
                GetTypeInfoOfGuid_PTR = $VTBL
                hresult = GetTypeInfoOfGuid(pITypeLib, IID_IComponent, gComponentITypeInfo)
                res = COMReleaseObject(pITypelib)
                if (hresult < 0) then
                    call LeaveCriticalSection(loc(gGlobalCriticalSection))
                    return
                end if
            end if
            call LeaveCriticalSection(loc(gGlobalCriticalSection))
            ppTInfo = gComponentITypeInfo
        end if
        res = COMAddObjectReference(gComponentITypeInfo)

    end function

    function Component_GetIDsOfNames(pData, riid, rgszNames, cNames, lcid, rgDispID) result (hresult)
        !dec$ attributes stdcall :: Component_GetIDsOfNames
        use ifwinty
        use CropModelMKS_Fortran_Demonstration_global
        use ifcom
        implicit none
        type (IComponent_Ptr) pData
        !dec$ attributes reference :: pData
        type (guid), intent(in)    :: riid 
        !dec$ attributes reference :: riid
        integer(int_ptr_kind()), intent(in) :: rgszNames
        !dec$ attributes value :: rgszNames
        integer, intent(in) :: cNames
        !dec$ attributes value :: cNames
        integer, intent(in) :: lcid
        !dec$ attributes value :: lcid
        integer(long), dimension(:), intent(out) :: rgDispID
        !dec$ attributes reference :: rgDispID
        integer(long) hresult

        interface
            function DispGetIDsOfNames(pITypeInfo, rgszNames, cNames, rgDispID) result (hresult)
                !dec$ attributes default :: DispGetIDsOfNames
                !dec$if defined(_X86_)
                !dec$ attributes stdcall, alias:'_DispGetIDsOfNames@16' :: DispGetIDsOfNames
                !dec$ else
                !dec$ attributes stdcall, alias:'DispGetIDsOfNames' :: DispGetIDsOfNames
                !dec$ endif
                use ifwinty
                integer(int_ptr_kind()) pITypeInfo
                !dec$ attributes value :: pITypeInfo
                integer(int_ptr_kind()), intent(in) :: rgszNames
                !dec$ attributes value :: rgszNames
                integer, intent(in) :: cNames
                !dec$ attributes value :: cNames
                integer(long), dimension(:), intent(out) :: rgDispID
                !dec$ attributes reference :: rgDispID
                integer(long) hresult
            end function
        end interface

        type (guid), parameter :: IID_NULL = &
              guid(#00000000, #0000, #0000, &
                char('00'X)//char('00'X)//char('00'X)//char('00'X)// &
                char('00'X)//char('00'X)//char('00'X)//char('00'X))
        integer(int_ptr_kind()) pTInfo 
        integer res

        hresult = S_OK

        !  The riid argument must be IID_NULL
        if (.not. COMIsEqualGUID(riid, IID_NULL)) then
            hresult = DISP_E_UNKNOWNINTERFACE
            return
        end if

        !  Get the ITypeInfo pointer
        hresult = Component_GetTypeInfo(pData, 0, lcid, pTInfo)
        if (hresult < 0) return

        !  Call DispGetIDsOfNames
        hresult = DispGetIDsOfNames(pTInfo, rgszNames, cNames, rgDispID)
        res = COMReleaseObject(pTInfo)

    end function

    function Component_Invoke(pData, dispidMember, riid, lcid, &
        wFlags, pparams, pvarResult, pexcepinfo, puArgErr) result (hresult)
        !dec$ attributes stdcall :: Component_Invoke
        use ifwinty
        use CropModelMKS_Fortran_Demonstration_global
        use ifcom
        implicit none
        type (IComponent_Ptr) pData
        !dec$ attributes reference :: pData
        integer(long), intent(in) :: dispidMember
        !dec$ attributes value :: dispidMember
        type (guid), intent(in)    :: riid 
        !dec$ attributes reference :: riid
        integer, intent(in) :: lcid
        !dec$ attributes value :: lcid
        integer(2), intent(in) :: wFlags
        !dec$ attributes value :: wFlags
        type(T_DISPPARAMS), intent(inout) :: pparams
        !dec$ attributes reference :: pparams
        type(VARIANT), intent(out) :: pvarResult
        !dec$ attributes reference :: pvarResult
        type(T_EXCEPINFO), intent(out) :: pexcepinfo
        !dec$ attributes reference :: pexcepinfo
        integer, intent(out) :: puArgErr
        !dec$ attributes reference :: puArgErr
        integer(long) hresult

        interface
            function DispInvoke(pInterface, pTInfo, dispidMember, &
                wFlags, pparams, pvarResult, pexcepinfo, puArgErr) result (hresult)
                !dec$ attributes default :: DispInvoke
                !dec$if defined(_X86_)
                !dec$ attributes stdcall, alias:'_DispInvoke@32' :: DispInvoke
                !dec$ else
                !dec$ attributes stdcall, alias:'DispInvoke' :: DispInvoke
                !dec$ endif
                use ifwinty
                integer(int_ptr_kind()) pInterface
                !dec$ attributes value :: pInterface
                integer(int_ptr_kind()) pTInfo
                !dec$ attributes value :: pTInfo
                integer(long), intent(in) :: dispidMember
                !dec$ attributes value :: dispidMember
                integer(2), intent(in) :: wFlags
                !dec$ attributes value :: wFlags
                type(T_DISPPARAMS), intent(inout) :: pparams
                !dec$ attributes reference :: pparams
                type(VARIANT), intent(out) :: pvarResult
                !dec$ attributes reference :: pvarResult
                type(T_EXCEPINFO), intent(out) :: pexcepinfo
                !dec$ attributes reference :: pexcepinfo
                integer, intent(out) :: puArgErr
                !dec$ attributes reference :: puArgErr
                integer(long) hresult
            end function
        end interface

        type (guid), parameter :: IID_NULL = &
               guid(#00000000, #0000, #0000, &
                 char('00'X)//char('00'X)//char('00'X)//char('00'X)// &
                 char('00'X)//char('00'X)//char('00'X)//char('00'X))
        integer(int_ptr_kind()) pTInfo 
        integer res

        hresult = S_OK

        !  The riid argument must be IID_NULL
        if (.not. COMIsEqualGUID(riid, IID_NULL)) then
            hresult = DISP_E_UNKNOWNINTERFACE
            return
        end if

        !  Get the ITypeInfo pointer
        hresult = Component_GetTypeInfo(pData, 0, lcid, pTInfo)
        if (hresult < 0) return

        !  Call DispInvoke
        hresult = DispInvoke(loc(pdata), pTInfo, dispidMember, &
                wFlags, pparams, pvarResult, pexcepinfo, puArgErr)
        res = COMReleaseObject(pTInfo)

    end function

end module



