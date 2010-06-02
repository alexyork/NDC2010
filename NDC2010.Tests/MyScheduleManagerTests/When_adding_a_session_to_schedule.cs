using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NDC2010.Logic.Managers;
using NDC2010.Model;

namespace NDC2010.Tests.MyScheduleManagerTests
{
	[TestFixture]
	public class When_adding_a_session_to_schedule : MyScheduleManagerTestBase
	{
		[SetUp]
		public void SetUp()
		{
			Initialise_manager_and_repository();
		}
		
		[Test]
		public void Should_ask_schedule_repository_to_save()
		{
			var session = new Session { ID = mockGuid1, Title = "Some fake session to add" };
			manager = new MyScheduleManager(repository, new List<Session> { session });
			
			manager.AddToSchedule(session);
			
			repository.SaveWasCalled.ShouldBe(true);
		}
		
		[Test]
		public void Should_set_IsSelected_to_true_on_the_session()
		{
			var session = new Session { ID = mockGuid1, Title = "Some fake session to add" };
			manager = new MyScheduleManager(repository, new List<Session> { session });
			
			manager.AddToSchedule(session);
			
			session.IsSelected.ShouldBe(true);
		}
		
		[Test]
		public void Should_pass_the_newly_added_session_to_the_repository()
		{
			var session = new Session { ID = mockGuid1, Title = "Some fake session to add" };
			manager = new MyScheduleManager(repository, new List<Session> { session });
			
			manager.AddToSchedule(session);
			
			repository.SessionIdsToSave.Contains(mockGuid1).ShouldBe(true);
		}
		
		[Test]
		public void Should_pass_previously_added_sessions_to_the_repository()
		{
			var session1 = new Session { ID = mockGuid1, Title = "Some fake session to add" };
			var session2 = new Session { ID = mockGuid2, IsSelected = true, Title = "Another fake session" };
			manager = new MyScheduleManager(repository, new List<Session> { session1, session2 });
			
			manager.AddToSchedule(session1);
			
			repository.SessionIdsToSave.Contains(mockGuid2).ShouldBe(true);
		}
	}
}