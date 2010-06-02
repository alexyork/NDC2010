using System;
using NDC2010.Model;

namespace NDC2010.Logic
{
	public static class SessionExtensions
	{
		public static string GetDayTimeTrackInfo(this Session session)
		{
			return string.Format("Day {0}; {1}; Track {2}", session.Day, session.Time, session.Track);
		}
		
		public static string GetTimeTrackSpeakerInfo(this Session session)
		{
			return string.Format("{0}; Track {1}; {2}", session.Time, session.Track, session.Speakers[0].Name);
		}
	}
}