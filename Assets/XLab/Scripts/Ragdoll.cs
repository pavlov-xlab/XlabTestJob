using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
	private List<Rigidbody> m_rigidbodies = new List<Rigidbody>();
	private List<Collider> m_colliders = new List<Collider>();

	private void Awake()
	{
		GetComponentsInChildren(m_rigidbodies);
		GetComponentsInChildren(m_colliders);

		Enable(false);
	}
	
	public void Enable(bool enable)
	{
		foreach (var rb in m_rigidbodies)
		{
			rb.isKinematic = !enable;
		}
		
		foreach (var col in m_colliders)
		{
			col.enabled = enable;
		}
	}
}