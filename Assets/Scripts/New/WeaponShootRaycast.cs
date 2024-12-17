using UnityEngine;

public class WeaponShootRaycast : MonoBehaviour, IWeaponShoot
{
    public void Shoot(Vector3 position, Vector3 direction)
    {
        if (Physics.Raycast(position, direction, out var hitInfo))
        {
            Debug.Log($"Hit - {hitInfo.collider.name}", hitInfo.collider);
        }
    }
}
