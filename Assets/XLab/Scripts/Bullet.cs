using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IBullet
{
    public float lifeTime = 5f;

    public void Fire(float power)
    {
        var body = GetComponent<Rigidbody>();
        body.linearVelocity = transform.forward * power;
        
        Invoke("DestroySelf", lifeTime);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        DestroySelf();
        
        Debug.Log($"HitBullet - {other.collider.name}", other.collider);
    }
}
