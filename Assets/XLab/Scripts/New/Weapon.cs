using UnityEngine;
using Xlab.WFSM;

namespace Xlab
{

    public class Weapon : MonoBehaviour
    {
        public Transform m_muzzle;
        public WeaponDataSO weaponDataSO;

        private int m_cageSize = 0;
        private int m_bulletCount;
        private WeaponFSM m_weaponFSM;

		public int curCage => m_cageSize;
		public int cageSize => weaponDataSO.cageSize;
		public bool hasBullet => m_bulletCount > 0;

		public event System.Action onShoot;
		public event System.Action onReload;

		public bool CanFire()
        {
            return m_cageSize > 0;
        }

        private void Awake()
        {
            m_weaponFSM = new WeaponFSM(this);
			
			m_cageSize = weaponDataSO.cageSize;
			m_bulletCount = m_cageSize * 2;
		}

        private void Start()
        {
            m_weaponFSM.ActivateState(WeaponStateEnum.Idle);
        }

        public void StartFire()
        {
            m_weaponFSM.StartFire();
        }

        public void StopFire()
        {
            m_weaponFSM.StopFire();
        }

        public void Reload()
        {
            m_weaponFSM.Reload();
        }

        private void Update()
        {
            m_weaponFSM.Update();
        }

        public void Shoot()
        {
            --m_cageSize;
            --m_bulletCount;

            Debug.Log("Weapon shoot");
            weaponDataSO.weaponShoot.Shoot(m_muzzle.position, m_muzzle.forward, weaponDataSO.damage);

			onShoot?.Invoke();
		}

        public void ReloadComplete()
        {
            Debug.Log("Weapon ReloadComplete");
            m_cageSize = Mathf.Min(weaponDataSO.cageSize, m_bulletCount);

			onReload?.Invoke();
		}
    }
}