using System;
using System.Collections.Generic;
using System.Linq;
using NDC2010.Model;
using NDC2010.Logic;

namespace NDC2010.Logic.Presenters
{
	public class SpeakersPresenter
	{
		protected List<Session> Sessions { get; set; }
		
		public SpeakersPresenter(List<Session> sessions)
		{
			Sessions = sessions;
		}
		
		public List<Speaker> GetAllSpeakers()
		{
			var speakers = new List<Speaker>();
			foreach (var session in Sessions)
				foreach (var speaker in session.Speakers)
					speakers.Add(speaker);
			
			return speakers.Distinct(SpeakerComparer.Instance).OrderBy(s => s.Name).ToList();
		}
		
		public string GetTitle()
		{
			return "Speakers";
		}
	}
}
