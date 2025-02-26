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
		private float m_curSpeed = 0f;
		[SerializeField]
		private float m_speedMaxDelta = 0f;

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

		private void LateUpdate()
		{
			Vector3 thisPosition = m_thisTransform.position;
			float speed = Vector3.Distance(m_lastPosition, thisPosition) / Time.deltaTime;

			if (m_speedMaxDelta > 0f)
			{
				m_curSpeed = Mathf.MoveTowards(m_curSpeed, speed, Time.deltaTime * m_speedMaxDelta);
			}
			else
			{
				m_curSpeed = speed;
			}

			m_animator.SetFloat(SpeedId, m_curSpeed);
			
			m_lastPosition = thisPosition;
		}

	}
}
