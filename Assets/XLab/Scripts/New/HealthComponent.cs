using UnityEngine;

namespace Xlab
{
	public class HealthComponent : MonoBehaviour
	{
		[SerializeField] private int m_hp = 100;
		[SerializeField] private int m_hpMax = 100;

		public float hpInPercent => m_hp / (float)m_hpMax;

		public event System.Action onDie;
		public event System.Action onDamage;

		public void TakeDamage(int damage)
		{
			m_hp = Mathf.Max(m_hp - damage, 0);
			onDamage?.Invoke();

			if (m_hp <= 0)
			{
				onDie?.Invoke();
			}
		}
	}
}
