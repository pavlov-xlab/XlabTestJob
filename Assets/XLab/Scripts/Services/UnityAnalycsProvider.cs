using System.Collections.Generic;

namespace Xlab
{
	public class UnityAnalyticsProvider : IAnalyticsProvider
	{
		public void Init()
		{
			UnityEngine.Analytics.Analytics.enabled = true;
		}

		public void SendEvent(string eventName)
		{
			UnityEngine.Analytics.Analytics.SendEvent(eventName, null);
		}

		public void SendEvent(string eventName, Dictionary<object, object> data)
		{
			UnityEngine.Analytics.Analytics.SendEvent(eventName, data);
		}
	}
}