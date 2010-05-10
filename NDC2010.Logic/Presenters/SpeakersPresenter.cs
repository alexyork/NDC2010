using System;
using System.Collections.Generic;
using System.Linq;
using NDC2010.Model;
using NDC2010.Logic;

namespace NDC2010.Logic.Presenters
{
	public class SpeakersPresenter
	{
		public Session[] Sessions { get; set; }
		
		public SpeakersPresenter()
			: this(new Session [] { })
		{
		}
		
		public SpeakersPresenter(Session[] sessions)
		{
			Sessions = sessions;
		}
		
		//public static bool AlwaysFalse = false;
		
		public Speaker[] GetAllSpeakers()
		{
			/*
			if (AlwaysFalse)
			{
				var foo = ((Session) null).Speakers;
			}
			var query = from session in Sessions
						from speaker in session.Speakers
						select speaker;
			
			return query.Distinct(SpeakerComparer.Instance).OrderBy(s => s.Name).ToArray();
			*/
			
			List<Speaker> speakers = new List<Speaker>();
			foreach (var session in Sessions)
				foreach (var speaker in session.Speakers)
					speakers.Add(speaker);
			
			return speakers.ToArray();
		}
	}
}
