using System;

namespace NDC2010.Logic
{
	public static class FriendlyDateTime
	{
		public static string Get(DateTime dateInThePast, DateTime dateNow)
		{
			if (dateInThePast > dateNow) return "";
			
			var timeDifference = dateNow - dateInThePast;
			
			if (timeDifference.Days > 30)
				return string.Format("{0} months ago", timeDifference.Days / 30);
			if (timeDifference.Days == 1)
				return "yesterday";
			else if (timeDifference.Days > 0)
				return string.Format("{0} days ago", timeDifference.Days);
			
			if (timeDifference.Hours == 1)
				return "an hour ago";
			else if (timeDifference.Hours > 0)
				return string.Format("{0} hours ago", timeDifference.Hours);
			
			if (timeDifference.Minutes <= 1)
				return "1 min ago";
			
			return string.Format("{0} mins ago", timeDifference.Minutes);
		}
	}
}