using System;
using NDC2010.Model;

namespace NDC2010.Logic.Presenters
{
	public class SessionPresenter
	{
		public Session Session { get; set; }
		
		public SessionPresenter()
		{
		}
		
		public string GetTitle()
		{
			return "Session";
		}
		
		public string GetHeadingTextForSessionInfo()
		{
			return "Session Info";
		}
		
		public string GetHeadingTextForSessionDescription()
		{
			return "Description";
		}
		
		public string GetTextForSpeakers()
		{
			if (Session.Speakers.Length == 0)
				return string.Empty;
			
			if (Session.Speakers.Length == 1)
				return Session.Speakers[0].Name;
			
			string speakersText = string.Empty;
			foreach (var speaker in Session.Speakers)
				speakersText += speaker.Name + ", ";
			
			return speakersText.Substring(0, speakersText.Length - 2);
		}
		
		public string GetTextForTimeAndPlace()
		{
			return string.Format("Day {0}; {1}; Track {2}", Session.Day, Session.Time, Session.Track);
		}
	}
}