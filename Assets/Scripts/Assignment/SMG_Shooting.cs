using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SMG_Shooting : Gun_Base
{
    public static event Action GunFired;
    public float speed = 50f;
    public GameObject bulletObj;
    public Transform frontOfGun;

    [SerializeField] private AudioClip gunShotSound;
    [SerializeField] private AudioClip reloadSound;

    private int currentBulletCount = 0;
    [SerializeField] private int maxBulletCount = 30;
    [SerializeField] private float bulletSpread = 0.05f;
    private float shootInterval = 0.07f;


    private bool isReloading = false;
    private bool isShooting = false;

    private void Start()
    {
        base.Start();
        currentBulletCount = maxBulletCount;
    }

    
    public void Fire()
    {
        if (isReloading) return;
        currentBulletCount--;
        GetComponent<AudioSource>().clip = gunShotSound;
        GetComponent<AudioSource>().Play();
        GameObject spawnedBullet = Instantiate(bulletObj, (frontOfGun.position) + frontOfGun.forward * 0.3f, frontOfGun.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * new Vector3(frontOfGun.forward.x + UnityEngine.Random.Range(-bulletSpread, bulletSpread), frontOfGun.forward.y + UnityEngine.Random.Range(-bulletSpread, bulletSpread), frontOfGun.forward.z); ;
        Destroy(spawnedBullet, 5f);

        isShooting = true;
        if (currentBulletCount <= 0)
        {
            StartCoroutine(Reload());
        }

        StartCoroutine(continousShoot());
    }

    private IEnumerator continousShoot()
    {
        yield return new WaitForSeconds(shootInterval);
        if (isShooting)
        {
            Fire();
        }
        else
        {
            yield break;
        }
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        GetComponent<AudioSource>().clip = reloadSound;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        currentBulletCount = maxBulletCount;
        isReloading = false;
    }
}
