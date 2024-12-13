using UnityEngine;

public class BulletRaycast : MonoBehaviour, IBullet
{
    public void Fire(float power)
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hitInfo))
        {
            Debug.Log($"Hit - {hitInfo.collider.name}", hitInfo.collider);
        }
        Destroy(gameObject);
    }
}
