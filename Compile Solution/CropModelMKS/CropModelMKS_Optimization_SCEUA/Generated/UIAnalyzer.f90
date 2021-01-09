!
!  UIAnalyzer.f90 - This file contains the implementation of the
!                    IAnalyzer methods
!
! IAnalyzer_Analyze
function IAnalyzer_Analyze( ObjectData ,&
         isimulator) result (hresult)
    use Algorithm
    use Analyzer_Types
    implicit none
    type(Analyzer_InstanceData) ObjectData
    !dec$ attributes reference :: ObjectData
    INTEGER(INT_PTR_KIND()), intent(in) :: isimulator
    integer(long) hresult
    ! <B2> DO NOT REMOVE THIS LINE
    ! TODO:  Add implementation
    integer :: status
    status = Analyze(simulator)
    hresult = S_OK
    ! <E2> DO NOT REMOVE THIS LINE
end function
! IAnalyzer_Configurate
function IAnalyzer_Configurate( ObjectData ,&
         configuration) result (hresult)
    use Algorithm
    use FoX_DOM
    use Analyzer_Types
    implicit none
    type(Analyzer_InstanceData) ObjectData
    !dec$ attributes reference :: ObjectData
    CHARACTER(*), intent(in) :: configuration
    integer(long) hresult
    ! <B3> DO NOT REMOVE THIS LINE
    ! TODO:  Add implementation
    
    integer :: status
    type(Node), pointer :: doc
    
    doc => parseFile(configuration)
    
    status = Configurate(doc)
    
    call destroy(doc)
    
    hresult = S_OK
    ! <E3> DO NOT REMOVE THIS LINE
end function
! IAnalyzer_Description
function IAnalyzer_Description( ObjectData ,&
         path) result (hresult)
    use Algorithm
    use Analyzer_Types
    implicit none
    type(Analyzer_InstanceData) ObjectData
    !dec$ attributes reference :: ObjectData
    CHARACTER(*), intent(in) :: path
    integer(long) hresult
    ! <B5> DO NOT REMOVE THIS LINE
    ! TODO:  Add implementation
    integer :: status, Description
    
    status = Description(path)
    
    hresult = S_OK
    ! <E5> DO NOT REMOVE THIS LINE
end function

