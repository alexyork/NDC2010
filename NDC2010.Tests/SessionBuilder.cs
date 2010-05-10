using System;
using System.Collections.Generic;
using System.Linq;
using NDC2010.Model;

namespace NDC2010.Tests
{
	public class SessionBuilder
	{
		private static List<Session> _sessions;
		private int _currentIndex;
		private int _currentCount;
		
		private SessionBuilder()
		{
			_sessions = new List<Session>();
		}
		
		private Session Create(int i)
		{
			var session = new Session();
			session.Day = 1;
			session.Description = "Description " + i;
			session.Speakers = new []
				{
					new Speaker { Name = "Speaker 1", Info = "info 1" }
				};
			session.Time = "9:00 - 10:00";
			session.Title = "Title " + i;
			return session;
		}
		
		public static SessionBuilder CreateListWithSize(int count)
		{
			var builder = new SessionBuilder();
			
			for (int i = 0; i < count; i++)
			{
				var session = builder.Create(i);
				_sessions.Add(session);
			}
			
			return builder;
		}
		
		public SessionBuilder WhereTheFirst(int count)
		{
			_currentIndex = 0;
			_currentCount = count;
			return this;
		}
		
		public SessionBuilder AndTheNext(int count)
		{
			_currentCount = count;
			return this;
		}
		
		public SessionBuilder HasDay(int day)
		{
			int endIndex = (_currentIndex + _currentCount);
			
			for (int i = _currentIndex; i < endIndex; i++)
			{
				_sessions[i].Day = day;
				_currentIndex++;
			}
			return this;
		}
		
		public SessionBuilder HasTime(string time)
		{
			int endIndex = (_currentIndex + _currentCount);
			
			for (int i = _currentIndex; i < endIndex; i++)
			{
				_sessions[i].Time = time;
				_currentIndex++;
			}
			return this;
		}
		
		public Session[] Build()
		{
			return _sessions.ToArray();
		}
	}
}