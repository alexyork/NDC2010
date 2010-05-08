using System;
using NDC2010.Logic.Presenters;

namespace NDC2010.Tests.SessionsPresenterTests
{
	public class SessionsPresenterTestBase
	{
		protected SessionsPresenter Presenter;
		
		protected void SetupPresenterAndMocks()
		{
			Presenter = new SessionsPresenter();
		}
	}
}