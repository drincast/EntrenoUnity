using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlMov_ : MonoBehaviour
{
    private short indiceVecFondos;

    public bool iniciar;
    public float direccionMovY;
    public float velocidadMov;
    public GameObject[] vecGOFondos;

    private void Inicializar()
    {
        this.indiceVecFondos = 0;
        this.iniciar = false;
        this.direccionMovY = -1;
        this.vecGOFondos = new GameObject[3];
        this.vecGOFondos[0] = GameObject.Find("F000_1280x720");
        this.vecGOFondos[1] = GameObject.Find("F001_1280x720");
        this.vecGOFondos[2] = GameObject.Find("F002_1280x720");

        this.ImpInfo();
    }

    private void ImpInfo()
    {
        Debug.Log(string.Format("this.vecGOFondos[0]: size.x - {0}, size.y - {1} ", this.vecGOFondos[0].GetComponent<SpriteRenderer>().size.x, this.vecGOFondos[0].GetComponent<SpriteRenderer>().size.y));
        Debug.Log(string.Format("this.vecGOFondos[0]: position - {0} ", this.vecGOFondos[0].GetComponent<SpriteRenderer>().transform.position.ToString()));
        Debug.Log(string.Format("pixelsPerUnit: {0} ", this.vecGOFondos[0].GetComponent<SpriteRenderer>().sprite.pixelsPerUnit));


    }

    // Start is called before the first frame update
    void Start()
    {
        this.Inicializar();
    }

    // Update is called once per frame
    void Update()
    {        
        if (this.iniciar)
        {
            //this.vecGOFondos[0].transform.position = new Vector3(0, (this.vecGOFondos[0].transform.position.y + (this.velocidadMov * this.direccionMovY)), 0);
            //Debug.Log(string.Format("this.vecGOFondos.Length: {0} - this.indiceVecFondos: {1}", this.vecGOFondos.Length, this.indiceVecFondos));
            if (!this.vecGOFondos[this.indiceVecFondos].GetComponent<MovFondo_>().MoverEnY(this.direccionMovY, this.velocidadMov)) {                
                if (this.vecGOFondos.Length - 1 > this.indiceVecFondos)
                {
                    this.indiceVecFondos++;
                }
                else
                {
                    this.indiceVecFondos = 0;
                }
            }

            //this.ImpInfo();
            //this.iniciar = false;
        }
    }
}
