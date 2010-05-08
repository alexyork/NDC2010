using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NDC2010.Model;
using NDC2010.Logic.Presenters;

namespace NDC2010.Tests.SessionsPresenterTests
{
	[TestFixture]
	public class Getting_number_of_daily_timeslots : SessionsPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_contain_7_timeslots()
		{
			Presenter.GetNumberOfDailyTimeslots().ShouldBe(7);
		}
	}
}