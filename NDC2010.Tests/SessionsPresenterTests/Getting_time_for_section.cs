using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NDC2010.Model;
using NDC2010.Logic.Presenters;

namespace NDC2010.Tests.SessionsPresenterTests
{
	[TestFixture]
	public class Getting_time_for_section : SessionsPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_correct_time_for_section_0()
		{
			Presenter.GetTimeForSection(0).ShouldBe("9:00 - 10:00");
		}
		
		[Test]
		public void Should_return_correct_time_for_section_1()
		{
			Presenter.GetTimeForSection(1).ShouldBe("10:20 - 11:20");
		}
		
		[Test]
		public void Should_return_correct_time_for_section_2()
		{
			Presenter.GetTimeForSection(2).ShouldBe("11:40 - 12:40");
		}
		
		[Test]
		public void Should_return_correct_time_for_section_3()
		{
			Presenter.GetTimeForSection(3).ShouldBe("13:40 - 14:40");
		}
		
		[Test]
		public void Should_return_correct_time_for_section_4()
		{
			Presenter.GetTimeForSection(4).ShouldBe("15:00 - 16:00");
		}
		
		[Test]
		public void Should_return_correct_time_for_section_5()
		{
			Presenter.GetTimeForSection(5).ShouldBe("16:20 - 17:20");
		}
		
		[Test]
		public void Should_return_correct_time_for_section_6()
		{
			Presenter.GetTimeForSection(6).ShouldBe("17:40 - 18:40");
		}
	}
}