
using UnityEngine;
using UnityEngine.Events;
//Класс сериализирует(TestTable) и десериализируют (в TestTable) json-данные
public class JsonSerializator : MonoBehaviour
{
    [SerializeField]
    private RequestHandler requestHandler;
    //событие которое происходить когда Json-строка десериализирована в объект класса TestTable
    public event UnityAction<TestTable> JsonDeserialized;

    private void Awake()
    {      
        requestHandler.DataDownloaded += DeserializeData;
    }

    private void DeserializeData(string data)
    {
        TestTable testTable = JsonUtility.FromJson<TestTable>(data);
        JsonDeserialized?.Invoke(testTable);
    }
  
}
