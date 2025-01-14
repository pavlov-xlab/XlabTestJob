
using System.Collections.Generic;
using UnityEngine;

namespace Xlab.States
{
	public class ActivateObjectController : MonoBehaviour, IController
	{
		public List<GameObject> m_objects;

		public void Activate()
		{
			m_objects.ForEach(o => o.SetActive(true));
		}

		public void Deactivate()
		{
			m_objects.ForEach(o => o.SetActive(false));
		}
	}
}
