using System;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using NDC2010.Model;
using NDC2010.Logic;

namespace NDC2010
{
	public class DefaultSessionsRepository
	{
		public Session[] GetAll()
		{
			var rawXml = File.ReadAllText("App_Data/sessions.xml");
			var sessionsXml = XDocument.Parse(rawXml);
			
			return sessionsXml.Descendants("session")
							  .Select(tweetXml => SessionConverter.FromXml(tweetXml))
							  .ToArray();
		}
	}
}
