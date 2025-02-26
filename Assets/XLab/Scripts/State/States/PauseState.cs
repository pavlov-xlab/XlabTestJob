
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
	}
}
