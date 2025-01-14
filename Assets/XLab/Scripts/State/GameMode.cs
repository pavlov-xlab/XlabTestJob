
using UnityEngine;

namespace Xlab.States
{
	public class GameMode : MonoBehaviour
	{
		private StateActivator m_stateActivator;

		private void Awake()
		{
			m_stateActivator = new StateActivator();
		}

		private void Start()
		{
			var states = GetComponentsInChildren<IGameState>(true);
			foreach (var state in states)
			{
				m_stateActivator.Add(state);
			}

			m_stateActivator.Add(new PauseState());


			m_stateActivator.Activate<GameplayState>();
		}

		private void OnDestroy()
		{
			m_stateActivator.current.Deactivate();
			m_stateActivator.current.Exit();
		}

		public void Back()
		{
			m_stateActivator.Back();
		}

		public void GotoPause()
		{
			m_stateActivator.Push<PauseState>();
		}

		public void GotoGameplay()
		{
			m_stateActivator.Activate<GameplayState>();
		}

		public void GotoSettings()
		{
			m_stateActivator.Push<SettingsState>();
		}
	}
}