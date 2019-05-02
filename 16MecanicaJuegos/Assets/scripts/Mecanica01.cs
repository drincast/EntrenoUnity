using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanica01 : MonoBehaviour
{
    public GameObject[] goPlayers;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("----------- Script desde GO: " + gameObject.name);

        goPlayers = GameObject.FindGameObjectsWithTag("Player");

        foreach (var go in goPlayers)
        {
            Debug.Log(go.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
