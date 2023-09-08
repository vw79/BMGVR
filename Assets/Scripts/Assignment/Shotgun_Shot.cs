using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun_Shot : Gun_Base
{
    public float speed = 50f;
    public GameObject bulletObj;
    public Transform frontOfGun;

    [SerializeField] private AudioClip gunShotSound;
    [SerializeField] private AudioClip reloadSound;

    [SerializeField] private int maxBulletCount = 1;
    private int currentBulletCount = 0;
    [SerializeField] private int pelletCount = 10;
    [SerializeField] private float pelletSpread = 0.1f;

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
        GetComponent<AudioSource>().clip = gunShotSound;
        GetComponent<AudioSource>().Play();

        for (int i = 0; i < pelletCount; i++)
        {
            GameObject spawnedBullet = Instantiate(bulletObj, (frontOfGun.position) + frontOfGun.forward * 0.3f, frontOfGun.rotation);
            spawnedBullet.GetComponent<Rigidbody>().velocity = speed * new Vector3(frontOfGun.forward.x + UnityEngine.Random.Range(-pelletSpread, pelletSpread), frontOfGun.forward.y + UnityEngine.Random.Range(-pelletSpread, pelletSpread), frontOfGun.forward.z);
            Destroy(spawnedBullet, 5f);
        }
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
