using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -0.8)
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.localPosition = new Vector3(Random.Range(-0.550f, 0.655f), 1.25f, Random.Range(-0.5f, -0.16f));
        }
    }
    
}
