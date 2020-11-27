!
!  UIComponent.f90 - This file contains the implementation of the
!                    IComponent methods
!
! IComponent_Update
function IComponent_Update( ObjectData ,&
         states) result (hresult)
    use Component_Types
    use Converter
    
    implicit none
    type(Component_InstanceData) ObjectData
    !dec$ attributes reference :: ObjectData
    INTEGER(INT_PTR_KIND()), intent(in) :: states
    integer(long) hresult
    ! <B2> DO NOT REMOVE THIS LINE
    ! TODO:  Add implementation
    real(kind = 4) :: CC, LAI, BM, RD, Y
    integer :: status
    
    CC = 0.0
    LAI = 0.0
    BM = 0.0
    RD = 0.0
    Y = 0.0
    
    status = cWrite("canopy cover", Wrap(CC), states)
    status = cWrite("leaf area index", Wrap(LAI), states)
    status = cWrite("root depth", Wrap(RD), states)
    status = cWrite("biomass", Wrap(BM), states)
    status = cWrite("yield", Wrap(Y), states)
    
    hresult = S_OK
    ! <E2> DO NOT REMOVE THIS LINE
end function
! IComponent_Initialize
function IComponent_Initialize( ObjectData ,&
         states,&
         parameters) result (hresult)
    use Component_Types
    use Converter
    
    implicit none
    type(Component_InstanceData) ObjectData
    !dec$ attributes reference :: ObjectData
    INTEGER(INT_PTR_KIND()), intent(in) :: states
    INTEGER(INT_PTR_KIND()), intent(in) :: parameters
    integer(long) hresult
    ! <B3> DO NOT REMOVE THIS LINE
    ! TODO:  Add implementation
    real(kind = 4) :: CC, LAI, BM, RD, Y
    integer :: status
    
    status = cInquire("canopy cover", states, CC)
    if(status .NE. 0) then
        CC = 0.0
        status = cWrite("canopy cover", Wrap(CC), states)
    end if 
    
    status = cInquire("leaf area index", states, LAI)
    if(status .NE. 0) then
        LAI = 0.0
        status = cWrite("leaf area index", Wrap(LAI), states)
    end if
    
    status = cInquire("biomass", states, BM)
    if(status .NE. 0) then
        BM = 0.0
        status = cWrite("biomass", Wrap(BM), states)
    end if
    
    status = cInquire("root depth", states, RD)
    if(status .NE. 0) then
        RD = 0.0
        status = cWrite("root depth", Wrap(RD), states)
    end if
    
    status = cInquire("yield", states, Y)
    if(status .NE. 0) then
        Y = 0.0
        status = cWrite("yield", Wrap(Y), states)
    end if
    
    hresult = S_OK
    ! <E3> DO NOT REMOVE THIS LINE
end function
! IComponent_Inquire
function IComponent_Inquire( ObjectData ,&
         name,&
         states) result (hresult)
    use Component_Types
    use Converter
    
    implicit none
    type(Component_InstanceData) ObjectData
    !dec$ attributes reference :: ObjectData
    CHARACTER(*), intent(in) :: name
    INTEGER(INT_PTR_KIND()), intent(in) :: states
    integer(long) hresult
    ! <B4> DO NOT REMOVE THIS LINE
    ! TODO:  Add implementati
    integer :: hash, status, i
    real(kind = 4) :: trx;
    real(kind = 4), dimension(:), allocatable :: sink, compart 
    
    hash = BKDRHash(name)
    
    if(hash .EQ. BKDRHash("water sink ablility")) then
        status = cInquire("soil compartments", states, compart)
        if(status .NE. 0) then
            hresult = S_FALSE
            return
        else
            allocate(sink(size(compart)))
            do i = 1, size(compart)
                sink(i) = 0.0
            end do
            status = Receive(Wrap(sink), states)
            
            deallocate(sink, compart)
            hresult = S_OK;
            return 
        end if 
    else if (hash .EQ. BKDRHash("transpiraiton ability")) then
        trx = 0.0
        status = Receive(Wrap(trx), states)
        hresult = S_OK
        return
    end if 

    hresult = S_OK
    ! <E4> DO NOT REMOVE THIS LINE
end function
! IComponent_Description
function IComponent_Description( ObjectData ,&
         path) result (hresult)
    use Component_Types
    implicit none
    type(Component_InstanceData) ObjectData
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
! IComponent_Convert
function IComponent_Convert( ObjectData ,&
         file_path,&
         xml_path) result (hresult)
    use Component_Types
    implicit none
    type(Component_InstanceData) ObjectData
    !dec$ attributes reference :: ObjectData
    CHARACTER(*), intent(in) :: file_path
    CHARACTER(*), intent(in) :: xml_path
    integer(long) hresult
    ! <B6> DO NOT REMOVE THIS LINE
    ! TODO:  Add implementation
    integer :: status, Convert
    
    status = Convert(file_path, xml_path)
    
    hresult = S_OK
    ! <E6> DO NOT REMOVE THIS LINE
end function

