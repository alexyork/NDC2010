using System;
using NDC2010.Model;

namespace NDC2010.Logic.Presenters
{
	public class SpeakerPresenter
	{
		public Speaker Speaker { get; set; }
		
		public SpeakerPresenter()
		{
		}
		
		// TODO: rename and refactor this: the presenters shouldnt be aware of "sections"
		public string GetSectionHeadingText(int section)
		{
			switch (section)
			{
				case 0:
					return "Name";
				case 1:
					return "Bio";
				case 2:
					return "Sessions";
				default:
					throw new Exception("No heading text for section " + section);
			}
		}
		
		// TODO: rename and refactor this: the presenters shouldnt be aware of "sections"
		public string GetCellTextForSection(int section)
		{
			switch (section)
			{
				case 0:
					return Speaker.Name;
				case 1:
					return Speaker.Info;
				default:
					throw new Exception("Cannot get cell text for section " + section);
			}
		}
	}
}