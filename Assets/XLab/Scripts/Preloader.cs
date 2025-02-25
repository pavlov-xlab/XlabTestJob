using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Xlab
{
	public class Preloader : MonoBehaviour
	{
		[SerializeField] private Image m_progressBar;

		private IEnumerator Start()
		{
			m_progressBar.fillAmount = 0;

			while (GameController.instance == null)
			{
				yield return 0;
			}

			m_progressBar.fillAmount = 0.5f;

			GameController.instance.LoadPlayerData();

			yield return 0;

			m_progressBar.fillAmount = 1f;

			yield return 0;

			SceneManager.LoadScene("MainMenu");

			yield break;
		}
	}
}
