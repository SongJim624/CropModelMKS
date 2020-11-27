!
!  UAnalyzerTY.f90 - This module contains user-defined class 
!  definitions and methods
!

module Analyzer_USE

    type Analyzer_InstanceData
        sequence
        ! <B1DEF> DO NOT REMOVE THIS LINE
        !  TODO:  Add fields and remove "dummy"
        integer dummy
        ! <E1DEF> DO NOT REMOVE THIS LINE
    end type

  contains

    !
    !  Constructor
    !
    function Analyzer_CONSTRUCTOR( ObjectData ) result (hresult)
        use ifwinty
        implicit none
        type(Analyzer_InstanceData) ObjectData
        !dec$ attributes reference :: ObjectData
        integer(LONG) hresult

        hresult = S_OK
        ! <B1CON> DO NOT REMOVE THIS LINE
        !  TODO:  Add field initialization code
        ! <E1CON> DO NOT REMOVE THIS LINE
    end function

    !
    !  Destructor
    !
    subroutine Analyzer_DESTRUCTOR( ObjectData )
        implicit none
        type(Analyzer_InstanceData) ObjectData
        !dec$ attributes reference :: ObjectData
        ! <B1DES> DO NOT REMOVE THIS LINE
        !  TODO:  Add field cleanup code
        ! <E1DES> DO NOT REMOVE THIS LINE
    end subroutine

end module




