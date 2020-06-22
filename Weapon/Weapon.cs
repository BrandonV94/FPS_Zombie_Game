using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera = null;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem muzzleFlashVFX = null;
    [SerializeField] GameObject hitEffectVFX = null;
    [SerializeField] Ammo ammoSlot = null;
    [SerializeField] AmmoType ammoType;
    [SerializeField] Text ammoCountText = null;
    [SerializeField] float timeBetweenShots = 1f; 

    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        DisplayAmmo();
        if (Input.GetButtonDown("Fire1") && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmount(ammoType);
        ammoCountText.text = currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if( ammoSlot.GetCurrentAmount(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRayCast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlashVFX.Play();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            print(name + " hit " + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        var hitEffect = Instantiate(hitEffectVFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitEffect, .1f);
    }
}
