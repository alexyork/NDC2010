using System;
using System.Linq;
using NUnit.Framework;

namespace NDC2010.Tests.SpeakersPresenterTests
{
	[TestFixture]
	public class Getting_all_speakers : SpeakersPresenterTestBase
	{
		[SetUp]
		public void SetUp()
		{
			SetupPresenterAndMocks();
		}
		
		/*
		[Test]
		public void Should_return_all_speakers()
		{
			Presenter.GetAllSpeakers().Count().ShouldBe(15);
		}
		
		// TODO: test distinctness, and ordering
		
		[Test]
		public void Should_return_distinct_speakers()
		{
			Presenter.GetAllSpeakers().Count().ShouldBe(1);
		}
		*/
	}
}