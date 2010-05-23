using System;
using NDC2010.Model;

namespace NDC2010.Logic.Presenters
{
	public class SpeakerPresenter
	{
		public Speaker Speaker { get; set; }
		
		public SpeakerPresenter()
		{
		}
		
		public string GetTitle()
		{
			return "Speaker";
		}
		
		public string GetHeadingTextForName()
		{
			return "Name";
		}
		
		public string GetHeadingTextForBio()
		{
			return "Bio";
		}
		
		/*
		public string GetHeadingTextForSessions()
		{
			return "Sessions";
		}
		*/
	}
}