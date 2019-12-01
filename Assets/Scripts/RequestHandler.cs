
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
//Класс для отправления запросов на сервер
public class RequestHandler : MonoBehaviour
{   
    //Событие которое происходить когда данные с сервера загружены
    public event UnityAction<string> DataDownloaded;

    [SerializeField]
    private string url = "https://owncloud.lindenvalley.de/index.php/s/lXIIkptI7tKJRL8/download";

    private void Start()
    {
       StartCoroutine(SendRequestsWithInterval(url));
    }

    private IEnumerator SendGetRequest(string url)
    {
        var request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();        

        if (!request.isHttpError && !request.isNetworkError)
        {
            DataDownloaded?.Invoke(request.downloadHandler.text);
        }
        else
        {
            Debug.LogErrorFormat("error request [{0}, {1}]", url, request.error);
            Debug.Log(null);
        }
        request.Dispose();
    }
    // Корутина которая отправляет Get-запрос  каждые 10 секунд;
    private IEnumerator SendRequestsWithInterval(string url)
    {
        while (true) {
            StartCoroutine(SendGetRequest(url));
            yield return new WaitForSeconds(10f);
        }
    }   
}
