using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Xlab
{
    public class Damager : MonoBehaviour
    {
		class DamageTarget
		{
			public HealthComponent health;
			public float damageLastTime;
		}

		private List<DamageTarget> m_targets = new();

		[SerializeField] private float m_damageDelay;
		[SerializeField] private int m_value;

		private void Update()
		{
			float time = Time.time;

			foreach (var target in m_targets)
			{
				if (time > target.damageLastTime + m_damageDelay)
				{
					target.health.TakeDamage(m_value);
					target.damageLastTime = time;
				}
			}
		}

        private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.TryGetComponent<HealthComponent>(out var hp))
			{
				m_targets.Add(new DamageTarget()
				{
					health = hp
				});
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject.TryGetComponent<HealthComponent>(out var hp))
			{
				m_targets.RemoveAll(x => x.health = hp);
			}
		}
    }
}
