using System;
using Unity.Cinemachine.Samples;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Xlab
{
    public class PlayerController : MonoBehaviour
    {
        public InputActionAsset actions;
        public AimCameraRig aimCameraRig;
        public GameObject player;

        private WeaponManager m_weaponManager;
        
        void Start()
        {
            var aimAction = actions.FindAction("Player/Fire2");
            aimAction.started += OnAimStarted;
            aimAction.canceled += OnAimCanceled;
            
            var fireAction = actions.FindAction("Player/Fire");
            fireAction.started += OnFireStarted;
            fireAction.canceled += OnFireCanceled;

            var nextWeaponAction = actions.FindAction("Player/NextWeapon");
            nextWeaponAction.performed += OnNextWeapon;

            actions.Enable();

            bool result = player.TryGetComponent(out m_weaponManager);
            Debug.Assert(result, "WeaponManager not found!");
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