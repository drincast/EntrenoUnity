using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCoche : MonoBehaviour
{
    public GameObject goCoche;
    public float velocidad;
    public float anguloDeGiro;

    // Start is called before the first frame update
    void Start()
    {
        this.goCoche = GameObject.Find("coche");
    }

    // Update is called once per frame
    void Update()
    {
        float giroEnZ = 0;

        this.transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * this.velocidad * Time.deltaTime);

        giroEnZ = Input.GetAxis("Horizontal") * -this.anguloDeGiro;
        this.goCoche.transform.rotation = Quaternion.Euler(0, 0, giroEnZ);

    }
}
