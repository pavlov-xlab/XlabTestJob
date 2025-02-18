using System.Collections.Generic;

namespace Xlab
{
	public interface IAnalyticsProvider
	{
		void Init();
		void SendEvent(string eventName);
		void SendEvent(string eventName, Dictionary<object, object> data);
	}



	public static class Analytics
	{
		private static List<IAnalyticsProvider> m_providers = new List<IAnalyticsProvider>();

		public static void Init()
		{
#if USE_ANALYTICS
			m_providers.Add(new UnityAnalyticsProvider());
#endif
			// m_providers.Add(new UnityAnalyticsProvider());

			m_providers.ForEach(x => x.Init());
		}

		public static void SendEvent(string eventName)
		{
			m_providers.ForEach(x => x.SendEvent(eventName));
		}

		public static void SendEvent(string eventName, Dictionary<object, object> data)
		{
			m_providers.ForEach(x => x.SendEvent(eventName, data));
		}
	}
}