using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.Audio;


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

    Animator anim;
    Animator camAnim;

    public Text currentAmmoText;
    public Text currentAmmoWorldText;

    public AudioSource gunshot;
    [SerializeField] private AudioClip[] gunshotSounds;

    //initialization
    void Start()
    {
        currentAmmo = maxAmmo;
        anim = this.GetComponent<Animator>();
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
    }

    void OnEnable()
    {
        isReloading = false;
    }

    void Reload ()
    {
        if (currentAmmo < maxAmmo)
        {
            StartCoroutine(reload());
            return;
        }
    }

    void Shoot ()
    {

        currentAmmo--;
        playShotAudio();

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

    void playShotAudio ()
    {
        int n = Random.Range(1, gunshotSounds.Length);
        gunshot.clip = gunshotSounds[n];
        gunshot.PlayOneShot(gunshot.clip);
        gunshotSounds[n] = gunshotSounds[0];
        gunshotSounds[0] = gunshot.clip;
    }

    IEnumerator lightTimer ()
    {
        yield return new WaitForSeconds(.05f);
        memeLight.SetActive(false);
    }

    IEnumerator reload ()
    {
        isReloading = true;

        anim.SetBool("reloading", true);
        
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;

        isReloading = false;
        anim.SetBool("reloading", false);
    }

    
}
