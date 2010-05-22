using System;

namespace NDC2010.Logic.Presenters
{
	public class DaysPresenter
	{
		private string[] _days;
		
		public DaysPresenter()
		{
			_days = new string[]
			{
				"Wednesday, June 16",
				"Thursday, June 17",
				"Friday, June 18"
			};
		}
		
		public string GetTextForDay(int index)
		{
			return _days[index];
		}
		
		public int GetNumberOfDays()
		{
			return _days.Length;
		}
		
		public string GetTitleForSection()
		{
			return "Select day";
		}
		
		public string GetTitle()
		{
			return "NDC 2010";
		}
	}
}
