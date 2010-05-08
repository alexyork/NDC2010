using System;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using NDC2010.Model;
using NDC2010.Logic;

namespace NDC2010.Tests
{
	[TestFixture]
	public class Creating_a_FriendlyDateTime
	{
		[Test]
		public void Should_return_empty_string_for_invalid_dates()
		{
			var dateInThePast = new DateTime(2010, 02, 02, 02, 02, 02, 02);
			var dateNow = new DateTime(2010, 01, 01, 01, 01, 01, 01);
			
			var result = FriendlyDateTime.Get(dateInThePast, dateNow);
			
			result.ShouldBe("");
		}
		
		[Test]
		public void Should_work_for_5_months_ago()
		{
			var dateInThePast = new DateTime(2010, 01, 01, 01, 01, 01, 01);
			var dateNow = new DateTime(2010, 06, 01, 01, 01, 01, 01);
			
			var result = FriendlyDateTime.Get(dateInThePast, dateNow);
			
			result.ShouldBe("5 months ago");
		}
		
		[Test]
		public void Should_work_for_26_days_ago()
		{
			var dateInThePast = new DateTime(2010, 01, 01, 01, 01, 01, 01);
			var dateNow = new DateTime(2010, 01, 27, 01, 01, 01, 01);
			
			var result = FriendlyDateTime.Get(dateInThePast, dateNow);
			
			result.ShouldBe("26 days ago");
		}
		
		[Test]
		public void Should_work_for_yesterday()
		{
			var dateInThePast = new DateTime(2010, 01, 01, 01, 01, 01, 01);
			var dateNow = new DateTime(2010, 01, 02, 01, 01, 01, 01);
			
			var result = FriendlyDateTime.Get(dateInThePast, dateNow);
			
			result.ShouldBe("yesterday");
		}
		
		[Test]
		public void Should_work_for_22_hours_ago()
		{
			var dateInThePast = new DateTime(2010, 01, 01, 01, 01, 01, 01);
			var dateNow = new DateTime(2010, 01, 01, 23, 01, 01, 01);
			
			var result = FriendlyDateTime.Get(dateInThePast, dateNow);
			
			result.ShouldBe("22 hours ago");
		}
		
		[Test]
		public void Should_work_for_1_hour_ago()
		{
			var dateInThePast = new DateTime(2010, 01, 01, 01, 01, 01, 01);
			var dateNow = new DateTime(2010, 01, 01, 02, 01, 01, 01);
			
			var result = FriendlyDateTime.Get(dateInThePast, dateNow);
			
			result.ShouldBe("an hour ago");
		}
		
		[Test]
		public void Should_work_for_58_minutes_ago()
		{
			var dateInThePast = new DateTime(2010, 01, 01, 01, 01, 01, 01);
			var dateNow = new DateTime(2010, 01, 01, 01, 59, 01, 01);
			
			var result = FriendlyDateTime.Get(dateInThePast, dateNow);
			
			result.ShouldBe("58 mins ago");
		}
		
		[Test]
		public void Should_work_for_1_minute_ago()
		{
			var dateInThePast = new DateTime(2010, 01, 01, 01, 01, 01, 01);
			var dateNow = new DateTime(2010, 01, 01, 01, 02, 01, 01);
			
			var result = FriendlyDateTime.Get(dateInThePast, dateNow);
			
			result.ShouldBe("1 min ago");
		}
		
		[Test]
		public void Should_work_for_0_minutes_ago()
		{
			var dateInThePast = new DateTime(2010, 01, 01, 01, 01, 01, 01);
			var dateNow = new DateTime(2010, 01, 01, 01, 01, 59, 59);
			
			var result = FriendlyDateTime.Get(dateInThePast, dateNow);
			
			result.ShouldBe("1 min ago");
		}
	}
}
