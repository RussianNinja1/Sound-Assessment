using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatTrigger : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject Prefab;
    public GameObject Cat;
   
    void OnTriggerEnter()
    {
        //Use in scene Lost cat not the prefab
        Instantiate(Cat, Spawnpoint.position, Spawnpoint.rotation);
        Destroy(Cat);
        Destroy(Prefab);
    }
}
