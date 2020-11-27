!
!  @GLOBAL.SOURCE@ - This module contains user-defined class 
!  definitions and methods
!

module @INSTANCETYPE.USE@

    type @INSTANCETYPE.NAME@
        sequence
        ! <B@INSTANCETYPE.MAGIC@DEF> DO NOT REMOVE THIS LINE
        !  TODO:  Add fields and remove "dummy"
        integer dummy
        ! <E@INSTANCETYPE.MAGIC@DEF> DO NOT REMOVE THIS LINE
    end type

  contains

    !
    !  Constructor
    !
    function @INSTANCETYPE.CONSTRUCTOR@( ObjectData ) result (hresult)
        use ifwinty
        implicit none
        type(@INSTANCETYPE.NAME@) ObjectData
        !dec$ attributes reference :: ObjectData
        integer(LONG) hresult

        hresult = S_OK
        ! <B@INSTANCETYPE.MAGIC@CON> DO NOT REMOVE THIS LINE
        !  TODO:  Add field initialization code
        ! <E@INSTANCETYPE.MAGIC@CON> DO NOT REMOVE THIS LINE
    end function

    !
    !  Destructor
    !
    subroutine @INSTANCETYPE.DESTRUCTOR@( ObjectData )
        implicit none
        type(@INSTANCETYPE.NAME@) ObjectData
        !dec$ attributes reference :: ObjectData
        ! <B@INSTANCETYPE.MAGIC@DES> DO NOT REMOVE THIS LINE
        !  TODO:  Add field cleanup code
        ! <E@INSTANCETYPE.MAGIC@DES> DO NOT REMOVE THIS LINE
    end subroutine

end module

@($INSTANCENAME = CopyStr(INSTANCETYPE.NAME)@)
@#PER INTERFACE
@#template "userim.f90|U@INTERFACE.NAME@.f90|U@INTERFACE.NAME@.f90.+"
@#ENDPER
