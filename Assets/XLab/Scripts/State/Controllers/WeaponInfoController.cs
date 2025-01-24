using System;
using UnityEngine;

namespace Xlab
{
    public class WeaponInfoController : MonoBehaviour
    {
		[SerializeField] private UIWeaponBar m_weaponBar;
		private WeaponManager m_weaponManager;

		public void Init(WeaponManager weaponManager)
		{
			m_weaponManager = weaponManager;
		}

		private void OnEnable()
		{
			if (m_weaponManager)
			{
				m_weaponManager.onChangeWeapon += OnChangeWeapon;
				m_weaponManager.onShoot += OnShoot;
				m_weaponManager.onReload += OnShoot;
				OnChangeWeapon();
			}
		}


		private void OnDisable()
		{
			if (m_weaponManager)
			{
				m_weaponManager.onChangeWeapon -= OnChangeWeapon;
				m_weaponManager.onShoot -= OnShoot;
				m_weaponManager.onReload -= OnShoot;
			}
		}
		private void OnShoot()
		{
			RefreshBulletInfo(m_weaponManager.currentWeapon);
		}

		private void OnChangeWeapon()
		{
			var curWeapon = m_weaponManager.currentWeapon;
			if (curWeapon)
			{
				m_weaponBar.SetIcon(curWeapon.weaponDataSO.icon);
			}
			
			RefreshBulletInfo(curWeapon);
		}

		private void RefreshBulletInfo(Weapon weapon)
		{
			if (weapon)
			{
				m_weaponBar.SetBulletInfo(weapon.curCage, weapon.cageSize);
			}
			else
			{
				m_weaponBar.SetBulletInfo(0, 0);
			}
		}
    }
}
