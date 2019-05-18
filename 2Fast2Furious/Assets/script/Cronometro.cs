using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    public GameObject goMotorCarretera;
    public MotorCarretera scpMotorcarretera;

    public float tiempo;
    public float distancia;
    public Text txtTiempo;
    public Text txtDistacia;
    public Text txtMsjDistancia;

    void InicializarObjetos()
    {
        this.goMotorCarretera = GameObject.Find("MotorCarretera");
        this.scpMotorcarretera = this.goMotorCarretera.GetComponent<MotorCarretera>();

        this.txtTiempo.text = "2:00";
        this.txtDistacia.text = "0";
        this.tiempo = 120;
    }

    void CalcularTiempoDistacia()
    {
        this.distancia += Time.deltaTime * this.scpMotorcarretera.velocidad;
        this.txtDistacia.text = ((int)this.distancia).ToString();

        this.tiempo -= Time.deltaTime;
        int minutos = (int)this.tiempo / 60;
        int segundos = (int)this.tiempo % 60;
        this.txtTiempo.text = string.Format("{0}:{1}", minutos.ToString(), segundos.ToString().PadLeft(2, '0'));
    }

    // Start is called before the first frame update
    void Start()
    {
        InicializarObjetos();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.scpMotorcarretera.inicioJuego && this.scpMotorcarretera.finJuego == false)
        {
            CalcularTiempoDistacia();
        }

        if(this.tiempo <= 0 && this.scpMotorcarretera.finJuego == false)
        {
            this.scpMotorcarretera.finJuego = true;
            this.scpMotorcarretera.JuegoTerminadoEstados();
            this.txtMsjDistancia.text = this.txtDistacia.text + " mts";
            this.txtTiempo.text = "0:00";
        }
    }
}
