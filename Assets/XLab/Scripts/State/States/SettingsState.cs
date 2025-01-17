
using UnityEngine;
using UnityEngine.UI;

namespace Xlab.States
{
	public class SettingsState : GameStateBehaviour
	{
		public UISettingsPanel panel;

		public void AddHealth(float health)
		{
			panel.AddHealth(health);
		}
	}
}
