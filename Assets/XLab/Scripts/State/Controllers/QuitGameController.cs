
using System.Collections.Generic;
using UnityEngine;

namespace Xlab.States.Controllers
{
	public class QuitGameController : MonoBehaviour
	{
		public GameplayState gameplayState;

		public void Quit()
		{
			if (!gameObject.activeSelf)
			{
				return;
			}


			if (gameplayState)
			{
				gameplayState.SavePlayerState();
				GameController.instance.SavePlayerData();
			}

			if (Application.isEditor)
			{
				UnityEditor.EditorApplication.isPlaying = false;
			}
			else
			{
				Application.Quit();
			}
		}
	}
}
