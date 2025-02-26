using UnityEngine;
using Xlab.States;

namespace Xlab
{
    public class GameOverState : GameStateBehaviour
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
