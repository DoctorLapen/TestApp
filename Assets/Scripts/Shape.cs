using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Класс который показывает данные фигуры в редакторе
public class Shape : MonoBehaviour
{
    [SerializeField]
    private string modifiedData;
    [SerializeField]
    private Vector3 coordinate;
    [SerializeField]
    private int id;
    [SerializeField]
    private TypeEnum type;

    //Метод для инициализации или обновления данных фигуры
    public void ChangeData(ShapeData shapeData)
    {
        transform.name = shapeData.name;
        modifiedData = shapeData.modifiedData;
        coordinate = shapeData.coordinate;
        id = shapeData.id;
        type = shapeData.type; 
    }
}
