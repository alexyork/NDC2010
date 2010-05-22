using System;
using NDC2010.Model;

namespace NDC2010.Logic.Presenters
{
	public class SessionPresenter
	{
		public Session Session { get; set; }
		
		public SessionPresenter()
		{
		}
		
		// TODO: rename and refactor this: the presenters shouldnt be aware of "sections"
		public string GetCellTextForSection(int section)
		{
			string cellText;
			
			switch (section)
			{
				case 0:
					cellText = Session.Title;
					break;
				case 1:
					cellText = Session.Description;
					break;
				default:
					throw new Exception("Cannot get text for section " + section);
			}
			
			return string.IsNullOrEmpty(cellText) ? "TBA" : cellText;
		}
		
		// TODO: rename and refactor this: the presenters shouldnt be aware of "sections"
		public string GetSectionHeadingText(int section)
		{
			switch (section)
			{
				case 0:
					return "Title";
				case 1:
					return "Description";
				default:
					throw new Exception("Can't find text for section " + section);
			}
		}
		
		public string GetTitle()
		{
			return "Session";
		}
	}
}
