using DG.Tweening;
using UnityEngine;

namespace Xlab
{
	[DefaultExecutionOrder(100)]
	public class GameController : MonoBehaviour
	{
		private static GameController m_instance;
		public static GameController instance
		{
			get
			{
				if (m_instance == null)
				{
					m_instance = FindAnyObjectByType<GameController>();
				}
				return m_instance;
			}
		}

		public AdManager adManager { private set; get; } = new AdManager();
		public PlayerData player { private set; get; } = new PlayerData();
		[field: SerializeField] public ItemsDB itemsDB { private set; get; }


		private void Awake()
		{
			if (m_instance == null)
			{
				m_instance = this;
			}

			if (m_instance != this)
			{
				Destroy(gameObject);
				return;
			}

			DontDestroyOnLoad(gameObject);

			// LoadPlayerData();

			Analytics.Init();
			adManager.Init();
		}

		public static void QuitGame()
		{
			if (Application.isEditor)
			{
				UnityEditor.EditorApplication.isPlaying = false;
			}
			else
			{
				Application.Quit();
			}
		}

		public void SavePlayerData()
		{
			PlayerDataProc.SavePlayer(player);
		}

		public void LoadPlayerData()
		{
			PlayerDataProc.LoadPlayer(player);
		}

		private void OnApplicationPause(bool pauseStatus)
		{
			Debug.Log($"[GameManager]: OnApplicationPause({pauseStatus})");
		}

		private void OnApplicationFocus(bool focusStatus)
		{
			Debug.Log($"[GameManager]: OnApplicationFocus({focusStatus})");
		}

		private void OnApplicationQuit()
		{
			Debug.Log($"[GameManager]: OnApplicationQuit()");

			SavePlayerData();
		}
	}
}