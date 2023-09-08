using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FireBullet : Gun_Base
{
    public float speed = 50f;
    public GameObject bulletObj;
    public Transform frontOfGun;

    [SerializeField] private AudioClip gunShotSound;
    [SerializeField] private AudioClip reloadSound;

    [SerializeField] private int maxBulletCount = 10;
    private int currentBulletCount = 0;
 
    public static event Action GunFired;

    private bool isReloading = false;

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
        GetComponent<AudioSource>().clip = reloadSound;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        currentBulletCount = maxBulletCount;
        isReloading = false;
    }

}
