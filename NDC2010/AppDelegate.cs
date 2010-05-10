using System;
using System.Diagnostics;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using NDC2010.Model;

namespace NDC2010
{
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		public Session[] Sessions { get; set; }
		
		// Containers
		private UIWindow window;
		private UITabBarController tabBarController;
		
		// Sessions
		private UINavigationController sessionsNavigationController;
		private DaysTableViewController daysTableViewController;
		
		// Speakers
		private NDC2010NavigationController speakersNavigationController;
		private SpeakersTableViewController speakersTableViewController;
		
		// Twitter
		private NDC2010NavigationController twitterNavigationController;
		private TwitterTableViewController twitterTableViewController;
		
		// Schedule
		private NDC2010NavigationController scheduleNavigationController;
		private UITableViewController scheduleTableViewController;
		
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			InitializeWindow();
			
			Sessions = new DefaultSessionsRepository().GetAll();
			
			InitializeMainViewControllers();
			InitializeTabController();
			
			window.MakeKeyAndVisible();
			return true;
		}
		
		// This method is required in iPhoneOS 3.0
		public override void OnActivated(UIApplication application)
		{
		}
		
		public override void ReceiveMemoryWarning(UIApplication application)
		{
			Console.WriteLine("ReceiveMemoryWarning!");
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