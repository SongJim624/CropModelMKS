!
!  IAnalyzer.f90 - This module contains the interfaces of methods 
!  of the IAnalyzer interface
!
!  Generated by the Intel(R) Visual Fortran COM Server Wizard on
!  12/17/20 at 11:05:56.
!
!   DO NOT EDIT THIS FILE!
!
!  This file is re-generated every time the object hierarchy is changed.
!

module IAnalyzer_Methods

    !  These routines get implemented by the user
    interface 
        function IAnalyzer_Analyze( ObjectData ,&
                 isimulator) result (hresult)
            use Analyzer_Types
            type(Analyzer_InstanceData) ObjectData
            !dec$ attributes reference :: ObjectData
            INTEGER(INT_PTR_KIND()), intent(in) :: isimulator
            integer(long) hresult
        end function
        function IAnalyzer_Configurate( ObjectData ,&
                 configuration) result (hresult)
            use Analyzer_Types
            type(Analyzer_InstanceData) ObjectData
            !dec$ attributes reference :: ObjectData
            CHARACTER(*), intent(in) :: configuration
            integer(long) hresult
        end function
        function IAnalyzer_Description( ObjectData ,&
                 path) result (hresult)
            use Analyzer_Types
            type(Analyzer_InstanceData) ObjectData
            !dec$ attributes reference :: ObjectData
            CHARACTER(*), intent(in) :: path
            integer(long) hresult
        end function

    end interface

   !  Local definition of SysStringByteLen
    interface
        pure integer*4 function SysStringByteLen_Local(bstr);
            !dec$ attributes default, stdcall, decorate, alias : 'SysStringByteLen' :: SysStringByteLen_Local
            use ifwinty
            integer(int_ptr_kind()), intent(in) :: bstr
            !dec$ attributes value              :: bstr
        end function SysStringByteLen_Local
    end interface


  contains

    !  Wrapper functions called from the Vtbl

    function $IAnalyzer_Analyze( pInterface ,&
             isimulator ) result (hresult)
        !dec$ attributes stdcall :: $IAnalyzer_Analyze
        use Analyzer_Types
        use ifcom
        implicit none
        type (IAnalyzer_Ptr) pInterface
        !dec$ attributes reference :: pInterface
        INTEGER(INT_PTR_KIND()), intent(in) :: isimulator 
        !dec$ attributes value :: isimulator 
        integer(long) hresult
        integer i
		

        hresult = IAnalyzer_Analyze(pInterface % pInternalData % pInstanceData ,&
             isimulator )
        
        if (hresult < 0) goto 9999
    9999  continue  ! Cleanup code
    end function
    function $IAnalyzer_Configurate( pInterface ,&
             configuration ) result (hresult)
        !dec$ attributes stdcall :: $IAnalyzer_Configurate
        use Analyzer_Types
        use ifcom
        implicit none
        type (IAnalyzer_Ptr) pInterface
        !dec$ attributes reference :: pInterface
        integer(INT_PTR_KIND()), intent(in) :: configuration 
        !dec$ attributes value :: configuration 
        integer(long) hresult
        integer i
        character(len=SysStringByteLen_Local(configuration)) f$configuration 
        
        i = ConvertBSTRToString(configuration, f$configuration) 
		

        hresult = IAnalyzer_Configurate(pInterface % pInternalData % pInstanceData ,&
             f$configuration )
        
        if (hresult < 0) goto 9999
    9999  continue  ! Cleanup code
    end function
    function $IAnalyzer_Description( pInterface ,&
             path ) result (hresult)
        !dec$ attributes stdcall :: $IAnalyzer_Description
        use Analyzer_Types
        use ifcom
        implicit none
        type (IAnalyzer_Ptr) pInterface
        !dec$ attributes reference :: pInterface
        integer(INT_PTR_KIND()), intent(in) :: path 
        !dec$ attributes value :: path 
        integer(long) hresult
        integer i
        character(len=SysStringByteLen_Local(path)) f$path 
        
        i = ConvertBSTRToString(path, f$path) 
		

        hresult = IAnalyzer_Description(pInterface % pInternalData % pInstanceData ,&
             f$path )
        
        if (hresult < 0) goto 9999
    9999  continue  ! Cleanup code
    end function
end module

