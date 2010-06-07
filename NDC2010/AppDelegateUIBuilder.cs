using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace NDC2010
{
	public partial class AppDelegate
	{
		// Containers
		private UIWindow window;
		private UITabBarController tabBarController;
		
		// Sessions
		private UINavigationController sessionsNavigationController;
		private DaysTableViewController daysTableViewController;
		
		// Speakers
		private NDC2010NavigationController speakersNavigationController;
		private SpeakersTableViewController speakersTableViewController;
		
		// My Schedule
		private NDC2010NavigationController myScheduleNavigationController;
		private MyScheduleTableViewController myScheduleTableViewController;
		
		// Twitter
		private NDC2010NavigationController twitterNavigationController;
		private TwitterTableViewController twitterTableViewController;
		
		private void InitializeWindow()
		{
			window = new UIWindow(UIScreen.MainScreen.Bounds);
			window.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("Images/background.png"));
		}
		
		private void InitializeMainViewControllers()
		{
			InitializeSessionsTab();
			InitializeSpeakersTab();
			InitializeMyScheduleTab();
			InitializeTwitterTab();
		}
		
		private void InitializeSessionsTab()
		{
			daysTableViewController = new DaysTableViewController();
			
			sessionsNavigationController = new NDC2010NavigationController();
			sessionsNavigationController.TabBarItem = new UITabBarItem("Sessions", UIImage.FromFile("Sessions/TabIcon.png"), 0);
			sessionsNavigationController.PushViewController(daysTableViewController, false);
		}
		
		private void InitializeSpeakersTab()
		{
			speakersTableViewController = new SpeakersTableViewController();
			
			speakersNavigationController = new NDC2010NavigationController();
			speakersNavigationController.TabBarItem = new UITabBarItem("Speakers", UIImage.FromFile("Speakers/TabIcon.png"), 0);
			speakersNavigationController.PushViewController(speakersTableViewController, false);
		}
		
		private void InitializeMyScheduleTab()
		{
			myScheduleTableViewController = new MyScheduleTableViewController();
			
			myScheduleNavigationController = new NDC2010NavigationController();
			myScheduleNavigationController.TabBarItem = new UITabBarItem("My Schedule", UIImage.FromFile("MySchedule/TabIcon.png"), 0);
			myScheduleNavigationController.PushViewController(myScheduleTableViewController, false);
		}
		
		private void InitializeTwitterTab()
		{
			twitterTableViewController = new TwitterTableViewController();
			
			twitterNavigationController = new NDC2010NavigationController();
			twitterNavigationController.TabBarItem = new UITabBarItem("Twitter", UIImage.FromFile("Twitter/TabIcon.png"), 0);
			twitterNavigationController.PushViewController(twitterTableViewController, false);
		}
		
		private void InitializeTabController()
		{
			tabBarController = new UITabBarController();
			tabBarController.SelectedIndex = 0;
			tabBarController.ViewControllers = new UIViewController[] 
				{
					sessionsNavigationController,
					speakersNavigationController,
					myScheduleNavigationController,
					twitterNavigationController
				};
			
			window.AddSubview(tabBarController.View);
		}
	}
}