using System.Collections;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource source;
    
    
    private void Awake()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            source.Play();
            
        }

        
    }
}
