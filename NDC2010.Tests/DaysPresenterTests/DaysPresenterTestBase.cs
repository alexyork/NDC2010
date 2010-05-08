using System;
using NDC2010.Logic.Presenters;

namespace NDC2010.Tests.DaysPresenterTests
{
	public class DaysPresenterTestBase
	{
		protected DaysPresenter Presenter;
		
		protected void SetupPresenterAndMocks()
		{
			Presenter = new DaysPresenter();
		}
	}
}