using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slutsound : MonoBehaviour
{
    private AudioSource audSor;
    public AudioClip reelSound;
    // Start is called before the first frame update
    void Start()
    {
        audSor = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void reel()
    {
        
        audSor.PlayOneShot(reelSound);

    }
}
