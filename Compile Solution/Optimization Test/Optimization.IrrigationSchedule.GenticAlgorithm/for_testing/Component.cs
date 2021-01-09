/*
* MATLAB Compiler: 8.0 (R2020a)
* Date: Wed Dec 23 18:18:14 2020
* Arguments:
* "-B""macro_default""-W""dotnet:Optimization_For_Test,Component,4.0,private,version=1.0""
* -T""link:lib""-d""C:\Users\Song Jim\Desktop\Optimization
* Test\Optimization.IrrigationSchedule.GenticAlgorithm\for_testing""-v""class{Component:C:
* \Users\Song Jim\Desktop\Optimization Test\Analyze.m,C:\Users\Song
* Jim\Desktop\Optimization Test\Configurate.m,C:\Users\Song Jim\Desktop\Optimization
* Test\Description.m}"
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace Optimization_For_Test
{

  /// <summary>
  /// The Component class provides a CLS compliant, MWArray interface to the MATLAB
  /// functions contained in the files:
  /// <newpara></newpara>
  /// C:\Users\Song Jim\Desktop\Optimization Test\Analyze.m
  /// <newpara></newpara>
  /// C:\Users\Song Jim\Desktop\Optimization Test\Configurate.m
  /// <newpara></newpara>
  /// C:\Users\Song Jim\Desktop\Optimization Test\Description.m
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

          string ctfFileName = "Optimization_For_Test.ctf";

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
    /// Provides a void output, 0-input MWArrayinterface to the Analyze MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    ///
    public void Analyze()
    {
      mcr.EvaluateFunction(0, "Analyze", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input MWArrayinterface to the Analyze MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="simulator">Input argument #1</param>
    ///
    public void Analyze(MWArray simulator)
    {
      mcr.EvaluateFunction(0, "Analyze", simulator);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the Analyze MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Analyze(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "Analyze", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the Analyze MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="simulator">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Analyze(int numArgsOut, MWArray simulator)
    {
      return mcr.EvaluateFunction(numArgsOut, "Analyze", simulator);
    }


    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the Configurate MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    ///
    public void Configurate()
    {
      mcr.EvaluateFunction(0, "Configurate", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input MWArrayinterface to the Configurate MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="path">Input argument #1</param>
    ///
    public void Configurate(MWArray path)
    {
      mcr.EvaluateFunction(0, "Configurate", path);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the Configurate MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Configurate(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "Configurate", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the Configurate MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="path">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Configurate(int numArgsOut, MWArray path)
    {
      return mcr.EvaluateFunction(numArgsOut, "Configurate", path);
    }


    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the Description MATLAB
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
      mcr.EvaluateFunction(0, "Description", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input MWArrayinterface to the Description MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// DESCRIPTION 此处显示有关此函数的摘要
    /// 此处显示详细说明
    /// </remarks>
    /// <param name="path">Input argument #1</param>
    ///
    public void Description(MWArray path)
    {
      mcr.EvaluateFunction(0, "Description", path);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the Description MATLAB
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
    public MWArray[] Description(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "Description", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the Description MATLAB
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
    public MWArray[] Description(int numArgsOut, MWArray path)
    {
      return mcr.EvaluateFunction(numArgsOut, "Description", path);
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
