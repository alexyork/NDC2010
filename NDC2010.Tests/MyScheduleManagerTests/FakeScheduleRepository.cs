using System;
using System.Collections.Generic;
using NDC2010.Model.MySchedule;

namespace NDC2010.Tests.MyScheduleManagerTests
{
	public class FakeScheduleRepository : IScheduleRepository
	{
		public bool SaveWasCalled;
		public List<Guid> SessionIdsToSave = new List<Guid>();
		
		public bool GetAllWasCalled;
		public List<Guid> SessionIdsToGet = new List<Guid>();
		
		public void Save(List<Guid> sessionIds)
		{
			SaveWasCalled = true;
			SessionIdsToSave = sessionIds;
		}
		
		public List<Guid> GetAll()
		{
			GetAllWasCalled = true;
			return SessionIdsToGet;
		}
	}
}