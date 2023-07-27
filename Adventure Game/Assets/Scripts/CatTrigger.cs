using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CatTrigger : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject Cat;
   
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "pickup")
        {
            Instantiate(Cat, Spawnpoint.position, Spawnpoint.rotation);

            Destroy(other.gameObject);
        }
    }
}
