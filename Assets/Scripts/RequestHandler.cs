using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//Класс для отправления запросов на сервер
public class RequestHandler : MonoBehaviour
{   
    //событие которое происходить когда данные с сервера загружены
    public event UnityAction<string> DataDownloaded;
    private void Start()
    {
        StartCoroutine(SendRequestsWithInterval());
    }
    private void SendGetRequest()
    {
        string data = WebServerEmulator.GetJsonData();
        Debug.Log(data);
        DataDownloaded?.Invoke(data);
    }
    // Корутина которая отправляет Get-запрос  каждые 10 секунд;
    private IEnumerator SendRequestsWithInterval() {
        while (true) {
            SendGetRequest();
            yield return new WaitForSeconds(10f);
        }
    }

    
}
