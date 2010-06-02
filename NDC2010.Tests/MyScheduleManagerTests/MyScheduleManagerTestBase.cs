using System;
using NDC2010.Logic.Managers;
using NDC2010.Model.MySchedule;

namespace NDC2010.Tests.MyScheduleManagerTests
{
	public class MyScheduleManagerTestBase
	{
		protected MyScheduleManager manager;
		protected FakeScheduleRepository repository;
		protected Guid mockGuid1 = new Guid("11111111-1111-1111-1111-111111111111");
		protected Guid mockGuid2 = new Guid("22222222-2222-2222-2222-222222222222");
		
		protected void Initialise_manager_and_repository()
		{
			repository = new FakeScheduleRepository();
			manager = new MyScheduleManager(repository, null);
		}
	}
}