using System;
using System.Collections.Generic;
using NDC2010.Model;

namespace NDC2010.Logic.Presenters
{
	public class SpeakerPresenter
	{
		public Speaker Speaker { get; set; }
		public Session[] Sessions { get; set; }
		
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
		
		public string GetHeadingTextForSessions()
		{
			return "Sessions";
		}
		
		public Session[] GetSessions()
		{
			var sessions = new List<Session>();
			
			foreach (var session in Sessions)
				foreach (var speaker in session.Speakers)
					if (speaker.Name == Speaker.Name)
						sessions.Add(session);
			
			return sessions.ToArray();
		}
	}
}