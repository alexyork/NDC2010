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
		protected MySchedulePresenter Presenter;
		
		[SetUp]
		public void SetUp()
		{
			Presenter = new MySchedulePresenter(null);
		}
		
		[Test]
		public void Should_return_correct_text_for_day_1()
		{
			Presenter.GetHeadingTextForDay(1).ShouldBe("Day 1");
		}
		
		[Test]
		public void Should_return_correct_text_for_day_2()
		{
			Presenter.GetHeadingTextForDay(2).ShouldBe("Day 2");
		}
		
		[Test]
		public void Should_return_correct_text_for_day_3()
		{
			Presenter.GetHeadingTextForDay(3).ShouldBe("Day 3");
		}
	}
}