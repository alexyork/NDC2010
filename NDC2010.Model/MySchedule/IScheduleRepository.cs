using System;
using System.Collections.Generic;

namespace NDC2010.Model.MySchedule
{
	public interface IScheduleRepository
	{
		void Save(List<Guid> sessionIds);

		List<Guid> GetAll();
	}
}