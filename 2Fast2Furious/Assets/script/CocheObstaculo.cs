using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheObstaculo : MonoBehaviour
{
    public GameObject goCronometro;
    public Cronometro scpCronometro;

    public GameObject goAudioFx;
    public AudioFX scpAudioFx;

    // Start is called before the first frame update
    void Start()
    {
        this.goCronometro = GameObject.FindObjectOfType<Cronometro>().gameObject;
        this.scpCronometro = this.goCronometro.GetComponent<Cronometro>();

        this.goAudioFx = GameObject.FindObjectOfType<AudioFX>().gameObject;
        this.scpAudioFx = this.goAudioFx.GetComponent<AudioFX>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Coche>() != null)
        {
            this.scpAudioFx.FXSonidoChoque();
            this.scpCronometro.tiempo -= 5;
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
