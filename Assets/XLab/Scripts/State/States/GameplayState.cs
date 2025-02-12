
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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

		private void Start()
		{
			var playerState = GameController.instance.player.lastPlayerState;
			
			if (playerState.valid)
			{
				m_player.transform.SetPositionAndRotation(playerState.pos, Quaternion.Euler(playerState.rot));

				if (m_player.TryGetComponent<HealthComponent>(out var hp))
				{
					hp.Init(playerState.hp);
				}
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

			SavePlayerState();
		}

		private void SavePlayerState()
		{
			var pos = m_player.transform.position;
			var rot = m_player.transform.eulerAngles;

			var playerState = GameController.instance.player.lastPlayerState;
			playerState.valid = true;
			playerState.pos = m_player.transform.position;
			playerState.rot = m_player.transform.eulerAngles;

			if (m_player.TryGetComponent<HealthComponent>(out var hp))
			{
				playerState.hp = hp.hp;
			}
		}
	}
}
