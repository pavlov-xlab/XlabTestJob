
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

			// GameController.QuitGame();
			SceneManager.LoadScene("MainMenu");
		}
	}
}
