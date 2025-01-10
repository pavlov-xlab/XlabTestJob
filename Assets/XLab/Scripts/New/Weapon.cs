using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    enum State { Idle, Fire, Reload, Empty }

    public Transform m_muzzle;
    public WeaponDataSO weaponDataSO;
    private Coroutine m_fireCoroutine;
    private IWeaponShoot m_weaponShoot;

    private State m_state = State.Idle;
    private int m_cageSize = 0;
    private int m_bulletCount;

    private void Awake()
    {
        m_weaponShoot = GetComponent<IWeaponShoot>();
        weaponDataSO.icon = null;
    }

    private void Start()
    {
        m_cageSize = weaponDataSO.cageSize;
        m_bulletCount = m_cageSize * 2;
    }

    public void Reload()
    {
        if (m_state == State.Fire || m_state == State.Idle)
        {
            m_state = State.Reload;

            StopFire();
            StartCoroutine(ReloadDelay());
        }
    }

    public void StartFire()
    {
        if (m_cageSize <= 0)
        {
            return;
        }

        if (m_state == State.Idle)
        {
            m_state = State.Fire;
            m_fireCoroutine = StartCoroutine(FireDelay());
        }
        else if (m_state == State.Empty)
        {
            Debug.Log("i am empty!");
        }
    }

    private IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(weaponDataSO.reloadDelay);
        m_cageSize = Mathf.Min(weaponDataSO.cageSize, m_bulletCount);
        m_state = State.Idle;
    }

    private IEnumerator FireDelay()
    {
        do
        {
            Shoot();
            yield return new WaitForSeconds(weaponDataSO.delay);
        }
        while(weaponDataSO.autoFire && m_cageSize > 0);


        if (m_bulletCount <= 0)
        {
            m_state = State.Empty;
        }
        else
        {
            m_state = State.Idle;
        }


        if (m_cageSize == 0 && m_bulletCount > 0 && weaponDataSO.autoReload)
        {
            Reload();
        }
    }

    public void StopFire()
    {
        m_state = State.Idle;

        if (m_fireCoroutine != null)
        {
            StopCoroutine(m_fireCoroutine);
            m_fireCoroutine = null;
        }
    }

    private void Shoot()
    {
        --m_cageSize;
        --m_bulletCount;

        weaponDataSO.weaponShoot.Shoot(m_muzzle.position, m_muzzle.forward);
        // m_weaponShoot.Shoot(m_muzzle.position, m_muzzle.forward);
    }
}
