using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject Spawn;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")  
        {
            collision.transform.position = Spawn.transform.position;
        }
    }
}