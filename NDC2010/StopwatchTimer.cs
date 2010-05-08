using System;
using System.Diagnostics;

namespace NDC2010
{
	public class StopwatchTimer : IDisposable
	{
		private string _message;
		private Stopwatch _timer;
		
		public StopwatchTimer(string message)
		{
			_message = message;
			_timer = new Stopwatch();
			_timer.Start();
		}
	
	   public void Dispose()
	   {
			_timer.Stop();
			Console.WriteLine(_message + ": " + _timer.ElapsedMilliseconds + " ms");
			GC.SuppressFinalize(this);
	   }
	}
}
