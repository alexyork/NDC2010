using System;
using NUnit.Framework;

namespace NDC2010.Tests.SessionPresenterTests
{
	[TestFixture]
	public class Getting_cell_text_for_section : SessionPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_session_title_for_section_0()
		{
			Presenter.GetCellTextForSection(0).ShouldBe(MockSession.Title);
		}
		
		[Test]
		public void Should_return_default_text_if_no_title_for_section_0()
		{
			MockSession.Title = "";
			Presenter.GetCellTextForSection(0).ShouldBe("TBA");
		}
		
		[Test]
		public void Should_return_session_description_for_section_1()
		{
			Presenter.GetCellTextForSection(1).ShouldBe(MockSession.Description);
		}
		
		[Test]
		public void Should_return_default_text_if_no_description_for_section_1()
		{
			MockSession.Description = "";
			Presenter.GetCellTextForSection(1).ShouldBe("TBA");
		}
	}
}
