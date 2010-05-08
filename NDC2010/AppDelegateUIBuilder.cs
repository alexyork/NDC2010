using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace NDC2010
{
	public partial class AppDelegate
	{
		private void InitializeWindow()
		{
			window = new UIWindow(UIScreen.MainScreen.Bounds);
			window.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("Images/background.png"));
		}
		
		private void InitializeMainViewControllers()
		{
			InitializeSessionsTab();
			InitializeSpeakersTab();
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
		
		private void InitializeTwitterTab()
		{
			twitterTableViewController = new TwitterTableViewController();
			
			twitterNavigationController = new NDC2010NavigationController();
			twitterNavigationController.TabBarItem = new UITabBarItem("Twitter", UIImage.FromFile("Twitter/TabIcon.png"), 0);
			twitterNavigationController.PushViewController(twitterTableViewController, false);
		}
		
		private void InitializeScheduleTab()
		{
			scheduleTableViewController = new UITableViewController();
			
			scheduleNavigationController = new NDC2010NavigationController();
			scheduleNavigationController.TabBarItem = new UITabBarItem("Speakers", UIImage.FromFile("Speakers/TabIcon.png"), 0);
			scheduleNavigationController.PushViewController(scheduleTableViewController, false);
		}
		
		private void InitializeTabController()
		{
			tabBarController = new UITabBarController();
			tabBarController.SelectedIndex = 0;
			tabBarController.ViewControllers = new UIViewController [] 
				{
					sessionsNavigationController,
					speakersNavigationController,
					twitterNavigationController
				};
			
			window.AddSubview(tabBarController.View);
		}
	}
}