using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NDC2010.Model;
using NDC2010.Logic.Presenters;

namespace NDC2010.Tests.SessionsPresenterTests
{
	[TestFixture]
	public class Getting_sessions_by_day : SessionsPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_contain_valid_sessions_for_day_1()
		{
			// Arrange
			Presenter.Sessions = SessionBuilder.CreateListWithSize(10)
                                               .WhereTheFirst(5).HasDay(1)
                                               .AndTheNext(5).HasDay(2)
                                               .Build();
			
			// Act
			var results = Presenter.GetSessionsForDay(1);
			
			// Assert
			results.Count().ShouldBe(5);
			foreach (var session in results)
				session.Day.ShouldBe(1);
		}
		
		[Test]
		public void Should_return_empty_list_for_day_0()
		{
			// Arrange
			Presenter.Sessions = SessionBuilder.CreateListWithSize(10)
                                               .WhereTheFirst(10).HasDay(2)
                                               .Build();
			
			// Act
			var results = Presenter.GetSessionsForDay(0);
			
			// Assert
			results.Count().ShouldBe(0);
		}
		
		[Test]
		public void Should_return_empty_list_for_day_4()
		{
			// Arrange
			Presenter.Sessions = SessionBuilder.CreateListWithSize(10)
                                               .WhereTheFirst(10).HasDay(2)
                                               .Build();
			
			// Act
			var results = Presenter.GetSessionsForDay(4);
			
			// Assert
			results.Count().ShouldBe(0);
		}
	}
}