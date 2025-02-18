using System.Threading.Tasks;
using UnityEngine;
using UnityDebug = UnityEngine.Debug;

namespace Xlab
{
	public class UnityEditorAdProvider : IAdProvider
	{
		private System.Action<AdStatus> onWatchCompleteCallback;


		public void Init()
		{

		}

		public void ShowVideoAd(System.Action<AdStatus> onWatchComplete)
		{
			UnityDebug.Log("ShowVideoAd - start");

			onWatchCompleteCallback = onWatchComplete;

			if (Random.value > 0.5f)
			{
				Wait();
			}
			else
			{
				UnityDebug.Log("ShowVideoAd - cancel");
				onWatchCompleteCallback?.Invoke(AdStatus.Canceled);
				onWatchCompleteCallback = null;
			}
		}

		private async void Wait()
		{
			UnityDebug.Log("ShowVideoAd - wait...");
			await Task.Delay(1000);
			UnityDebug.Log("ShowVideoAd - complete");

			onWatchCompleteCallback?.Invoke(AdStatus.Complete);
			onWatchCompleteCallback = null;
		}
	}
}