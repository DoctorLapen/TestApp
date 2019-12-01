using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
//Класс для проверкм изменений в json-данных
public class JsonChangeCheckHandler : MonoBehaviour
{
    [SerializeField]
    private RequestHandler requestHandler;
    //Событие которые происходит если json-данные изменились
    public event UnityAction<DataChangedEventArgs> DataChanged;
    //Событие которые происходит если json-данные не изменились
    public event UnityAction<ShapeData[]> DataNotChanged;

    private void Awake()
    {
        requestHandler.DataDownloaded += OnDataDownloaded;
    }
    /*
     * Метод который проверяет изменение поля modifiedData  
     * в новых данных относительно текущих данных
     * если данных изменились ,то вызывается событие DataChanged
     * и метод RewriteData
     * если данных не изменились ,то вызывается событие DataNotChanged
     * принимает json-строку с новыми данными
    */
    private void OnDataDownloaded(string newDataString)
    {
        TestTable CurData = JsonUtility.FromJson<TestTable>(LoadCurDataString());
        TestTable NewData = JsonUtility.FromJson<TestTable>(newDataString);
        if (CurData.modifiedData != NewData.modifiedData)
        {
            RewriteData(newDataString);
            DataChangedEventArgs data = new DataChangedEventArgs();
            data.OldData = CurData.data;
            data.NewData = NewData.data;
            DataChanged?.Invoke(data);
        }
        else DataNotChanged?.Invoke(CurData.data); 
    }
    //Метод для загрузки json-строки с текущими данными
    private string LoadCurDataString()
    {
        string path = Path.Combine(Application.dataPath, "TestTable.json");
        return File.ReadAllText(path);
    }
    //Метод для перезаписи старых данных новыми json-данными
    private void RewriteData(string newDataString)
    {
        string path = Path.Combine(Application.dataPath, "TestTable.json");
        File.WriteAllText(path, newDataString);
    }
}
