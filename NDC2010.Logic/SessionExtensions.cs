using System;
using NDC2010.Model;

namespace NDC2010.Logic
{
	public static class SessionExtensions
	{
		public static string GetInfo(this Session session)
		{
			return string.Format("Day {0}; {1}; Track {2}", session.Day, session.Time, session.Track);
		}
	}
}