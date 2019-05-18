using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fundido : MonoBehaviour
{
    public Image imgFundido;
    public string[] escenas;

    // Start is called before the first frame update
    void Start()
    {
        this.imgFundido.CrossFadeAlpha(0, 0.5f, false);
    }

    public void FadeOut(int indiceEscena)
    {
        this.imgFundido.CrossFadeAlpha(1, 0.5f, false);
        StartCoroutine(CambioEscena(escenas[indiceEscena]));
    }

    IEnumerator CambioEscena(string escena)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(escena);
    }
}
