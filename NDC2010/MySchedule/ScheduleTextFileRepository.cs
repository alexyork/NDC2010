using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using NDC2010.Model.MySchedule;

namespace NDC2010
{
	public class ScheduleTextFileRepository : IScheduleRepository
	{
		protected string TextFilePath
		{
			get
			{
				var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				return Path.Combine(documents, "MySchedule.txt");
			}
		}
		
		public void Save(List<Guid> sessionIds)
		{
			File.WriteAllLines(TextFilePath, sessionIds.Select(id => id.ToString()).ToArray());
			
			Console.WriteLine("Writing Session ID's to disk");
			foreach (var sessionId in sessionIds)
				Console.WriteLine("Session ID: " + sessionId);
		}
		
		public List<Guid> GetAll()
		{
			if (!File.Exists(TextFilePath)) return new List<Guid>();
			
			var sessionIds = File.ReadAllLines(TextFilePath);
			
			Console.WriteLine("Reading Session ID's from disk");
			foreach (var sessionId in sessionIds)
				Console.WriteLine("Session ID: " + sessionId);
			
			return sessionIds.Select(id => new Guid(id)).ToList();
		}
	}
}