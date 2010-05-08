using System;
using System.Collections.Generic;
using System.Linq;
using NDC2010.Model;
using NDC2010.Logic;

namespace NDC2010.Logic.Presenters
{
	public class SpeakersPresenter
	{
		public IEnumerable<Session> Sessions { get; set; }
		
		public SpeakersPresenter()
			: this(new Session [] { })
		{
		}
		
		public SpeakersPresenter(IEnumerable<Session> sessions)
		{
			Sessions = sessions;
		}
		
		public Speaker[] GetAllSpeakers()
		{
			var query = from session in Sessions
						from speaker in session.Speakers
						select speaker;
			
			return query.Distinct(SpeakerComparer.Instance).OrderBy(s => s.Name).ToArray();
		}
	}
}
