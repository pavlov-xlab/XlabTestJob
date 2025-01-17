using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Xlab
{
	public class UISettingsPanel : MonoBehaviour
	{
		[SerializeField] private TMP_Text m_valueSlider;
		[SerializeField] private Slider m_slider;

		public void AddHealth(float health)
		{
			m_slider.value += health;
		}

		public void OnSliderValueChange(float value)
		{
			m_valueSlider.text = value.ToString();
		}
	}
}
