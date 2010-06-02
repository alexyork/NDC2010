using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NDC2010.Logic.Presenters;

namespace NDC2010.Tests.MySchedulePresenterTests
{
	[TestFixture]
	public class Getting_sessions
	{
		[Test]
		public void Should_only_return_sessions_that_are_selected()
		{
			var sessions = SessionBuilder.CreateListWithSize(10)
								.WhereTheFirst(5).IsSelected(true)
								.AndTheNext(5).IsSelected(false)
								.Build();
			
			var presenter = new MySchedulePresenter(sessions);
			
			var results = presenter.GetSessions();
			
			results.Count().ShouldBe(5);
			foreach (var result in results)
				result.IsSelected.ShouldBe(true);
		}
	}
}