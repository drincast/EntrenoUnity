using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventos : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("En Awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("En Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("En Update");
    }

    private void OnEnable()
    {
        Debug.Log("En OnEnable");
    }

    private void OnDisable()
    {
        Debug.Log("En OnDisable");
    }

    private void OnMouseDown()
    {
        Debug.Log("En OnMouseDown");
    }

    private void OnMouseEnter()
    {
        Debug.Log("En OnMouseEnter");
    }

    private void OnMouseExit()
    {
        Debug.Log("En OnMouseExit");
    }

    private void OnMouseOver()
    {
        Debug.Log("En OnMouseOver");
    }

    private void OnMouseUp()
    {
        Debug.Log("En OnMouseUp");
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("En OnMouseUpAsButton");
    }

    private void OnMouseDrag()
    {
        Debug.Log("En OnMouseDrag");
    }
}
