using UnityEngine;
using Xlab;


[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IBullet
{
    public float lifeTime = 5f;

	private int m_damage;

    public void Fire(float power, int damage)
    {
        var body = GetComponent<Rigidbody>();
        body.linearVelocity = transform.forward * power;

		m_damage = damage;


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

		if (other.collider.TryGetComponent<HealthComponent>(out var hp))
		{
			hp.TakeDamage(m_damage);
		}
    }
}
