using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CloudController : MonoBehaviour
{    
    [SerializeField] private Transform m_cloud;
    [SerializeField] private ParticleSystem m_rain;
    [SerializeField] private Transform[] m_points;
    [SerializeField] private float m_speed = 10f;

    private int m_curPointIndex = -1;
    private bool m_isMove = false;

    private void Start()
    {
        m_rain.Stop();
    }


    public void MoveNext()
    {
        if (m_curPointIndex >= 0)
        {
            m_curPointIndex++;

            if (m_curPointIndex >= m_points.Length)
            {
                m_curPointIndex = 0;
            }
        }
        else
        {
           m_curPointIndex = 0;
        }

        m_isMove = true;
        m_rain.Stop();
    }

    private Vector3 GetPoint(int index)
    {
        var point = m_points[index].position;
        point.y = m_cloud.position.y;
        return point;
    }

    private void Update()
    {
        if (!m_isMove)
        {
            return;
        }

        var point = GetPoint(m_curPointIndex);
        m_cloud.position = Vector3.Lerp(m_cloud.position, point, Time.deltaTime * m_speed);
        if (Vector3.Distance(m_cloud.position, point) < 1f)
        {
            m_isMove = false;
            m_rain.Play();
        }
    }

}
