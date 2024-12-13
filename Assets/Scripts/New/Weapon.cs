using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform m_muzzle;
    public WeaponDataSO weaponDataSO;
    private Coroutine m_fireCoroutine;


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
        var go = Instantiate(weaponDataSO.bulletPrefab, m_muzzle.position, m_muzzle.rotation);
        
        if (go.TryGetComponent<IBullet>(out var bullet))
        {
            bullet.Fire(weaponDataSO.power);
        }
    }
}
