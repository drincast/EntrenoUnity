using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformaciones : MonoBehaviour
{
    private Transform thisTransform = null;
    public GameObject goCuboRojo;
    Transform cpTransformCuboRojo;

    // Start is called before the first frame update
    void Start()
    {
        this.thisTransform = GetComponent<Transform>();
        thisTransform.position = new Vector3(-1, 1, 1);

        goCuboRojo = GameObject.Find("CuboRojo");
        cpTransformCuboRojo = goCuboRojo.transform;

        cpTransformCuboRojo.position = new Vector3(-2, -0.1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
