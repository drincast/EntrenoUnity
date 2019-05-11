using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    public AudioClip[] fxs;
    AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        this.audioS = this.GetComponent<AudioSource>();
    }

    // 0 choque
    public void FXSonidoChoque()
    {
        this.audioS.clip = fxs[0];
        audioS.Play();
    }

    // 0 choque
    public void FXMusica()
    {
        this.audioS.clip = fxs[1];
        audioS.Play();
    }
}
