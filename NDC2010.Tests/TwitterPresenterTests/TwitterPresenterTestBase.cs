using System;
using NDC2010.Logic.Presenters;

namespace NDC2010.Tests.TwitterPresenterTests
{
	public class TwitterPresenterTestBase
	{
		protected TwitterPresenter Presenter;
		
		protected void SetupPresenterAndMocks()
		{
			Presenter = new TwitterPresenter();
		}
	}
}
