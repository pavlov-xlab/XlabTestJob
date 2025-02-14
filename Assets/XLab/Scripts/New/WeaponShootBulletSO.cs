using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(menuName = "Weapon/WeaponShootBulletSO", fileName = "WeaponShootBulletSO")]
public class WeaponShootBulletSO : WeaponShootSO
{
	public Bullet prefab;
	public float power = 10f;

	private ObjectPool<Bullet> m_pool;


	public override void Shoot(Vector3 position, Vector3 direction, int damage)
	{
		if (m_pool == null)
		{
			m_pool = new ObjectPool<Bullet>(createFunc: () =>
			{
				return Instantiate(prefab);
			},
			actionOnRelease: b =>
			{
				b.gameObject.SetActive(false);
				b.Reset();
			},
			actionOnGet: b =>
			{
				b.gameObject.SetActive(true);
			});
		}

		var bullet = m_pool.Get();
		bullet.transform.SetPositionAndRotation(position, Quaternion.LookRotation(direction));
		bullet.Fire(power, damage);

		bullet.onDestroy += () => m_pool.Release(bullet);
	}
}
