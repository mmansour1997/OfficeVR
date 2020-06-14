using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpandDown : MonoBehaviour
{
    float speed = 5f;

    // Update is called once per frame
    void Update()
    { 
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed)*0.025f;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(38.26487f, newY+ (-23.3f), -104.338f);
    }
}
