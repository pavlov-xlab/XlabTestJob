
using System.Collections.Generic;
using UnityEngine;

namespace Xlab.States
{
	public class StateActivator
	{
		private List<IGameState> m_states = new();
		private IGameState m_current;
		private List<IGameState> m_stack = new();

		public IGameState current => m_current;

		public void Add(IGameState state)
		{
			m_states.Add(state);
		}

		public void Activate<T>()
		{
			var state = m_states.Find(state=> state is T);
			if (state != null)
			{
				Swap(m_current, state);
			}
		}

		public void Push<T>()
		{
			var state = m_states.Find(state => state is T);
			if (state != null)
			{
				m_stack.Add(m_current);
				PushState(m_current, state);
			}
		}

		public void Back()
		{
			Debug.Log("StateActivator.TryBack");
			if (m_stack.Count > 0)
			{
				m_current.Deactivate();
				m_current.Exit();

				var nextState = m_stack[m_stack.Count - 1];
				m_stack.RemoveAt(m_stack.Count-1);
				nextState.Activate();
				m_current = nextState;
			}
		}

		private void PushState(IGameState prevState, IGameState nextState)
		{
			Debug.Log($"StateActivator.Push - prevState: {prevState} => nextState: {nextState}");
			if (prevState != null)
			{
				prevState.Deactivate();
			}

			m_current = nextState;

			if (nextState != null)
			{
				nextState.Enter();
				nextState.Activate();
			}
		}

		private void Swap(IGameState prevState, IGameState nextState)
		{
			Debug.Log($"StateActivator.Swap - prevState: {prevState} => nextState: {nextState}");
			if (prevState != null)
			{
				prevState.Exit();
				prevState.Deactivate();
			}

			m_current = nextState;

			if (nextState != null)
			{
				nextState.Enter();
				nextState.Activate();
			}
		}
	}
}
