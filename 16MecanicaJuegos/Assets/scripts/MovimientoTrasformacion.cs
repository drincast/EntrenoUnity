using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTrasformacion : MonoBehaviour
{
    private Transform thisTrasform = null;

    public float velocidad = 0;
    public float rotacion = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.thisTrasform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //this.thisTrasform.position += new Vector3(0, 0, 1 * this.velocidad * Time.deltaTime);
        this.thisTrasform.Translate(Vector3.forward * this.velocidad * Time.deltaTime);
        this.thisTrasform.Rotate(Vector3.up * rotacion * Time.deltaTime);
    }
}
