using System;
using NUnit.Framework;

namespace NDC2010.Tests
{
	public static class TestExtensionsHelpers
	{
		public static void ShouldBe(this object objectToTest, object expectedObject)
		{
			Assert.AreEqual(expectedObject, objectToTest);
		}
	}
}
