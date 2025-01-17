
using System.Collections.Generic;
using UnityEngine;

namespace Xlab.States.Controllers
{
	public class ActivateObjectController : MonoBehaviour
	{
		[SerializeField] private List<GameObject> m_objects;

		private void OnEnable()
		{
			m_objects.ForEach(o => o.SetActive(true));
		}

		private void OnDisable()
		{
			m_objects.ForEach(o =>
			{
				if (o != null)
				{
					o.SetActive(false);
				}
			});
		}
	}
}
