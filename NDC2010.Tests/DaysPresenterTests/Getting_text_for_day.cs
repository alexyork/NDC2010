using System;
using NUnit.Framework;

namespace NDC2010.Tests.DaysPresenterTests
{
	[TestFixture()]
	public class Getting_text_for_day : DaysPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_correct_text_for_day_1()
		{
			string result = Presenter.GetTextForDay(1);
			
			result.ShouldContain("Wednesday");
			result.ShouldContain("June 16");
		} 
		
		[Test]
		public void Should_return_correct_text_for_day_2()
		{
			string result = Presenter.GetTextForDay(2);
			
			result.ShouldContain("Thursday");
			result.ShouldContain("June 17");
		} 
		
		[Test]
		public void Should_return_correct_text_for_day_3()
		{
			string result = Presenter.GetTextForDay(3);
			
			result.ShouldContain("Friday");
			result.ShouldContain("June 18");
		} 
	}
}
