using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillAxe : MonoBehaviour
{
    public GameObject axeThrowHolder;

    public void refillTheAxe ()
    {
        Debug.Log("i should be manually getting the axe");
        axeThrowHolder.GetComponent<NewAxe>().refillTheAxe();
    }
}
