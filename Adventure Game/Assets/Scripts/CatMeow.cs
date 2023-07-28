using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CatMeow : MonoBehaviour
{
    [SerializeField] private AudioClip[] catSoundsClips;
    
    [Range(-3, 3)]
    [SerializeField] private float minPitch = 0.5f;
    [Range(-3, 3)]
    [SerializeField] private float maxPitch = 3f;
    [Range(10, 30)]
    [SerializeField] private float Intervals = 10f;

   public AudioSource audioSourceCat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InvokeRepeating("PlayMeowSound", 1.0f, Intervals);
        }
    }
    private void PlayMeowSound()
    {
        //sound clip
        int randomIndex = Random.Range(0, catSoundsClips.Length);
        AudioClip soundClip = catSoundsClips[randomIndex];
        //pitch
        audioSourceCat.pitch = Random.Range(minPitch, maxPitch);
        //play sound
        audioSourceCat.PlayOneShot(soundClip);
    }
}

