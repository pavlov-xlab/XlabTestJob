
using System.Collections.Generic;
using UnityEngine;

namespace Xlab.States
{
	public class GameStateBehaviour : MonoBehaviour, IGameState
	{
		void IGameState.Enter()
		{
			OnEnter();
		}

		void IGameState.Exit()
		{
			OnExit();
		}

		void IGameState.Activate()
		{
			gameObject.SetActive(true);
		}

		void IGameState.Deactivate()
		{
			gameObject.SetActive(false);
		}

		protected virtual void OnEnter()
		{
		}

		protected virtual void OnExit()
		{
		}
	}
}
