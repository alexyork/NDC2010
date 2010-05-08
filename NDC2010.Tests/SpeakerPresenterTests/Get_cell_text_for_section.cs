using System;
using NUnit.Framework;

namespace NDC2010.Tests.SpeakerPresenterTests
{
	[TestFixture]
	public class Get_cell_text_for_section : SpeakerPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		[Test]
		public void Should_return_speaker_name_for_section_0()
		{
			Presenter.GetCellTextForSection(0).ShouldBe(MockSpeaker.Name);
		}
		
		[Test]
		public void Should_return_speaker_bio_for_section_1()
		{
			Presenter.GetCellTextForSection(1).ShouldBe(MockSpeaker.Info);
		}
		
		[ExpectedException]
		public void Should_throw_exception_for_section_2()
		{
			var result = Presenter.GetCellTextForSection(2);
		}
		
		[ExpectedException]
		public void Should_throw_exception_for_section_minus1()
		{
			var result = Presenter.GetCellTextForSection(-1);
		}
	}
}