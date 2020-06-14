using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject Righthand;
    public GameObject thePlayer;

    public List<GameObject> AllArrows;


    private void OnCollisionEnter(Collision collision)
    {
        thePlayer.transform.position = teleportTarget.transform.position;

    }
}
