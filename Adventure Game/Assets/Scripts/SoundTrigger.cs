using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    AudioSource source;
    Collider soundTrigger;
    private IEnumerator Sound()
    {
        source.Play();
        yield return new WaitForSeconds(5f);
        
    }
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
          StartCoroutine(Sound());
        }

        
    }
}
