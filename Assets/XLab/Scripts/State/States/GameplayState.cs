
using System.Collections.Generic;
using UnityEngine;

namespace Xlab.States
{
    public class GameplayState : GameStateBehaviour
	{
		[SerializeField] private GameObject m_player;

		private void Awake()
		{
			var playerHP = m_player.GetComponent<HealthComponent>();

			if (TryGetComponent<HealthController>(out var health))
			{
				health.Init(playerHP);
			}

			if (TryGetComponent<FXDamageController>(out var fxDamage))
			{
				fxDamage.Init(playerHP);
			}

			if (TryGetComponent<WeaponInfoController>(out var weapon))
			{
				weapon.Init(m_player.GetComponent<WeaponManager>());
			}
		}

        private void OnEnable()
        {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;

		}

        private void OnDisable()
        {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
    }
}
