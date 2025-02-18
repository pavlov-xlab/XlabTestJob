using System;
using System.Collections.Generic;
using Unity.Cinemachine.Samples;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Xlab
{
    public class PlayerController : MonoBehaviour
    {
        public InputActionAsset actions;
        public AimCameraRig aimCameraRig;
		public WeaponDB weaponDB;
        public GameObject player;

        private WeaponManager m_weaponManager;

		public Inventory inventory;

		void Start()
		{
			inventory = GameController.instance.player.inventory.Clone();

			var aimAction = actions.FindAction("Player/Fire2");
			aimAction.started += OnAimStarted;
			aimAction.canceled += OnAimCanceled;

			var fireAction = actions.FindAction("Player/Fire");
			fireAction.started += OnFireStarted;
			fireAction.canceled += OnFireCanceled;

			var nextWeaponAction = actions.FindAction("Player/NextWeapon");
			nextWeaponAction.performed += OnNextWeapon;

			var reloadWeaponAction = actions.FindAction("Player/Reload");
			reloadWeaponAction.performed += OnReloadWeapon;

			actions.Enable();

			bool result = player.TryGetComponent(out m_weaponManager);
			Debug.Assert(result, "WeaponManager not found!");

			if (player.TryGetComponent<PickupDetecter>(out var pickupDetecter))
			{
				pickupDetecter.onPickupObjectDetect += OnPickupObjectDetect;
			}

			foreach (var slot in inventory.slots)
			{
				if (!string.IsNullOrEmpty(slot.item))
				{
					WeaponDataSO data = weaponDB.GetWeapon(slot.item);
					if (data)
					{
						m_weaponManager.AddWeapon(data);
					}
				}
			}
		}

		private void OnPickupObjectDetect(PickupObject pickupObject)
		{
			var weaponData = pickupObject.weaponData;

			if (inventory.Exist(weaponData.id))
			{
				return;
			}

			Analytics.SendEvent("PickUpWeapon", new Dictionary<object, object>()
			{
				{"id", weaponData.id },
				{ "", "" }
			});

			inventory.AddItemInNextSlot(weaponData.id);
			m_weaponManager.AddWeapon(weaponData);
			m_weaponManager.NextWeapon();

			GameObject.Destroy(pickupObject.gameObject);
		}

		private void OnReloadWeapon(InputAction.CallbackContext context)
        {
            m_weaponManager.Reload();
        }

        private void OnDestroy()
        {
            var aimAction = actions.FindAction("Player/Fire2");
            aimAction.started -= OnAimStarted;
            aimAction.canceled -= OnAimCanceled;
            
            var fireAction = actions.FindAction("Player/Fire");
            fireAction.started -= OnFireStarted;
            fireAction.canceled -= OnFireCanceled;

            var nextWeaponAction = actions.FindAction("Player/NextWeapon");
            nextWeaponAction.performed -= OnNextWeapon;

            var reloadWeaponAction = actions.FindAction("Player/Reload");
            reloadWeaponAction.performed -= OnReloadWeapon;

            actions.Disable();
        }

        private void OnNextWeapon(InputAction.CallbackContext context)
        {
            m_weaponManager.NextWeapon();
        }

        private void OnFireCanceled(InputAction.CallbackContext context)
        {
            m_weaponManager.StopFire();
        }

        private void OnFireStarted(InputAction.CallbackContext context)
        {
            m_weaponManager.StartFire();
        }

        private void OnAimCanceled(InputAction.CallbackContext context)
        {
            aimCameraRig.IsAiming = false;
        }

        private void OnAimStarted(InputAction.CallbackContext context)
        {
            aimCameraRig.IsAiming = true;
        }
    }
}