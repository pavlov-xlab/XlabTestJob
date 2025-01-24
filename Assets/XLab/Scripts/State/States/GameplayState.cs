
using System.Collections.Generic;
using UnityEngine;

namespace Xlab.States
{
    public class GameplayState : GameStateBehaviour
	{
		[SerializeField] private GameObject m_player;

		private void Awake()
		{
			if (TryGetComponent<HealthController>(out var health))
			{
				health.Init(m_player.GetComponent<HealthComponent>());
			}

			if (TryGetComponent<WeaponInfoController>(out var weapon))
			{
				weapon.Init(m_player.GetComponent<WeaponManager>());
			}
		}

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }
    }
}
