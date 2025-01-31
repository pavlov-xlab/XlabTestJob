using System;
using DG.Tweening;
using UnityEngine;

namespace Xlab
{
	public class FXDamageController : MonoBehaviour
	{
		[SerializeField] private CanvasGroup m_view;
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
			}

			m_view.alpha = 0;
		}

		private void OnDisable()
		{
			if (m_hp)
			{
				m_hp.onDamage -= OnTakeDamage;
			}

			m_view.alpha = 0;
		}

		private void OnTakeDamage()
		{
			DG.Tweening.Sequence sequence = DOTween.Sequence();
			sequence.Append(m_view.DOFade(1, 0.1f))
					.Append(m_view.DOFade(0, 0.3f));
		}
	}
}
