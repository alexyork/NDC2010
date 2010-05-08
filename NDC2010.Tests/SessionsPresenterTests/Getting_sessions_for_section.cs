using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NDC2010.Model;
using NDC2010.Logic.Presenters;

namespace NDC2010.Tests.SessionsPresenterTests
{
	[TestFixture]
	public class Getting_sessions_for_section : SessionsPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_3_sessions_in_section_0()
		{
			// Arrange
			Presenter.Sessions = SessionBuilder.CreateListWithSize(10)
                                               .WhereTheFirst(3).HasTime("9:00 - 10:00")
											   .AndTheNext(7).HasTime("10:20 - 11.20")
                                               .Build();
			
			// Act
			var sessions = Presenter.GetSessionsForSection(0);
			
			// Assert
			sessions.Count().ShouldBe(3);
			foreach (var session in sessions)
				session.Time.ShouldBe("9:00 - 10:00");
		}
		
		[Test]
		public void Should_return_7_sessions_in_section_1()
		{
			// Arrange
			Presenter.Sessions = SessionBuilder.CreateListWithSize(10)
                                               .WhereTheFirst(3).HasTime("9:00 - 10:00")
											   .AndTheNext(7).HasTime("10:20 - 11:20")
                                               .Build();
			
			// Act
			var sessions = Presenter.GetSessionsForSection(1);
			
			// Assert
			sessions.Count().ShouldBe(7);
			foreach (var session in sessions)
				session.Time.ShouldBe("10:20 - 11:20");
		}
	}
}