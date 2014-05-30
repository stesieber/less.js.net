using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Less.Js.Net.Tests
{
	public static class AssertUtil
	{
		public static void AreEqualIgnoreWhitespace(string expected, string actual)
		{
			Assert.AreEqual(StripWhitespace(expected), StripWhitespace(actual));
		}

		private static string StripWhitespace(string str)
		{
			return str
				.Replace(" ", "")
				.Replace("\n", "")
				.Replace("\r", "")
				.Replace("\t", "");
		}
	}
}
