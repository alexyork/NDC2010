using System;
using NDC2010.Model;
using NDC2010.Logic.Presenters;

namespace NDC2010.Tests.SessionPresenterTests
{
	public class SessionPresenterTestBase
	{
		protected SessionPresenter Presenter;
		protected Session MockSession;
		
		protected void SetupPresenterAndMocks()
		{
			MockSession = new Session
			{
				Day = 1,
				Description = "fake description",
				Speakers = new []
				{
					new Speaker { Name = "Joe Bloggs", Info = "fake speaker info" }
				},
				Time = "time",
				Title = "fake title",
				Track = 1
			};
			
			Presenter = new SessionPresenter();
			Presenter.Session = MockSession;
		}
	}
}
