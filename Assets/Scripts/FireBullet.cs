using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FireBullet : Gun_Base
{
    public float speed = 50f;
    public GameObject bulletObj;
    public Transform frontOfGun;

    [SerializeField] private AudioSource gunShotSource;
    [SerializeField] private AudioSource reloadSource;

    [SerializeField] private int maxBulletCount = 10;
    private int currentBulletCount = 0;
 
    public static event Action GunFired;

    private bool isReloading = false;

    private void Start()
    {
        currentBulletCount = maxBulletCount;
    }

    public void Fire()
    {
        if (isReloading) return;

        currentBulletCount--;
        gunShotSource.Play();
        GameObject spawnedBullet = Instantiate(bulletObj, (frontOfGun.position) + frontOfGun.forward * 0.3f, frontOfGun.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * frontOfGun.forward;
        Destroy(spawnedBullet, 5f);
        GunFired?.Invoke();

        if (currentBulletCount <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(0.2f);
        reloadSource.Play();
        yield return new WaitForSeconds(0.3f);
        currentBulletCount = maxBulletCount;
        isReloading = false;
    }

    public override void StartReloading()
    {
        if (isReloading) return;
        StartCoroutine(Reload());
    }
}
