
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Xlab.States
{
	public class PauseState : GameStateBehaviour
	{
        protected override void OnEnter()
        {            
        	Time.timeScale = 0f;
		}

		protected override void OnExit()
		{
			Time.timeScale = 1f;
		}

		public void OnRestartClick()
		{
			GameController.instance.adManager.ShowVideoAd(status=>
			{
				if (status == AdStatus.Complete)
				{
					RestartScene();
				}
				else
				{

				}
			});
			
		}

		private static void RestartScene()
		{
			var scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene("Empty");
			SceneManager.LoadScene(scene.name);
		}
	}
}
