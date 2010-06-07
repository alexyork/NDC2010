using System;
using NUnit.Framework;
using NDC2010.Logic.Presenters;

namespace NDC2010.Tests.MySchedulePresenterTests
{
	[TestFixture]
	public class Getting_title
	{
		protected MySchedulePresenter Presenter;
		
		[SetUp]
		public void SetUp()
		{
			Presenter = new MySchedulePresenter(null);
		}
		
		[Test]
		public void Should_return_correct_title()
		{
			Presenter.GetTitle().ShouldNotBeNullOrEmpty();
		}
	}
}