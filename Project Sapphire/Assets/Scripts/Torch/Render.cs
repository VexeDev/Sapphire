using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Render : MonoBehaviour
{
    Light thisLight;
    Transform player;
    public GameObject playerObject;

    private void Start()
    {
        thisLight = GetComponentInChildren<Light>();
        player = playerObject.transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance <= 75f)
        {
            thisLight.enabled = true;
            //Debug.Log("enabled");
        } else
        {
            thisLight.enabled = false;
            //Debug.Log("disabled");
        }
    }
}
