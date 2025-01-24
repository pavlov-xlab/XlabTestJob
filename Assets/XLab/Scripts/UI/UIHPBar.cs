using UnityEngine;
using UnityEngine.UI;

namespace Xlab
{
	public class UIHPBar : MonoBehaviour
	{
		[SerializeField] private Image m_fill;

		private void Awake()
		{
			m_fill.fillAmount = 0f;
		}

		public void SetHP(float percent)
		{
			m_fill.fillAmount = percent;
		}
	}
}
