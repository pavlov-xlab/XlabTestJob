using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform m_muzzle;
    public WeaponDataSO weaponDataSO;
    private Coroutine m_fireCoroutine;
    private IWeaponShoot m_weaponShoot;

    private void Awake()
    {
        m_weaponShoot = GetComponent<IWeaponShoot>();
    }


    public void StartFire()
    {
        m_fireCoroutine = StartCoroutine(FireDelay());
    }

    private IEnumerator FireDelay()
    {
        do
        {
            Shoot();
            yield return new WaitForSeconds(weaponDataSO.delay);
        }
        while(true);
    }

    public void StopFire()
    {
        if (m_fireCoroutine != null)
        {
            StopCoroutine(m_fireCoroutine);
            m_fireCoroutine = null;
        }
    }

    private void Shoot()
    {
        weaponDataSO.weaponShoot.Shoot(m_muzzle.position, m_muzzle.forward);
        // m_weaponShoot.Shoot(m_muzzle.position, m_muzzle.forward);
    }
}
