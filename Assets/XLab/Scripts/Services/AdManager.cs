using System.Collections.Generic;

namespace Xlab
{
	public enum AdStatus
	{
		Canceled, Complete
	}

	public interface IAdProvider
	{
		void Init();

		void ShowVideoAd(System.Action<AdStatus> onWatchComplete);
	}



	public class AdManager
	{
		private IAdProvider m_provider;

		public void Init()
		{
#if UNITY_EDITOR
			m_provider = new UnityEditorAdProvider();
#elif UNITY_ANDROID
			m_provider = new GoogleAdProvider();
#else
			Debug.Log("");
#endif

			m_provider?.Init();
		}

		public void ShowVideoAd(System.Action<AdStatus> onWatchComplete)
		{
			if (m_provider != null)
			{
				m_provider.ShowVideoAd(onWatchComplete);
			}
		}
	}
}
