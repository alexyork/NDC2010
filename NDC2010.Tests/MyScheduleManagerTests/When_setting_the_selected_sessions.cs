using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NDC2010.Logic.Managers;
using NDC2010.Model;

namespace NDC2010.Tests.MyScheduleManagerTests
{
	[TestFixture]
	public class When_setting_the_selected_sessions : MyScheduleManagerTestBase
	{
		[SetUp]
		public void SetUp()
		{
			Initialise_manager_and_repository();
		}
		
		[Test]
		public void Should_ask_the_repository_to_get_all_selected_sessions()
		{
			var sessions = new List<Session>
			{
				new Session { ID = mockGuid1, Title = "Some fake session" }
			};
			manager = new MyScheduleManager(repository, sessions);
			
			manager.SetSelectedSessions();
			
			repository.GetAllWasCalled.ShouldBe(true);
		}
		
		[Test]
		public void Should_flag_the_correct_sessions()
		{
			var sessions = new List<Session>
			{
				new Session { ID = mockGuid1, Title = "Some fake session" },
				new Session { ID = mockGuid2, Title = "Another fake session" }
			};
			repository.SessionIdsToGet = new List<Guid> { mockGuid1 };
			manager = new MyScheduleManager(repository, sessions);
			
			manager.SetSelectedSessions();
			
			sessions[0].IsSelected.ShouldBe(true);
			sessions[1].IsSelected.ShouldBe(false);
		}
	}
}