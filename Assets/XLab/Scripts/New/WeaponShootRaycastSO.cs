using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/WeaponShootRaycastSO", fileName = "WeaponShootRaycastSO")]
public class WeaponShootRaycastSO : WeaponShootSO
{
    public override void Shoot(Vector3 position, Vector3 direction)
    {
        if (Physics.Raycast(position, direction, out var hitInfo))
        {
            Debug.Log($"Hit - {hitInfo.collider.name}", hitInfo.collider);
        }
    }
}
