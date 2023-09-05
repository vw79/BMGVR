using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SMG_Shooting : MonoBehaviour
{
    public static event Action GunFired;
    public float speed = 50f;
    public GameObject bulletObj;
    public Transform frontOfGun;

    private int currentBulletCount = 0;
    [SerializeField] private int maxBulletCount = 30;
    [SerializeField] private float bulletSpread = 0.05f;
    private float shootInterval = 0.1f;

    private ActionBasedController controller;
    private GameObject lefthand;

    private bool isReloading = false;
    private bool isShooting = false;

    private void Start()
    {
        currentBulletCount = maxBulletCount;
        lefthand = GameObject.Find("LeftHand Controller");
        Debug.Log(lefthand.name);
        controller = lefthand.GetComponent<ActionBasedController>();
        
        Debug.Log(controller);
    }

    
    public void Fire()
    {
        if (isReloading) return;
        currentBulletCount--;
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
        yield return new WaitForSeconds(2f);
        currentBulletCount = maxBulletCount;
        isReloading = false;
    }
}
