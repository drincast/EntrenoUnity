using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class LoadImageUrl : MonoBehaviour
{
    public Image img;

    // Start is called before the first frame update
    void Start()
    //async void Start()
    {
        StartCoroutine(LoadImage2());     //ok
        //LoadImage3(this.img);             //ok

        // Texture2D texture = await LoadImage4();
        // img.sprite = Sprite.Create(texture, new Rect(0,0,texture.width,texture.height), new Vector2(0,0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadImage()
    {
        WWW www = new WWW("https://tgchan.org/kusaba/questdis/src/130784452211.png");
        yield return www;

        Debug.Log(string.Format("hxw = {0}x{1}", www.texture.height, www.texture.width));

        img.sprite = Sprite.Create(www.texture, new Rect(0,0,www.texture.width,www.texture.height), new Vector2(0,0));
    }

    IEnumerator LoadImage2()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://tgchan.org/kusaba/questdis/src/130784452211.png");
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError)
            Debug.Log(www.error);
        else
        {
            Texture2D texture = ((DownloadHandlerTexture) www.downloadHandler).texture;
            Debug.Log(string.Format("hxw = {0}x{1}", texture.height, texture.width));
            img.sprite = Sprite.Create(texture, new Rect(0,0,texture.width,texture.height), new Vector2(0,0));
        }
    }

    public static async void LoadImage3(Image img)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://tgchan.org/kusaba/questdis/src/130784452211.png");        
        //yield return www.SendWebRequest();

        var asyncOp = www.SendWebRequest();

        while(!www.isDone)
        {
                await Task.Delay( 1000/30 );//30 hertz
        }

        if(www.isNetworkError || www.isHttpError){
            Debug.Log(www.error);
        }            
        else
        {
            if(www.isDone)
            {
                Texture2D texture = ((DownloadHandlerTexture) www.downloadHandler).texture;
                Debug.Log(string.Format("hxw = {0}x{1}", texture.height, texture.width));
                img.sprite = Sprite.Create(texture, new Rect(0,0,texture.width,texture.height), new Vector2(0,0));
            }
            
        }
    }

    public static async Task<Texture2D> LoadImage4()
    {
        Texture2D texture = null;
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://tgchan.org/kusaba/questdis/src/130784452211.png");        
        //yield return www.SendWebRequest();

        var asyncOp = www.SendWebRequest();

        while(!www.isDone)
        {
                await Task.Delay( 1000/30 );//30 hertz
        }

        if(www.isNetworkError || www.isHttpError){
            Debug.Log(www.error);
        }            
        else
        {
            if(www.isDone)
            {
                texture = ((DownloadHandlerTexture) www.downloadHandler).texture;
                Debug.Log(string.Format("hxw = {0}x{1}", texture.height, texture.width));
            }
        }

        return texture;
    }
}
