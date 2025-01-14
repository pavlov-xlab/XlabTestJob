
using System.Collections.Generic;
using UnityEngine;

namespace Xlab.States
{
	public class GameStateBehaviour : MonoBehaviour, IGameState
	{
		private List<IController> m_controllers = new List<IController>();

		private void Awake()
		{
			GetComponentsInChildren(m_controllers);
		}

		public void Enter()
		{
			gameObject.SetActive(true);

			OnEnter();
		}

		public void Exit()
		{
			OnExit();

			gameObject.SetActive(false);
		}

		public void Activate()
		{
			OnActivate();
			m_controllers.ForEach(controller => controller.Activate());
		}

		public void Deactivate()
		{
			m_controllers.ForEach(controller => controller.Deactivate());
			OnDeactivate();
		}

		protected virtual void OnEnter()
		{
		}

		protected virtual void OnExit()
		{
		}

		protected virtual void OnActivate()
		{
		}

		protected virtual void OnDeactivate()
		{
		}


	}
}
