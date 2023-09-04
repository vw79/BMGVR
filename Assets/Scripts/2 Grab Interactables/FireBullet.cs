using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FireBullet : MonoBehaviour
{
    public float speed = 50f;
    public GameObject bulletObj;
    public Transform frontOfGun;

    [SerializeField] private int maxBulletCount = 10;
    private int currentBulletCount = 0;
 
    public static event Action GunFired;

    private void Start()
    {
        currentBulletCount = maxBulletCount;
    }

    public void Fire()
    {
        if(currentBulletCount <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        currentBulletCount--;
        GetComponent<AudioSource>().Play();
        GameObject spawnedBullet = Instantiate(bulletObj, (frontOfGun.position) + frontOfGun.forward * 0.3f, frontOfGun.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * frontOfGun.forward;
        Destroy(spawnedBullet, 5f);
        GunFired?.Invoke();
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(2f);
        currentBulletCount = maxBulletCount;
    }

}
