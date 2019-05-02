using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrutina : MonoBehaviour
{
    private bool activateCoroutineTree = false;

    public GameObject[] trees;
    public bool hideTree = false;

    // Start is called before the first frame update
    void Start()
    {
        trees = GameObject.FindGameObjectsWithTag("Tree");
        StartCoroutine(HideTree());
    }

    // Update is called once per frame
    void Update()
    {
        if (this.activateCoroutineTree)
        {
            Debug.Log("this.hideTree is true");
            this.activateCoroutineTree = false;
            StartCoroutine(HideTree());
        }
    }

    IEnumerator HideTree()
    {
        yield return new WaitForSeconds(2.0f);
        this.trees[0].SetActive(this.hideTree);

        yield return new WaitForSeconds(2);
        this.trees[1].SetActive(this.hideTree);

        yield return new WaitForSeconds(2);
        this.trees[2].SetActive(this.hideTree);

        yield return new WaitForSeconds(2);
        this.activateCoroutineTree = true;
        this.hideTree = !this.hideTree;
    }
}
