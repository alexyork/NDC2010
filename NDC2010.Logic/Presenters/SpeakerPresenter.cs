using System;
using System.Collections.Generic;
using System.Linq;
using NDC2010.Model;

namespace NDC2010.Logic.Presenters
{
	public class SpeakerPresenter
	{
		public Speaker Speaker { get; set; }
		public List<Session> Sessions { get; set; }
		
		public SpeakerPresenter()
		{
		}
		
		public string GetTitle()
		{
			return "Speaker";
		}
		
		public string GetHeadingTextForName()
		{
			return "Speaker";
		}
		
		public string GetHeadingTextForSessions()
		{
			return "Sessions";
		}
		
		public List<Session> GetSessions()
		{
			var sessions = new List<Session>();
			
			foreach (var session in Sessions)
				foreach (var speaker in session.Speakers)
					if (speaker.Name == Speaker.Name)
						sessions.Add(session);
			
			return sessions.ToList();
		}
	}
}