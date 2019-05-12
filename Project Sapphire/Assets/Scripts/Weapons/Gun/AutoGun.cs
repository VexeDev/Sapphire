using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject normalCam;
    public GameObject ADSCam;
    bool isAiming = false;
    bool hasAimed = false;

    Animator anim;
    Animator camAnim;

    public Text currentAmmoText;
    public Text currentAmmoWorldText;

    public AudioSource gunshot;

    //initialization
    void Start()
    {
        currentAmmo = maxAmmo;
        anim = this.GetComponent<Animator>();
        camAnim = ADSCam.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentAmmoText.text = currentAmmo.ToString();
        currentAmmoWorldText.text = currentAmmo.ToString();

        if(isReloading == true)
        {
            currentAmmoText.text = 0.ToString();
        }

        if (isReloading == true)
        {
            return;
        }

        if(currentAmmo <= 0)
        {
            Reload();
            return;
        }
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire) {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }

        if(Input.GetButtonDown("Reload"))
        {
            Reload();
        }

        if(Input.GetButtonDown ("Fire2"))
        {
            isAiming = true;
        }

        if(Input.GetButtonUp ("Fire2"))
        {
            isAiming = false;
        }

        if (isAiming == true)
        {
            Aim();
        }

        if(isAiming == false)
        {
            StopAim();
        }
    }

    void OnEnable()
    {
        isReloading = false;
    }

    void Reload ()
    {
        if (currentAmmo < maxAmmo)
        {
            forceAimQuit();
            StartCoroutine(reload());
            return;
        }
    }

    void Shoot ()
    {

        currentAmmo--;
        gunshot.Play();

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

    void Aim()
    {
        if(hasAimed == false)
        {
            hasAimed = true;
            //turn off normal cam
            normalCam.GetComponent<Camera>().enabled = false;
            //turn on new cam
            ADSCam.GetComponent<Camera>().enabled = true;
            //play gun zoom anim
            anim.SetBool("isAiming", true);
            //play cam zoom anim
            camAnim.SetBool("isAiming", true);
        }
    }

    void StopAim()
    {
        if(hasAimed == true)
        {
            hasAimed = false;
            //play cam unzoom
            anim.SetBool("isAiming", false);
            //play gun unzoom
            camAnim.SetBool("isAiming", false);
            //should wait a few secs before doing this
            StartCoroutine(unZoomTimer());
        }
    }

    void forceAimQuit ()
    {
        isAiming = false;
        anim.SetBool("isAiming", false);
        hasAimed = false;
        ADSCam.GetComponent<Camera>().enabled = false;
        normalCam.GetComponent<Camera>().enabled = true;
    }

    IEnumerator lightTimer ()
    {
        yield return new WaitForSeconds(.05f);
        memeLight.SetActive(false);
    }

    IEnumerator reload ()
    {
        isAiming = false;
        isReloading = true;

        anim.SetBool("reloading", true);
        
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;

        isReloading = false;
        anim.SetBool("reloading", false);
    }

    IEnumerator unZoomTimer ()
    {
        yield return new WaitForSeconds(.15f);
        //turn off new cam
        ADSCam.GetComponent<Camera>().enabled = false;
        //turn on old cam
        normalCam.GetComponent<Camera>().enabled = true;
    }
}
