using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Less.Js.Net.Tests
{
	[TestClass]
	public class CompilationBenchmark
	{
		private Less _less;

		[TestInitialize]
		public void Init()
		{
			_less = new Less();
		}

		[TestMethod]
		public void CompileBenchmarkFile()
		{
			var less = File.ReadAllText("benchmark.less");
			_less.Compile(less);
		}

		[TestMethod]
		public void BenchmarkIsCompiledCorrectly()
		{
			var less = File.ReadAllText("benchmark.less");
			var expected = File.ReadAllText("benchmark_result.css");
			var result = _less.Compile(less);
			AssertUtil.AreEqualIgnoreWhitespace(expected, result);
		}
	}
}
