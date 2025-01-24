using UnityEngine;
using UnityEngine.UI;

namespace Xlab
{
	public class UIWeaponBar : MonoBehaviour
	{
		[SerializeField] private Image m_icon;
		[SerializeField] private TMPro.TMP_Text m_text;

		public void SetIcon(Sprite icon)
		{
			m_icon.sprite = icon;
		}

		public void SetBulletInfo(int cur, int max)
		{
			m_text.text = $"{cur} / {max}";
		}
	}
}
