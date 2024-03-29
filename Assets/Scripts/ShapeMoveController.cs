﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Класс перемещает фигуры
public class ShapeMoveController : MonoBehaviour
{   //Массив в котором храняться все фигуры которые нужно двигать 
    public GameObject[] ShapesArr = new GameObject[5];

    [SerializeField]
    private JsonChangeCheckHandler checkHandler;
    /*
     * Поле которое показывает первое ли это передвижение фигур в этом запуске
     * нужно для корректной работы метода MoveShapesAfterStartDeplay
    */
    private bool isNoFirstShapesMoving;
    //Поле для хранения массива ShapeData текущих данных
    private ShapeData[] curShapeData;
    //Поле для хранения массива ShapeData новых данных
    private ShapeData[] newShapeData;
    //Поле для хранения массива ShapeData данных для стартового перемещения
    private ShapeData[] DataForFirstMove;

    private void Awake()
    {
        checkHandler.DataChanged += OnDataChanged;
        checkHandler.DataNotChanged += OnDataNotChange;
    }

    private void Start()
    {
        StartCoroutine(MoveShapesAfterStartDeplay());
    }
    //Метод-обработчик события DataNotChanged 
    private void OnDataNotChange(ShapeData[] data)
    {
        DataForFirstMove = data;
    }
    /*
     * Метод-обработчик события DataNotChanged 
     * если это не первое измения данных ,то вызывает метод MoveShapes
    */
    private void OnDataChanged(DataChangedEventArgs e)
    {
        DataForFirstMove = e.NewData;
        curShapeData = e.OldData;
        newShapeData = e.NewData;
        if (isNoFirstShapesMoving) MoveShapes();
    }
    /*
     * Корутина которая перемещает все фигуры по указанным кординатам из curShapeData
     * и передает в каждую фигуру её данные
     * после 5 секундной задержки
     * вызывается только один раз в начале запуска приложения
    */
    private IEnumerator MoveShapesAfterStartDeplay()
    {
        yield return new WaitForSeconds(5f);
        for ( int i = 0; i < 5; i++)
        {   
            StartCoroutine(MoveShape(ShapesArr[i].transform, DataForFirstMove[i].coordinate));
            ShapesArr[i].GetComponent<Shape>().ChangeData(DataForFirstMove[i]);
        }
        isNoFirstShapesMoving = true;       
    }
    /*
     * Метод который двигает фигуры
     * если их координаты изменились в новых данных
     * и передает новые данные в фигуры
    */
    private void MoveShapes()
    {
        for ( int i = 0; i < 5; i++)
        {
            ShapeData data;
            if (curShapeData[i].coordinate != newShapeData[i].coordinate)
            {
                data = newShapeData[i];
                StartCoroutine(MoveShape(ShapesArr[i].transform, newShapeData[i].coordinate));
            }
            else data = curShapeData[i];
            ShapesArr[i].GetComponent<Shape>().ChangeData(data);
        }
    }
    /*
     * Корутина которая двигает фигуры к target
     * на maxDistanceDelta = 1
     * каждые 0,1 секунды
     * по фигура не достигнет target
    */
    private IEnumerator MoveShape(Transform shape,Vector3 target)
    {
        while (shape.position != target)
        {
            shape.position = Vector3.MoveTowards(shape.position,target,1);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
