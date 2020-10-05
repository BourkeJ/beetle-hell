using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beetleSfx : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audSor;
    public AudioClip pushClip;
    public AudioClip fallClip;

    void Start()
    {
        audSor = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void push()
    {
        if (!audSor.isPlaying)
        {
            audSor.pitch = (Random.Range(0.85f, 1.15f));

            audSor.PlayOneShot(pushClip);
        }
            

    }
    private void fall()
    {
        audSor.pitch = (Random.Range(0.85f, 1.15f));
        audSor.PlayOneShot(fallClip);

    }
}
