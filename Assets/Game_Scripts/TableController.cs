using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    public GameObject TimeLapse;
    public bool TurnOnTime = false;
    public bool Stop = false;
    float multipler = 1f;
    public GameObject CurrentTime;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (TurnOnTime) StartTimeLapse();

    }

    void StartTimeLapse()
    {
        if (multipler < 88.5f && !Stop)
        {
            multipler = 0.05f + multipler;
            Vector3 timer = new Vector3(multipler, 1, 1);
            TimeLapse.transform.localScale = timer;
        }
        else
        {
            Stop = true;
        }
       
    }


}
