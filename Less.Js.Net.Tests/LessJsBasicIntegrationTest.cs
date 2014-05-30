using System;
using System.IO;
using System.Text;
using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Less.Js.Net.Tests
{
	[TestClass]
	public class LessJsBasicIntegrationTest
	{
		[TestMethod]
		public void MultipleImports()
		{
			try
			{
				var engine = new V8ScriptEngine("lessJsEngine");
				IncludeScript(engine, "lessIntegration.js");
				IncludeScript(engine, "less-1.7.0.js");
				string result = (string) engine.Evaluate("lessJsNet.lessIt('foo {width: calc(10% -10px)}')");
				AssertAreEqualIgnoreWhitespace("foo {width: calc(10% -10px);}", result);
			}
			catch (ScriptEngineException e)
			{
				throw new Exception(e.ErrorDetails);
			}
		}

		private static void IncludeScript(V8ScriptEngine engine, string scriptName)
		{
			string script = File.ReadAllText(scriptName, Encoding.UTF8);
			engine.Execute(scriptName, script);
		}

		private void AssertAreEqualIgnoreWhitespace(string expected, string actual)
		{
			Assert.AreEqual(StripWhitespace(expected), StripWhitespace(actual));
		}

		private string StripWhitespace(string str)
		{
			return str
				.Replace(" ", "")
				.Replace("\n", "")
				.Replace("\t", "");
		}

	}
}
