using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGun : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public float fireRate = 15f;

    public GameObject bloodImpactEffect;
    public GameObject impactEffect;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject memeLight;

    public int maxAmmo = 40;
    private int currentAmmo;
    public float reloadTime = 3f;
    private bool isReloading;

    private float nextTimeToFire = 0f;

    public GameObject indicator;

    //initialization
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading == true)
        {
            indicator.SetActive(false);
            return;
        }

        if(currentAmmo <= 0)
        {
            Reload();
            return;
        }
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire) {
            nextTimeToFire = Time.time + 1f/fireRate;
            indicator.SetActive(false);
            Shoot();
        }

        if(Time.time >= nextTimeToFire)
        {
            indicator.SetActive(true);
        }

        if(Input.GetButtonDown("Reload"))
        {
            Reload();
        }
    }

    void OnEnable()
    {
        isReloading = false;
    }

    void Reload ()
    {
        StartCoroutine(reload());
        return;
    }

    void Shoot ()
    {

        currentAmmo--;

        RaycastHit hit;
        muzzleFlash.Play();
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            Health target = hit.transform.GetComponent<Health>();
            memeLight.SetActive(true);
            StartCoroutine(lightTimer());
            if(target != null)
            {
                target.Damage(damage);
                GameObject impactBGO = Instantiate(bloodImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactBGO, 2f);
            } else
            {
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
        }
    }

    IEnumerator lightTimer ()
    {
        yield return new WaitForSeconds(.05f);
        memeLight.SetActive(false);
    }

    IEnumerator reload ()
    {
        isReloading = true;
        
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;

        isReloading = false;
    }
}
