using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnbot : MonoBehaviour
{
    public Animator animation;
    public GameObject bot;
    public bool spawn = false;

    // Start is called before the first frame update
    void Start()
    {
   

    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            Instantiate(bot);
     
            spawn = false;
        }
    }
}
