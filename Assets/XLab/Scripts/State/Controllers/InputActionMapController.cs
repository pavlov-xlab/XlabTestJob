using UnityEngine;
using UnityEngine.InputSystem;

namespace Xlab
{
	public class InputActionMapController : MonoBehaviour
	{
		[SerializeField] private InputActionAsset m_actions;
		[SerializeField] private string[] m_maps;

		private void OnEnable()
		{
			foreach (var item in m_maps)
			{
				var map = m_actions.FindActionMap(item);
				map?.Enable();
			}
		}

		private void OnDisable()
		{
			foreach (var item in m_maps)
			{
				var map = m_actions.FindActionMap(item);
				map?.Disable();
			}
		}
	}
}
