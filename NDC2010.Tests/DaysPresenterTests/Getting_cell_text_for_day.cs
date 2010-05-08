using System;
using NUnit.Framework;

namespace NDC2010.Tests.DaysPresenterTests
{
	[TestFixture()]
	public class Getting_cell_text_by_index : DaysPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_correct_text_for_day_1()
		{
			Presenter.GetTextForDay(0).ShouldBe("Wednesday, June 16");
		} 
		
		[Test]
		public void Should_return_correct_text_for_day_2()
		{
			Presenter.GetTextForDay(1).ShouldBe("Thursday, June 17");
		} 
		
		[Test]
		public void Should_return_correct_text_for_day_3()
		{
			Presenter.GetTextForDay(2).ShouldBe("Friday, June 18");
		} 
	}
}
