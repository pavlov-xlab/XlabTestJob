using System.Collections.Generic;
using UnityEngine;

namespace Xlab.WFSM
{
    public enum WeaponStateEnum { Idle, Fire, Reload, Empty }

    public interface IWeaponState
    {
        void Enter();
        void Exit();
        void StartFire();
        void StopFire();
        void Reload();
        void Update();
    }

    public class WeaponFSM
    {
        private IWeaponState m_currentState;
        private Dictionary<WeaponStateEnum, IWeaponState> m_states = new Dictionary<WeaponStateEnum, IWeaponState>();

        public WeaponFSM(Weapon context)
        {
            m_states.Add(WeaponStateEnum.Idle, new WeaponStateIdle(this, context));
            m_states.Add(WeaponStateEnum.Fire, new WeaponStateFire(this, context));
            m_states.Add(WeaponStateEnum.Reload, new WeaponStateReload(this, context));
            m_states.Add(WeaponStateEnum.Empty, new WeaponStateEmpty(this));
        }

        public void ActivateState(WeaponStateEnum state)
        {
            Debug.Log($"FSM > activate: {state}");
            if (m_currentState != null)
            {
                m_currentState.Exit();
                m_currentState = null;
            }


            if (m_states.TryGetValue(state, out m_currentState))
            {
                m_currentState.Enter();
            }
        }

        public void StartFire()
        {
            m_currentState?.StartFire();
        }

        public void StopFire() 
        {
            m_currentState?.StopFire();
        }
        
        public void Reload() 
        {
            m_currentState?.Reload();
        }
        
        public void Update() 
        {
            m_currentState?.Update();
        }
    }


    public abstract class WeaponStateBase : IWeaponState
    {
        public virtual void Enter() {}

        public virtual void Exit()
        {
        }

        public virtual void Reload()
        {            
        }

        public virtual void StartFire() {}

        public virtual void StopFire()
        {            
        }

        public virtual void Update()
        {            
        }
    }

    public class WeaponStateIdle : WeaponStateBase
    {
        private readonly WeaponFSM m_weaponFSM;
        private readonly Weapon m_context;

        public WeaponStateIdle(WeaponFSM weaponFSM, Weapon context)
        {
            m_weaponFSM = weaponFSM;
            m_context = context;
        }

        public override void Reload()
        {
            m_weaponFSM.ActivateState(WeaponStateEnum.Reload);
        }

        public override void StartFire()
        {
            if (m_context.CanFire())
            {
                m_weaponFSM.ActivateState(WeaponStateEnum.Fire);
            }
        }
    }

    public class WeaponStateFire : WeaponStateBase
    {
        private float m_timer;

        private readonly WeaponFSM m_weaponFSM;
        private readonly Weapon m_context;

        public WeaponStateFire(WeaponFSM weaponFSM, Weapon context)
        {
            m_weaponFSM = weaponFSM;
            m_context = context;
        }

        override public void Enter()
        {
            m_timer = 0f;
            m_context.Shoot();
        }

        public override void Update()
        {
            m_timer += Time.deltaTime;
            if (m_timer >= m_context.weaponDataSO.delay)
            {
                if (!m_context.hasBullet && m_context.weaponDataSO.autoReload)
                {
                    m_weaponFSM.ActivateState(WeaponStateEnum.Reload);
                }
                else if (m_context.weaponDataSO.autoFire)
                {
                    if (m_context.CanFire())
                    {
                        m_context.Shoot();
                    }

                    if (m_context.CanFire())
                    {
                        m_timer = 0;
                    }                    
                    else
                    {
                        m_weaponFSM.ActivateState(WeaponStateEnum.Empty);
                    }
                }
                else 
                {
                    StopFire();
                }
            }
        }

        public override void StopFire()
        {
            m_weaponFSM.ActivateState(WeaponStateEnum.Idle);
        }
    }

    public class WeaponStateReload : WeaponStateBase
    {
        private float m_timer;

        private readonly WeaponFSM m_weaponFSM;
        private readonly Weapon m_context;

        public WeaponStateReload(WeaponFSM weaponFSM, Weapon context)
        {
            m_weaponFSM = weaponFSM;
            m_context = context;
        }

        override public void Enter()
        {
            m_timer = 0f;
        }

        public override void Update()
        {
            m_timer += Time.deltaTime;
            if (m_timer >= m_context.weaponDataSO.reloadDelay)
            {
                m_context.ReloadComplete();
                m_weaponFSM.ActivateState(WeaponStateEnum.Idle);
            }
        }
    }

    public class WeaponStateEmpty : WeaponStateBase
    {
        private readonly WeaponFSM m_weaponFSM;

        public WeaponStateEmpty(WeaponFSM weaponFSM)
        {
            m_weaponFSM = weaponFSM;
        }

        //public override void Reload()
        //{
        //    m_weaponFSM.ActivateState(WeaponStateEnum.Reload);
        //}
    }
}
