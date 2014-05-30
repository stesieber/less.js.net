using System.IO;
using System.Reflection;
using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;

namespace Less.Js.Net
{
	public class JintLess
	{
		private readonly V8ScriptEngine _engine;

		public JintLess()
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
				return (string)_engine.Evaluate("lessJsNet.lessIt(lessCode)");
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
			//string script = File.ReadAllText(scriptName, Encoding.UTF8);
			_engine.Execute(reader.ReadToEnd());
		}
	}
}
