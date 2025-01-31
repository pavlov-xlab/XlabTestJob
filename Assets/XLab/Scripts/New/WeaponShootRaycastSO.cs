using UnityEngine;
using Xlab;

[CreateAssetMenu(menuName = "Weapon/WeaponShootRaycastSO", fileName = "WeaponShootRaycastSO")]
public class WeaponShootRaycastSO : WeaponShootSO
{
	public override void Shoot(Vector3 position, Vector3 direction, int damage)
    {
        if (Physics.Raycast(position, direction, out var hitInfo))
        {
            Debug.Log($"Hit - {hitInfo.collider.name}", hitInfo.collider);

			if (hitInfo.collider.TryGetComponent<HealthComponent>(out var hp))
			{
				hp.TakeDamage(damage);
			}
        }
    }
}
