using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaC : MonoBehaviour
{
    public GameObject goBala;

    public BalaC(Vector3 posicion, int idBala){
        try
        {
            //Debug.Log(string.Format("balaC: {0}", this.gameObject));

            this.goBala = new GameObject(string.Format("bala{0}", idBala.ToString()));
            SpriteRenderer sri = this.goBala.AddComponent<SpriteRenderer>();
            sri.sprite = Resources.Load<Sprite>("sprites/bala_14x18");

            this.Materializar(posicion);
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error en BalaCs: {0}", ex.Message));
            throw;
        }
    }

    public bool Materializar(Vector3 posicion)
    {
        bool res = false;

        this.goBala.SetActive(true);
        this.goBala.transform.position = new Vector3(posicion.x, posicion.y, posicion.z);
        res = true;

        return res;
    }

    public bool Desplazar()
    {
        bool res = false;

        try
        {
            float y = 0;
            //y = this.gameObject.transform.position.y + 0.2f;
            y = 2f;
            Debug.Log(string.Format("name: {0} - x: {1} - y: {2} - z: {3}", this.gameObject.name, this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z));
            
            //this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, y, this.gameObject.transform.position.z);
            this.gameObject.transform.Translate(Vector3.up * y * Time.deltaTime);
            

            //Debug.Log(string.Format("x: {0} - y: {1} - z: {2}", this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z));
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error En BalaA - Desplazamiento: {0}", ex));
            throw;
        }

        return res;
    }

    public bool FinalizarBala()
    {
        bool res = false;

        try
        {
            this.gameObject.SetActive(false);
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error En BalaA - Desplazamiento: {0}", ex));
            throw;
        }

        return res;
    }
}
