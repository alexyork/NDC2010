using System;
using System.Collections.Generic;

namespace NDC2010.Logic.Presenters
{
	public class DaysPresenter
	{
		private Dictionary<int, string> _days;
		
		public DaysPresenter()
		{
			_days = new Dictionary<int, string>
			{
				{ 1, "Wednesday, June 16" },
				{ 2, "Thursday, June 17" },
				{ 3, "Friday, June 18" }
			};
		}
		
		public string GetTextForDay(int day)
		{
			return _days[day];
		}
		
		public int GetNumberOfDays()
		{
			return _days.Count;
		}
		
		public string GetHeadingText()
		{
			return "Select day";
		}
		
		public string GetFooterText()
		{
			return "Note: Any last-minute changes to the schedule will not be reflected in this app.";
		}
		
		public string GetTitle()
		{
			return "NDC 2010";
		}
	}
}
