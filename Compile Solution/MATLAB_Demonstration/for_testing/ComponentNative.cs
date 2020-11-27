/*
* MATLAB Compiler: 8.0 (R2020a)
* Date: Fri Nov 20 18:46:16 2020
* Arguments:
* "-B""macro_default""-W""dotnet:CropModelMKS.MATLAB.Demonstraion,Component,4.0,private,ve
* rsion=1.0""-T""link:lib""-d""C:\Users\Song Jim\Desktop\CropModelMKS\Compile
* Solution\MATLAB_Demonstration\for_testing""-v""class{Component:C:\Users\Song
* Jim\Desktop\CropModelMKS\Sources\Components\CropModelMKS.MATLAB.Demonstration\Convert.m,
* C:\Users\Song
* Jim\Desktop\CropModelMKS\Sources\Components\CropModelMKS.MATLAB.Demonstration\Descriptio
* n.m,C:\Users\Song
* Jim\Desktop\CropModelMKS\Sources\Components\CropModelMKS.MATLAB.Demonstration\Initialize
* .m,C:\Users\Song
* Jim\Desktop\CropModelMKS\Sources\Components\CropModelMKS.MATLAB.Demonstration\Inquire.m,
* C:\Users\Song
* Jim\Desktop\CropModelMKS\Sources\Components\CropModelMKS.MATLAB.Demonstration\Update.m}"
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace CropModelMKS.MATLAB.DemonstraionNative
{

  /// <summary>
  /// The Component class provides a CLS compliant, Object (native) interface to the
  /// MATLAB functions contained in the files:
  /// <newpara></newpara>
  /// C:\Users\Song
  /// Jim\Desktop\CropModelMKS\Sources\Components\CropModelMKS.MATLAB.Demonstration\Conver
  /// t.m
  /// <newpara></newpara>
  /// C:\Users\Song
  /// Jim\Desktop\CropModelMKS\Sources\Components\CropModelMKS.MATLAB.Demonstration\Descri
  /// ption.m
  /// <newpara></newpara>
  /// C:\Users\Song
  /// Jim\Desktop\CropModelMKS\Sources\Components\CropModelMKS.MATLAB.Demonstration\Initia
  /// lize.m
  /// <newpara></newpara>
  /// C:\Users\Song
  /// Jim\Desktop\CropModelMKS\Sources\Components\CropModelMKS.MATLAB.Demonstration\Inquir
  /// e.m
  /// <newpara></newpara>
  /// C:\Users\Song
  /// Jim\Desktop\CropModelMKS\Sources\Components\CropModelMKS.MATLAB.Demonstration\Update
  /// .m
  /// </summary>
  /// <remarks>
  /// @Version 1.0
  /// </remarks>
  public class Component : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Runtime instance.
    /// </summary>
    static Component()
    {
      if (MWMCR.MCRAppInitialized)
      {
        try
        {
          Assembly assembly= Assembly.GetExecutingAssembly();

          string ctfFilePath= assembly.Location;

		  int lastDelimiter = ctfFilePath.LastIndexOf(@"/");

	      if (lastDelimiter == -1)
		  {
		    lastDelimiter = ctfFilePath.LastIndexOf(@"\");
		  }

          ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

          string ctfFileName = "Demonstraion.ctf";

          Stream embeddedCtfStream = null;

          String[] resourceStrings = assembly.GetManifestResourceNames();

          foreach (String name in resourceStrings)
          {
            if (name.Contains(ctfFileName))
            {
              embeddedCtfStream = assembly.GetManifestResourceStream(name);
              break;
            }
          }
          mcr= new MWMCR("",
                         ctfFilePath, embeddedCtfStream, true);
        }
        catch(Exception ex)
        {
          ex_ = new Exception("MWArray assembly failed to be initialized", ex);
        }
      }
      else
      {
        ex_ = new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the Component class.
    /// </summary>
    public Component()
    {
      if(ex_ != null)
      {
        throw ex_;
      }
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~Component()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a void output, 0-input Objectinterface to the Convert MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// CONVERT 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    ///
    public void Convert()
    {
      mcr.EvaluateFunction(0, "Convert", new Object[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input Objectinterface to the Convert MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// CONVERT 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="file_path">Input argument #1</param>
    ///
    public void Convert(Object file_path)
    {
      mcr.EvaluateFunction(0, "Convert", file_path);
    }


    /// <summary>
    /// Provides a void output, 2-input Objectinterface to the Convert MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// CONVERT 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="file_path">Input argument #1</param>
    /// <param name="xml_path">Input argument #2</param>
    ///
    public void Convert(Object file_path, Object xml_path)
    {
      mcr.EvaluateFunction(0, "Convert", file_path, xml_path);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the Convert MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// CONVERT 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Convert(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "Convert", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the Convert MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// CONVERT 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="file_path">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Convert(int numArgsOut, Object file_path)
    {
      return mcr.EvaluateFunction(numArgsOut, "Convert", file_path);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the Convert MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// CONVERT 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="file_path">Input argument #1</param>
    /// <param name="xml_path">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Convert(int numArgsOut, Object file_path, Object xml_path)
    {
      return mcr.EvaluateFunction(numArgsOut, "Convert", file_path, xml_path);
    }


    /// <summary>
    /// Provides an interface for the Convert function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// CONVERT 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("Convert", 2, 0, 0)]
    protected void Convert(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("Convert", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a void output, 0-input Objectinterface to the Description MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// DESCRIPTION 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    ///
    public void Description()
    {
      mcr.EvaluateFunction(0, "Description", new Object[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input Objectinterface to the Description MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// DESCRIPTION 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="path">Input argument #1</param>
    ///
    public void Description(Object path)
    {
      mcr.EvaluateFunction(0, "Description", path);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the Description MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// DESCRIPTION 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Description(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "Description", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the Description MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// DESCRIPTION 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="path">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Description(int numArgsOut, Object path)
    {
      return mcr.EvaluateFunction(numArgsOut, "Description", path);
    }


    /// <summary>
    /// Provides an interface for the Description function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// DESCRIPTION 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("Description", 1, 0, 0)]
    protected void Description(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("Description", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a void output, 0-input Objectinterface to the Initialize MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// INITIALIZE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    ///
    public void Initialize()
    {
      mcr.EvaluateFunction(0, "Initialize", new Object[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input Objectinterface to the Initialize MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// INITIALIZE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="states">Input argument #1</param>
    ///
    public void Initialize(Object states)
    {
      mcr.EvaluateFunction(0, "Initialize", states);
    }


    /// <summary>
    /// Provides a void output, 2-input Objectinterface to the Initialize MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// INITIALIZE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="states">Input argument #1</param>
    /// <param name="parameters">Input argument #2</param>
    ///
    public void Initialize(Object states, Object parameters)
    {
      mcr.EvaluateFunction(0, "Initialize", states, parameters);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the Initialize MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// INITIALIZE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Initialize(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "Initialize", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the Initialize MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// INITIALIZE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="states">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Initialize(int numArgsOut, Object states)
    {
      return mcr.EvaluateFunction(numArgsOut, "Initialize", states);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the Initialize MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// INITIALIZE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="states">Input argument #1</param>
    /// <param name="parameters">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Initialize(int numArgsOut, Object states, Object parameters)
    {
      return mcr.EvaluateFunction(numArgsOut, "Initialize", states, parameters);
    }


    /// <summary>
    /// Provides an interface for the Initialize function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// INITIALIZE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("Initialize", 2, 0, 0)]
    protected void Initialize(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("Initialize", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a void output, 0-input Objectinterface to the Inquire MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// INQUIRE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    ///
    public void Inquire()
    {
      mcr.EvaluateFunction(0, "Inquire", new Object[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input Objectinterface to the Inquire MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// INQUIRE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="name">Input argument #1</param>
    ///
    public void Inquire(Object name)
    {
      mcr.EvaluateFunction(0, "Inquire", name);
    }


    /// <summary>
    /// Provides a void output, 2-input Objectinterface to the Inquire MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// INQUIRE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="name">Input argument #1</param>
    /// <param name="states">Input argument #2</param>
    ///
    public void Inquire(Object name, Object states)
    {
      mcr.EvaluateFunction(0, "Inquire", name, states);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the Inquire MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// INQUIRE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Inquire(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "Inquire", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the Inquire MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// INQUIRE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="name">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Inquire(int numArgsOut, Object name)
    {
      return mcr.EvaluateFunction(numArgsOut, "Inquire", name);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the Inquire MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// INQUIRE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="name">Input argument #1</param>
    /// <param name="states">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Inquire(int numArgsOut, Object name, Object states)
    {
      return mcr.EvaluateFunction(numArgsOut, "Inquire", name, states);
    }


    /// <summary>
    /// Provides an interface for the Inquire function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// INQUIRE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("Inquire", 2, 0, 0)]
    protected void Inquire(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("Inquire", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a void output, 0-input Objectinterface to the Update MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// UPDATE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    ///
    public void Update()
    {
      mcr.EvaluateFunction(0, "Update", new Object[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input Objectinterface to the Update MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// UPDATE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="states">Input argument #1</param>
    ///
    public void Update(Object states)
    {
      mcr.EvaluateFunction(0, "Update", states);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the Update MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// UPDATE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Update(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "Update", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the Update MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// UPDATE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="states">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Update(int numArgsOut, Object states)
    {
      return mcr.EvaluateFunction(numArgsOut, "Update", states);
    }


    /// <summary>
    /// Provides an interface for the Update function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// UPDATE 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("Update", 1, 0, 0)]
    protected void Update(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("Update", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }

    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private static Exception ex_= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
