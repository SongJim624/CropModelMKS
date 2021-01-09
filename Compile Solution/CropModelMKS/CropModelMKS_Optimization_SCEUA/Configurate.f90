function Configurate(path) result(status)
    use FoX_DOM
    use Core
    implicit none
    
    character(*), intent(in) :: path
    integer status
    
    type(Node), pointer :: myDoc, p
    
    myDoc => parseFile("h2o.xml", iostat=ios, ex=ex)
    if (ios.ne.0) then
        print*, "Problem reading file. iostat was ", ios
        status = -1
        return

    elseif (inException(ex)) then
        print*,"DOM Parse error ", getExceptionCode(ex)
        status = -1
        return
        
    endif

    
    
    
    
    
    
    
    end function  Configurate
    