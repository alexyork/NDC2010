using System;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using NDC2010.Model;
using NDC2010.Model.MySchedule;
using NDC2010.Logic.Managers;

namespace NDC2010
{
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		public List<Session> Sessions { get; set; }
		public MyScheduleManager MyScheduleManager { get; set; }
		
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			InitializeWindow();
			
			// TODO: put this in a thread when the UI is blocked
			Sessions = SessionsOnDisk.GetAll();
			MyScheduleManager = new MyScheduleManager(new ScheduleTextFileRepository(), Sessions);
			MyScheduleManager.SetSelectedSessions();
			
			InitializeMainViewControllers();
			InitializeTabController();
			
			window.MakeKeyAndVisible();
			return true;
		}
		
		public override void OnActivated(UIApplication application)
		{
			Console.WriteLine("OnActivated");
		}
		
		public override void ReceiveMemoryWarning(UIApplication application)
		{
			Console.WriteLine("ReceiveMemoryWarning");
		}
	}
	
	public class NDC2010Application
	{
		public static void Main(string[] args)
		{
			UIApplication.Main(args, null, "AppDelegate");
		}
	}
}