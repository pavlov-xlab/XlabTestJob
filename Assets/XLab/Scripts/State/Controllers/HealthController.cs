using System;
using UnityEngine;

namespace Xlab
{
    public class HealthController : MonoBehaviour
    {
		[SerializeField] private UIHPBar m_hpBar;
		private HealthComponent m_hp;

		public void Init(HealthComponent hp)
		{
			m_hp = hp;
		}

        private void OnEnable()
		{
			if (m_hp)
			{
				m_hp.onDamage += OnTakeDamage;
				OnTakeDamage();
			}
		}

		private void OnDisable()
		{
			if (m_hp)
			{
				m_hp.onDamage -= OnTakeDamage;
			}
		}

		private void OnTakeDamage()
		{
			m_hpBar.SetHP(m_hp.hpInPercent);
		}
    }
}
