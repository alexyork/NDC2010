using System;
using System.Linq;
using System.Xml.Linq;
using NDC2010.Model;

namespace NDC2010.Logic
{
	public static class SessionConverter
	{
		public static Session FromXml(XElement xml)
   		{
			return new Session
				    {
						ID = (Guid) xml.Element("id"),
						Title = (string) xml.Element("title"),
						Speakers = (from speaker in xml.Element("speakers").Elements("speaker")
				            			select new Speaker
				            			{
										Name = (string) speaker.Element("name"),
										Info = (string) speaker.Element("info")
									}).ToArray(),
						Day = (int) xml.Element("day"),
						Track = (int) xml.Element("track"),
						Time = (string) xml.Element("time"),
						Description = (string) xml.Element("description")
				    };
   		}
	}
}