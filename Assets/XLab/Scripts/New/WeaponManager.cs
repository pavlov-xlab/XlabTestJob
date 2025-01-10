using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private readonly List<Weapon> m_weapons = new List<Weapon>();
    public List<WeaponDataSO> m_data;
    private Weapon m_currentWeapon;

    private void Awake()
    {
        GetComponentsInChildren(true, m_weapons);
        m_weapons.ForEach(x=> x.gameObject.SetActive(false));

        SetActiveWeapon(0);
    }

    private void Start()
    {
        foreach (var data in m_data)
        {
            var go = Instantiate(data.prefab, transform);
            go.SetActive(false);
            if (go.TryGetComponent<Weapon>(out var weapon))
            {
                m_weapons.Add(weapon);
            }
        }

        SetActiveWeapon(0);
    }

    public void Reload()
    {
        Debug.Log($"[WeaponManager]: Reload");
        if (m_currentWeapon)
        {
            m_currentWeapon.Reload();
        }
    }

    public void StartFire()
    {
        Debug.Log($"[WeaponManager]: StartFire");
        if (m_currentWeapon)
        {
            m_currentWeapon.StartFire();
        }
    }

    public void StopFire()
    {
        Debug.Log($"[WeaponManager]: StopFire");
        if (m_currentWeapon)
        {
            m_currentWeapon.StopFire();
        }
    }

    public void NextWeapon()
    {
        Debug.Log($"[WeaponManager]: NextWeapon");
        int index = m_weapons.IndexOf(m_currentWeapon);
        if (index >= 0)
        {
            SetActiveWeapon(++index % m_weapons.Count);
        }
    }

    public void SetActiveWeapon(int index)
    {
        Debug.Log($"[WeaponManager]: SetActiveWeapon({index})");
        if (m_currentWeapon)
        {
            m_currentWeapon.gameObject.SetActive(false);
            m_currentWeapon = null;
        }

        if (index >= 0 && index < m_weapons.Count)
        {
            m_currentWeapon = m_weapons[index];
            m_currentWeapon.gameObject.SetActive(true);
        }
    }
}
