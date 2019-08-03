using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Render : MonoBehaviour
{

    public Renderer renderMake;
    public bool litStart;
    public GameObject torchBody;

    /*
   // Start is called before the first frame update
   void Start()
   {
       if(litStart == true)
       {
           torchBody.SetActive(true);
       } else
       {
           torchBody.SetActive(false);
       }
   }

   private void OnTriggerEnter(Collider other)
   {
       if (other.tag == "Player")
       {
           torchBody.SetActive(true);
       }
   }

   private void OnTriggerExit(Collider other)
   {
       if (other.tag == "Player")
       {
           torchBody.SetActive(false);
       }
   }*/

    private void Start()
    {
        if(litStart == true)
        {
            torchBody.SetActive(true);
        } else
        {
            torchBody.SetActive(false);
        }
    }

    private void Update()
    {
        if(renderMake.isVisible)
        {
            torchBody.SetActive(true);
        } else
        {
            torchBody.SetActive(false);
        }
    }
}
