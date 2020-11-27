!
!  UIAnalyzer.f90 - This file contains the implementation of the
!                    IAnalyzer methods
!
! IAnalyzer_Analyze
function IAnalyzer_Analyze( ObjectData ,&
         simulator) result (hresult)
    use Analyzer_Types
    implicit real*8 (a-h,o-z)

    type(Analyzer_InstanceData) ObjectData
    !dec$ attributes reference :: ObjectData
    INTEGER(INT_PTR_KIND()), intent(in) :: simulator
    integer(long) hresult
    ! <B2> DO NOT REMOVE THIS LINE
    ! TODO:  Add implementation
    
    dimension :: a(16), bl(16), bu(16), jseed(10)
    data jseed/2,3,5,7,11,13,17,19,23,29/

    write (*,*) ' ENTER THE MAIN PROGRAM --- '

    if (iseed .gt. 0) then
        nrun = min(iseed,10)
    else
        nrun = 1
    end if
      
    do i=1,nrun
        if (nrun .ne. 1) iseed = jseed(i)
        write (*,*) '@ SCE-UA Run Number',i,' Random Seed Value',iseed
        call sceua(a,bl,bu,nopt,maxn,kstop,pcento,iseed,ngs,npg,nps,nspl,mings,iniflg,iprint)
    end do
    
    hresult = S_OK
    ! <E2> DO NOT REMOVE THIS LINE
end function
! IAnalyzer_Configurate
function IAnalyzer_Configurate( ObjectData ,&
         configuration) result (hresult)
    use Analyzer_Types
    implicit none
    type(Analyzer_InstanceData) ObjectData
    !dec$ attributes reference :: ObjectData
    CHARACTER(*), intent(in) :: configuration
    integer(long) hresult
    ! <B3> DO NOT REMOVE THIS LINE
    ! TODO:  Add implementation
    hresult = S_OK
    ! <E3> DO NOT REMOVE THIS LINE
end function
! IAnalyzer_Inquire
function IAnalyzer_Inquire( ObjectData ,&
         name,&
         value) result (hresult)
    use Analyzer_Types
    implicit none
    type(Analyzer_InstanceData) ObjectData
    !dec$ attributes reference :: ObjectData
    CHARACTER(*), intent(in) :: name
    TYPE(VARIANT), intent(out) :: value
    integer(long) hresult
    ! <B4> DO NOT REMOVE THIS LINE
    ! TODO:  Add implementation
    hresult = S_OK
    ! <E4> DO NOT REMOVE THIS LINE
end function
! IAnalyzer_Description
function IAnalyzer_Description( ObjectData ,&
         path) result (hresult)
    use Analyzer_Types
    implicit none
    type(Analyzer_InstanceData) ObjectData
    !dec$ attributes reference :: ObjectData
    CHARACTER(*), intent(in) :: path
    integer(long) hresult
    ! <B5> DO NOT REMOVE THIS LINE
    ! TODO:  Add implementation
    
    
    
    
    
    hresult = S_OK
    ! <E5> DO NOT REMOVE THIS LINE
end function
! IAnalyzer_Convert
function IAnalyzer_Convert( ObjectData ,&
         file_path,&
         xml_path) result (hresult)
    use Analyzer_Types
    implicit none
    type(Analyzer_InstanceData) ObjectData
    !dec$ attributes reference :: ObjectData
    CHARACTER(*), intent(in) :: file_path
    CHARACTER(*), intent(in) :: xml_path
    integer(long) hresult
    ! <B6> DO NOT REMOVE THIS LINE
    ! TODO:  Add implementation
    
    
    
    
    
    
    hresult = S_OK
    ! <E6> DO NOT REMOVE THIS LINE
end function

