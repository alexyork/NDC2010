using System;
using MonoTouch.UIKit;

namespace NDC2010
{
	public class NetworkActivity : IDisposable
	{
	   public NetworkActivity()
	   {
			UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
	   }
	
	   public void Dispose()
	   {
			UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
			GC.SuppressFinalize(this);
	   }
	}
}