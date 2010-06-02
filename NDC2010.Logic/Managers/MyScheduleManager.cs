using System;
using System.Collections.Generic;
using System.Linq;
using NDC2010.Model;
using NDC2010.Model.MySchedule;

namespace NDC2010.Logic.Managers
{
	public class MyScheduleManager
	{
		private IScheduleRepository _scheduleRepository;
		private List<Session> _sessions;
		
		public MyScheduleManager(IScheduleRepository scheduleRepository, List<Session> sessions)
		{
			_scheduleRepository = scheduleRepository;
			_sessions = sessions;
		}
		
		public void SetSelectedSessions()
		{
			var selectedSessionIds = _scheduleRepository.GetAll();
			
			foreach (var session in _sessions)
			{
				if (selectedSessionIds.Contains(session.ID))
				{
					session.IsSelected = true;
				}
			}
		}
		
		public void AddToSchedule(Session session)
		{
			session.IsSelected = true;
			SaveSelectedSessions();
		}
		
		public void RemoveFromSchedule(Session session)
		{
			session.IsSelected = false;
			SaveSelectedSessions();
		}
		
		private void SaveSelectedSessions()
		{
			var selectedSessionIds = _sessions.Where(s => s.IsSelected)
											  .Select(s => s.ID)
											  .ToList();
			
			_scheduleRepository.Save(selectedSessionIds);
		}
	}
}