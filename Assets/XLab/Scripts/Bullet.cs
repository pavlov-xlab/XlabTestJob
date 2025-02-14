using UnityEngine;
using Xlab;


[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IBullet
{
    public float lifeTime = 5f;

	private int m_damage;

	private Rigidbody m_body;

	public event System.Action onDestroy;

	private void Awake()
	{
		m_body = GetComponent<Rigidbody>();
	}

	public void Fire(float power, int damage)
	{
		m_body.linearVelocity = transform.forward * power;

		m_damage = damage;


		Invoke("DestroySelf", lifeTime);
	}

	public void Reset()
	{
		var body = GetComponent<Rigidbody>();
		m_body.linearVelocity = Vector3.zero;
		m_body.angularVelocity = Vector3.zero;
		m_damage = 0;
		CancelInvoke();
		onDestroy = null;
	}

    private void DestroySelf()
	{
		onDestroy?.Invoke();
	}

    private void OnCollisionEnter(Collision other)
    {   
        Debug.Log($"HitBullet - {other.collider.name}", other.collider);

		if (other.collider.TryGetComponent<HealthComponent>(out var hp))
		{
			hp.TakeDamage(m_damage);
		}

        DestroySelf();
    }
}
