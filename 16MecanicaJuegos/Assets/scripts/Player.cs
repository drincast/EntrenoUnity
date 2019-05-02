using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject goPared;
    public Pared scpPared;
    public Object obj;
    public Mecanica01[] mecanicas01;

    // Start is called before the first frame update
    void Start()
    {
        goPared = GameObject.Find("Cube02");
        scpPared = goPared.GetComponent<Pared>();
        obj = Object.FindObjectOfType(typeof(GameObject));

        mecanicas01 = Object.FindObjectsOfType(typeof(Mecanica01)) as Mecanica01[];

        Debug.LogFormat("{0}", "\n");
        Debug.LogFormat("Información del objeto: type: {0}, name: {1}", obj.GetType().ToString(), obj.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (!scpPared.paredActiva)
        {
            goPared.SetActive(false);
        }
    }
}
