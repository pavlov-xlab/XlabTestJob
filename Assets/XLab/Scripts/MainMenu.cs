using UnityEngine;
using UnityEngine.SceneManagement;

namespace Xlab
{
	public class MainMenu : MonoBehaviour
	{
		public GameObject continueBtn;

		private void Start()
		{
			continueBtn.SetActive(GameController.instance.player.lastPlayerState.valid);
		}

		public void OnContinueClick()
		{
			SceneManager.LoadScene("Level");
		}

		public void OnNewGameClick()
		{
			GameController.instance.player.Reset();
			OnContinueClick();
		}

		public void OnQuitClick()
		{
			GameController.QuitGame();
		}

		public void OnSettingsClick()
		{

		}
	}
}
