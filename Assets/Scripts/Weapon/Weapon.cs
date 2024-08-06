using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 1f;
    [SerializeField] ParticleSystem gunFlash;
    [SerializeField] GameObject enemyHitEffect;
    [SerializeField]  float fireRate = 10f;  // Number of shots per second
    private float nextFireTime = 0f;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;

    private void Start()
    {
        if (gunFlash == null)
        {
            Debug.LogError("Gun Flash Particle System is not assigned!");
        }
    }

    void Update()
    {
        DisplayAmmo();

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    private void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {

        PlayGunFlash();
        ProcessRaycast();
        ammoSlot.ReduceCurrentAmmo(ammoType);
        }
    }

    private void PlayGunFlash()
    {
        if (gunFlash != null)
        {
            gunFlash.Play();

        }
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        Vector3 impactPosition = hit.point + hit.normal * 0.01f; // Slightly offset the position
        GameObject impact = Instantiate(enemyHitEffect, impactPosition, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f); // Reduce the lifetime for testing
    }

}
