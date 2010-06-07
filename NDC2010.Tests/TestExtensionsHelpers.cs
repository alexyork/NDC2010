using System;
using NUnit.Framework;

namespace NDC2010.Tests
{
	public static class TestExtensionsHelpers
	{
		public static void ShouldBe(this object objectToTest, object expectedObject)
		{
			Assert.AreEqual( expectedObject, objectToTest );
		}
		
		public static void ShouldNotBeNullOrEmpty(this string stringToTest)
		{
			Assert.IsTrue( !string.IsNullOrEmpty(stringToTest) );
		}
		
		public static void ShouldContain(this string stringToTest, string expectedText)
		{
			Assert.IsTrue( stringToTest.IndexOf(expectedText) != -1 );
		}
	}
}