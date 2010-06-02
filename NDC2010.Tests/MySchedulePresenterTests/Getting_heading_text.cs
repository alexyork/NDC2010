using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NDC2010.Logic.Presenters;

namespace NDC2010.Tests.MySchedulePresenterTests
{
	[TestFixture]
	public class Getting_heading_text
	{
		[Test]
		public void Should_return_correct_text_for_day_1()
		{
			var sessions = SessionBuilder.CreateListWithSize(10).Build();
			var presenter = new MySchedulePresenter(sessions);
			
			presenter.GetHeadingTextForDay(1).ShouldBe("Day 1");
		}
		
		[Test]
		public void Should_return_correct_text_for_day_2()
		{
			var sessions = SessionBuilder.CreateListWithSize(10).Build();
			var presenter = new MySchedulePresenter(sessions);
			
			presenter.GetHeadingTextForDay(2).ShouldBe("Day 2");
		}
		
		[Test]
		public void Should_return_correct_text_for_day_3()
		{
			var sessions = SessionBuilder.CreateListWithSize(10).Build();
			var presenter = new MySchedulePresenter(sessions);
			
			presenter.GetHeadingTextForDay(3).ShouldBe("Day 3");
		}
	}
}