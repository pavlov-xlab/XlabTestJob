using UnityEngine;
using UnityEngine.AI;

namespace Xlab
{
	public class NPCAnimator : MonoBehaviour
	{
		private Animator m_animator;

		private Vector3 m_lastPosition;

		private int SpeedId = Animator.StringToHash("Speed");
		private int HitId = Animator.StringToHash("Hit");
		private int DieId = Animator.StringToHash("Die");

		private Transform m_thisTransform;

		private void Awake()
		{
			m_thisTransform = transform;
			m_animator = GetComponent<Animator>();

			var hp = GetComponentInParent<HealthComponent>();
			if (hp)
			{
				hp.onDamage += () =>
				{
					m_animator.SetTrigger(HitId);
				};

				hp.onDie += () =>
				{
					// m_animator.SetTrigger(DieId);
					m_animator.enabled = false;
					GetComponent<Ragdoll>().Enable(true);
				};

			}
			
		}

		private void Start()
		{
			m_lastPosition = transform.position;
			
		}

		private void Update()
		{
			Vector3 thisPosition = m_thisTransform.position;
			float speed = Vector3.Distance(m_lastPosition, thisPosition) / Time.deltaTime;
			
			m_animator.SetFloat(SpeedId, speed);
			
			m_lastPosition = thisPosition;
		}

	}
}
