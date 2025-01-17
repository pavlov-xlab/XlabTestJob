using UnityEngine;

namespace Xlab.States
{
    public interface IGameState
    {
        void Enter();
        void Activate();
        void Deactivate();
        void Exit();
    }
}
