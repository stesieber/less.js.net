using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Less.Js.Net.Tests
{
	[TestClass]
	public class LessJsBasicIntegrationTest
	{
		private Less _lessCompiler;

		[TestInitialize]
		public void Init()
		{
			_lessCompiler = new Less();
		}


		[TestMethod]
		public void VariablesWork()
		{
			var less = @" @variable : 20px;
						bar { width : @variable; }";
			var expected = @"bar {width: 20px;}";

			AssertLessCompilationCorrect(less, expected);
		}

		[TestMethod]
		public void StrictMathIsUsedByDefault()
		{
			AssertLessCompilationCorrect("foo {width: calc(10% -10px)}", "foo {width: calc(10% -10px);}");
		}

		private void AssertLessCompilationCorrect(string lessInput, string expectedResult)
		{
			var result = _lessCompiler.Compile(lessInput);
			AssertUtil.AreEqualIgnoreWhitespace(expectedResult, result);
		}

	}
}
