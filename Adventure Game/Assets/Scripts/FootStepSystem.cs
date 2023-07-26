using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSystem : MonoBehaviour
{
    public AudioSource AudioSource;

    public AudioClip grass;
    public AudioClip concrete;

    RaycastHit hit;
    public Transform RayStart;
    public float range;
    public LayerMask layerMask;

    public void Footstep()
    {
        if (Physics.Raycast(RayStart.position, RayStart.transform.up * -1, out hit, range, layerMask))
        {
            if (hit.collider.CompareTag("concrete"))
            {
                PlayFootstepSoundClip(concrete);
            }
            if (hit.collider.CompareTag("grass"))
            {
                PlayFootstepSoundClip(grass);
            }
        }
    } 



    void PlayFootstepSoundClip(AudioClip audio)
    {
        AudioSource.pitch = Random.Range(0.8f, 1f);
        AudioSource.PlayOneShot(audio);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Footstep();
    }
}