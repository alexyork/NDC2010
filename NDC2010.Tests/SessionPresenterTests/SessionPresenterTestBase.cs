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
				Description = "desc",
				Speakers = new []
				{
					new Speaker { Name = "Speaker 1", Info = "info 1" }
				},
				Time = "time",
				Title = "tit",
				Track = 1
			};
			
			Presenter = new SessionPresenter();
			Presenter.Session = MockSession;
		}
	}
}
