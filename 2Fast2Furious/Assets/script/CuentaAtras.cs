using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{
    public GameObject goMotorCarretera;
    public MotorCarretera scpMotorCarreterra;
    public Sprite[] vecNumeros;

    public GameObject goContadorNumeros;
    public SpriteRenderer compContadorNumeros;

    public GameObject goControladorCoche;
    public GameObject goCoche;

    IEnumerator Contar()
    {
        this.goControladorCoche.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        this.compContadorNumeros.sprite = vecNumeros[1];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        this.compContadorNumeros.sprite = vecNumeros[2];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        this.compContadorNumeros.sprite = vecNumeros[3];
        this.scpMotorCarreterra.inicioJuego = true;
        this.goContadorNumeros.GetComponent<AudioSource>().Play();
        this.goCoche.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        this.goContadorNumeros.SetActive(false);
    }

    void InicializarObjetos()
    {
        this.goMotorCarretera = GameObject.Find("MotorCarretera");
        this.scpMotorCarreterra = this.goMotorCarretera.GetComponent<MotorCarretera>();

        this.goContadorNumeros = GameObject.Find("ContadorNumeros");
        this.compContadorNumeros = this.goContadorNumeros.GetComponent<SpriteRenderer>();

        this.goControladorCoche = GameObject.Find("ControladorCoche");
        this.goCoche = GameObject.Find("coche");

        this.IniciarCuentaAtras();
    }

    void IniciarCuentaAtras()
    {
        StartCoroutine(Contar());
    }

    // Start is called before the first frame update
    void Start()
    {
        this.InicializarObjetos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
