using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;

namespace Less.Js.Net
{
	/// <summary>
	/// Less compiler. This class is NOT threadsafe!
	/// </summary>
    public class Less
    {
	    private readonly V8ScriptEngine _engine;

		/*
		 * Next steps
		 * - wrap options in API
		 * - make imports work
		 * - ensure it runs in concurrent environment
		 * - ? provide caching
		 * - basic documentation
		 * - provide nuget package.
		 * - publish nuget package
		 * - anounce with simple asp.Net mvc howto.
		 * - enhanced documentation
		 *  
		 */
	    public Less()
	    {
			_engine = new V8ScriptEngine("lessJsEngine");
			IncludeScript("lessIntegration.js");
			IncludeScript("less-1.7.0.js");
	    }

	    public string Compile(string lessCode)
	    {
		    try
		    {
			    _engine.Script.lessCode = lessCode;
			    return (string) _engine.Evaluate("lessJsNet.lessIt(lessCode)");
		    }
		    catch (ScriptEngineException e)
		    {
			    throw new LessCompilationException(e);
		    }
	    }


	    private void IncludeScript(string scriptName)
	    {
		    string resourceName = string.Format("Less.Js.Net.javascript.{0}", scriptName);

		    Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
			StreamReader reader = new StreamReader(resourceStream);
		    try
		    {
			    //string script = File.ReadAllText(scriptName, Encoding.UTF8);
			    _engine.Execute(scriptName, reader.ReadToEnd());
		    }
		    catch (ScriptEngineException e)
		    {
			    throw new LessCompilationException(e);
		    }
		}

    }
}
