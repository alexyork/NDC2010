using System;
using System.Collections.Generic;
using NDC2010.Model;

namespace NDC2010.Logic
{
	public class SpeakerComparer : IEqualityComparer<Speaker>
	{
		private static SpeakerComparer _instance;
		public static SpeakerComparer Instance
		{
			get
			{
				if (_instance == null)
					_instance = new SpeakerComparer();
				return _instance;
			}
		}
		
		public bool Equals(Speaker speaker1, Speaker speaker2)
		{
			return speaker1.Name == speaker2.Name;
		}
		
    		public int GetHashCode(Speaker speaker)
    		{
			return speaker.Name.GetHashCode();
		}
	}
}
