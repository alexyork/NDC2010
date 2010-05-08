using System;
using NDC2010.Model;
using NDC2010.Logic.Presenters;

namespace NDC2010.Tests.SpeakerPresenterTests
{
	public class SpeakerPresenterTestBase
	{
		protected SpeakerPresenter Presenter;
		protected Speaker MockSpeaker;
		
		public void SetupPresenterAndMocks()
		{
			Presenter = new SpeakerPresenter();
			
			MockSpeaker = new Speaker
			{
				Info = "Speaker info",
				Name = "Joe Bloggs"
			};
			
			Presenter.Speaker = MockSpeaker;
		}
	}
}