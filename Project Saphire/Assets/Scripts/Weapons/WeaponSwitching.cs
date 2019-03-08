using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{

    public int currentWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {

        int previousSelectedWeapon = currentWeapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (currentWeapon >= transform.childCount - 1)
                currentWeapon = 0;
            else 
                currentWeapon++;
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentWeapon <= transform.childCount - 1)
                currentWeapon = transform.childCount - 1;
            else
                currentWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >= 2)
        {
            currentWeapon = 0;
        }
        
        /*
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            currentWeapon = 1;
        }
        */

        if (previousSelectedWeapon != currentWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon ()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == currentWeapon)

                weapon.gameObject.SetActive(true);
            else

                weapon.gameObject.SetActive(false);
                i++;
            
        }
    }
}
