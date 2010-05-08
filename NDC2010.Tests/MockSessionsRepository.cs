using System;
using System.Collections.Generic;
using NDC2010.Model;

namespace NDC2010.Tests
{
	/*
	public class MockSessionsRepository// : ISessionsRepository
	{
		public IEnumerable<Session> GetAll()
		{
			var sessions = SessionBuilder.CreateListWithSize(15)
										
										// Mock 5 sessions on each day
										 .WhereTheFirst(5)
										 	.HasDay(1)
										 .AndTheNext(5)
										 	.HasDay(2)
										 .AndTheNext(5)
											.HasDay(3)
					
										// Mock 3 at 9:00am, and 2 at 10:20am
										 .WhereTheFirst(3)
											.HasTime("9:00 - 10:00")
										 .AndTheNext(2)
											.HasTime("10:20 - 11:20")
										 .Build();
			
			return sessions;
		}
	}
	*/
}
