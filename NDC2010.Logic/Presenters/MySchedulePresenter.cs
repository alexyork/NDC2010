using System;
using System.Collections.Generic;
using System.Linq;
using NDC2010.Model;

namespace NDC2010.Logic.Presenters
{
	public class MySchedulePresenter
	{
		protected List<Session> Sessions { get; set; }
		
		public MySchedulePresenter(List<Session> sessions)
		{
			Sessions = sessions;
		}
		
		public List<Session> GetSessions()
		{
			return Sessions.Where(s => s.IsSelected == true).ToList();
		}
		
		public string GetHeadingTextForDay(int day)
		{
			return "Day " + day;
		}
		
		public string GetTitle()
		{
			return "My Schedule";
		}
	}
}