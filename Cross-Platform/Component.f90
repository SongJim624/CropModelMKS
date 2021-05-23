function Initialize(states, parameters, s) result(index)
    !DES$ ATTRIBUTES DLLEXPORT::Initialize
    implicit none

end function Initialize

function Update(index, states, parameters, s) result(status)
    !DES$ ATTRIBUTES DLLEXPORT::Update
    implicit none
    
end function Update

function Finalize(index) result(status)
    !DES$ ATTRIBUTES DLLEXPORT::Finalize
    implicit none
    
        
end function Finalize

function Inquire_C(name, value, size) result(status)
    !DES$ ATTRIBUTES DLLEXPORT::Inquire
    implicit none
    character(len = *), intent(in), volatile :: name
    real(kind = 4), dimension(:), intent(out), volatile :: value
    integer(kind = 8), intent(out) :: size
    
end function Inquire_C

function Describe(path) result(status)
    !DES$ ATTRIBUTES DLLEXPORT::Describe
    implicit none
    character(len = *), volatile :: path
            
end function Describe

function Convert(xml, file) result(status)
    !DES$ ATTRIBUTES DLLEXPORT::Convert
    implicit none
    character(len = *), volatile :: xml, file
    
end function Convert