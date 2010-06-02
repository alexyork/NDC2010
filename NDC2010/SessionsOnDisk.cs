using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using NDC2010.Model;
using NDC2010.Logic;

namespace NDC2010
{
	public static class SessionsOnDisk
	{
		public static List<Session> GetAll()
		{
			var rawXml = File.ReadAllText("App_Data/sessions.xml");
			
			return XDocument.Parse(rawXml)
							.Descendants("session")
							.Select(tweetXml => SessionConverter.FromXml(tweetXml))
							.ToList();
		}
	}
}
