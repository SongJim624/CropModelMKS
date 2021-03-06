!
!  @GLOBAL.SOURCE@ - This file contains the main entry point for the
!  COM Server
!
!  Generated by the Intel(R) Visual Fortran COM Server Wizard on
!  @GLOBAL.DATE@ at @GLOBAL.TIME@.
!
!   DO NOT EDIT THIS FILE!
!
!  This file is re-generated every time the object hierarchy is changed.
!

integer*4 function WinMain( hInstance, hPrevInstance, lpszCmdLine, nCmdShow )
    !dec$ if defined(_X86_)
    !dec$ attributes dllexport, stdcall, alias : '_WinMain@16' :: WinMain
    !dec$ else
    !dec$ attributes dllexport, stdcall, alias : 'WinMain' :: WinMain
    !dec$ end if

    use @GLOBAL.NAME@_global
    use ifcom
    use user32
    use ole32

    implicit none

    integer(HANDLE) hInstance
    integer(HANDLE) hPrevInstance
    integer(LPVOID) lpszCmdLine
    integer(DWORD)  nCmdShow

    interface
        logical function ProcessCommandLine (ret)
            integer*4 ret
        end function
        @#PER CLASS
        function Register@CLASS.NAME@()
            use ifwinty
            integer(DWORD) Register@CLASS.NAME@
        end function
        @#ENDPER
    end interface

    ! Variables
    type (T_MSG)            mesg
    integer*4               ret
    logical*4               lret
    logical                 lrun

    ! Per Class
    @#PER CLASS
    integer(DWORD)          @CLASS.NAME@_Reg
    @#ENDPER

    ! Initialize global variables
    ghinst =  hInstance
    call InitializeCriticalSection(loc(gGlobalCriticalSection))
    ! Per Class
    @#PER CLASS
    g@CLASS.NAME@IClassFactory = NULL
    g@CLASS.NAME@ITypeInfo = NULL
    @#ENDPER

    ! Initialize COM
    call COMInitialize(ret)
    if (ret < 0) then
        ret = MessageBox(0, "Error initializing COM"C, &
                         "Error"C, MB_OK)
        WinMain = 0
        return
    end if
                           
    ! Check the command line for the /Register and /Unregister switches
    lrun = ProcessCommandLine(ret)
    if (ret < 0) then
        ret = MessageBox(0, "Error registering or unregistering server"C, &
                         "Error"C, MB_OK)
        WinMain = 0
        return
    end if

    ! If /Register or /Unregister were found, don't start the server
    if (lrun) then
        @#PER CLASS
        @CLASS.NAME@_Reg = Register@CLASS.NAME@()
        @#ENDPER
        ret = CoResumeClassObjects()

        ! Read and process messsages
        do while( GetMessage (mesg, NULL, 0, 0) ) 
           ret = DispatchMessage( mesg )
        end do
        WinMain = mesg.wParam

        ! Revoke the server's classes
        ! Per Class
        @#PER CLASS
        ret = CoRevokeClassObject(@CLASS.NAME@_Reg)
        @#ENDPER
    else
        WinMain = ret
    end if

    ! Cleanup
    @#PER CLASS
    if (g@CLASS.NAME@IClassFactory /= NULL) then
        ret = COMReleaseObject(g@CLASS.NAME@IClassFactory)    
    end if
    if (g@CLASS.NAME@ITypeInfo /= NULL) then
        ret = COMReleaseObject(g@CLASS.NAME@ITypeInfo)    
    end if
    @#ENDPER
    call COMUnInitialize()
    call DeleteCriticalSection(loc(gGlobalCriticalSection))

end 

logical function ProcessCommandLine (ret)
    use ServerHelper
    use ifwinty
    use user32

    implicit none

    integer*4               ret

    integer                 status
    integer                 argc
    integer                 argi
    integer(DWORD)          nchars
    character*(MAX_PATH)    p

    ret = S_OK

    ! Check the command line for the /Register and /Unregister switches
    argc = nargs()           ! First arg is command name
    if (argc > 1) then
        argi = 1
        do while (argi < argc)
            call getarg(argi, p, nchars)
            argi = argi + 1
            if (nchars > 0) then
                if (p(1:1) == '/' .or. p(1:1) == '-') then
                    status = CharUpperBuff ( p, nchars )
                    if (p(2:10) == "REGSERVER") then
                        ret = RegisterServer()
                        ProcessCommandLine = .FALSE.    !Don't run server
                        return
                    end if 
                    if (p(2:12) == "UNREGSERVER") then
                        ret = UnregisterServer()
                        ProcessCommandLine = .FALSE.    !Don't run server
                        return
                    end if 
                end if
            end if
        end do
    end if

    ProcessCommandLine = .TRUE.
end function

@#PER CLASS
function Register@CLASS.NAME@()
    use @GLOBAL.NAME@_global
    use @CLASS.NAME@_Types
    use IClassFactory_Types
    use IClassFactory_Methods
    use ifwinty
    use ifcom
    use ole32, only: CoRegisterClassObject

    implicit none

    integer(dword)          Register@CLASS.NAME@
    integer(dword)          dwFlags
    integer(dword)          dwReg
    integer(int_ptr_kind()) ppv
    integer(long)           status

    !  Create the class factory
    !  Allocate an instance data structure and a Vtbl
    allocate (gp@CLASS.NAME@CFData)
    allocate (gp@CLASS.NAME@CFData % pVtbl)
    gp@CLASS.NAME@CFData % refCount = 1
    !  The Vtbl implementations are in ClsFact.f90
    gp@CLASS.NAME@CFData % pVtbl % QueryInterface = &
            loc(IClassFactory_QueryInterface)
    gp@CLASS.NAME@CFData % pVtbl % AddRef = &
            loc(IClassFactory_AddRef)
    gp@CLASS.NAME@CFData % pVtbl % Release = &
            loc(IClassFactory_Release)
    gp@CLASS.NAME@CFData % pVtbl % CreateInstance = &
            loc(IClassFactory_Create@CLASS.NAME@Instance)
    gp@CLASS.NAME@CFData % pVtbl % LockServer = &
            loc(IClassFactory_LockServer)
    g@CLASS.NAME@IClassFactory  = loc(gp@CLASS.NAME@CFData)
    ppv = loc(gp@CLASS.NAME@CFData)
    status = COMAddObjectReference (ppv) 

    ! Register the class
    dwFlags = REGCLS_MULTIPLEUSE .or. REGCLS_SUSPENDED
    dwReg = 0
    status = CoRegisterClassObject(CLSID_@CLASS.NAME@, ppv, CLSCTX_LOCAL_SERVER, dwFlags, dwReg)
    Register@CLASS.NAME@ = dwReg
end function
@#ENDPER
