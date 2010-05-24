using System;
using NDC2010.Logic.Presenters;

namespace NDC2010.Tests.SpeakersPresenterTests
{
	public class SpeakersPresenterTestBase
	{
		protected SpeakersPresenter Presenter;
		
		protected void SetupPresenterAndMocks()
		{
			Presenter = new SpeakersPresenter(null);
		}
	}
}
