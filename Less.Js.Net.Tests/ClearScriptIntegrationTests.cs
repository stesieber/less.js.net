using System;
using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Less.Js.Net.Tests
{
	[TestClass]
	public class ClearScriptIntegrationTests
	{
		[TestMethod]
		public void RunHelloWorld()
		{
			var engine = new V8ScriptEngine("testEngine");
			var result = engine.Evaluate("1 + 1") as int?;
			Assert.IsTrue(result.HasValue);
			Assert.AreEqual(2, result.Value);
		}

		[TestMethod]
		public void SomeConsoleWriting()
		{
			var engine = new V8ScriptEngine("testEngine");
			engine.AddHostType("Console", typeof(Console));
			engine.Execute("Console.WriteLine('Hello World')");
		}
	}
}
