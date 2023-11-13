using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReadyPlayerMe.Core;
using UnityEngine.Networking;
using Siccity.GLTFUtility;


public class LoadAvatar : MonoBehaviour
{
    [SerializeField]
    private string avatarUrl = "https://models.readyplayer.me/655192b4f1a79ed2ebb81732.glb";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(downloadAvatar(avatarUrl));
    }

    IEnumerator downloadAvatar(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(avatarUrl))
        {
            yield return webRequest.SendWebRequest();
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("nReceived: " + webRequest.downloadHandler.data.Length);
                    GameObject avatar = Importer.LoadFromBytes(webRequest.downloadHandler.data);
                    break;

            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
