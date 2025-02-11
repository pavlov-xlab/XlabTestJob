using UnityEngine;
using UnityEngine.Events;

namespace Xlab
{
	public class HealthComponent : MonoBehaviour
	{
		[SerializeField] private int m_hp = 100;
		[SerializeField] private int m_hpMax = 100;

		public bool isDead => m_hp <= 0;

		public float hpInPercent => m_hp / (float)m_hpMax;

		public event System.Action onDie;
		public event System.Action onDamage;

		[SerializeField] private UnityEvent m_onDie;

		public void TakeDamage(int damage)
		{
			if (isDead)
			{
				return;
			}

			m_hp = Mathf.Max(m_hp - damage, 0);
			onDamage?.Invoke();

			if (m_hp <= 0)
			{
				onDie?.Invoke();
				m_onDie.Invoke();
			}
		}
	}
}
