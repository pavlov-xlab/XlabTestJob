using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        public float maxAngle = 30f;
        public float speed = 360f;
        public float power = 100f;
        public Transform point;
        public event System.Action onCollisionStone;

        private Vector3 m_lastPointPosition;
        private Vector3 m_dir;
        private bool m_isDown = false;
        private Rigidbody m_rigidbody;
        private float m_angle = 0;

        public void Reset()
        {
            m_isDown = false;
        }


        private void Awake()
        {
            m_angle = maxAngle;
            m_rigidbody = GetComponent<Rigidbody>();
        }

        public void Down()
        {
            m_isDown = true;
        }

        public void Up()
        {
            m_isDown = false;
        }

        private void FixedUpdate()
        {
            if (m_isDown)
            {   
                m_angle = Mathf.MoveTowards(m_angle, -maxAngle, speed * Time.deltaTime);
            }
            else
            {
                m_angle = Mathf.MoveTowards(m_angle, maxAngle, speed * Time.deltaTime);
            }

            Vector3 localEulerAngles = transform.localEulerAngles;
            localEulerAngles.z = m_angle;
            transform.localEulerAngles = localEulerAngles;

            m_dir = (point.position - m_lastPointPosition).normalized;
            m_lastPointPosition = point.position;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<Stone>(out var stone) && !stone.isDirty)
            {
                stone.isDirty = true;
                // var contact = other.contacts[0];
                other.rigidbody.AddForce(m_dir * power, ForceMode.Impulse);
                onCollisionStone?.Invoke();
            }
        }
    }
}