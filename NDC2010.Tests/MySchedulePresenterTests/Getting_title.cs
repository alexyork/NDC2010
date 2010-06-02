using System;
using NUnit.Framework;
using NDC2010.Logic.Presenters;

namespace NDC2010.Tests.MySchedulePresenterTests
{
	[TestFixture]
	public class Getting_title
	{
		[Test]
		public void Should_return_correct_title()
		{
			var sessions = SessionBuilder.CreateListWithSize(10).Build();
			var presenter = new MySchedulePresenter(sessions);
			
			presenter.GetTitle().ShouldBe("My Schedule");
		}
	}
}