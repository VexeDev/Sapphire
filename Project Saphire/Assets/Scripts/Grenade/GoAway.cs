using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAway : MonoBehaviour
{

    public float boomTime = 1.95f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, boomTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
