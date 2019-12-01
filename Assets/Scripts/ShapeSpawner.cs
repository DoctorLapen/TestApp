using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Класс для спауна фигур
public class ShapeSpawner : MonoBehaviour
{  
    
    //Массив префабов фигур
    public GameObject[] ShapePrefab = new GameObject[5];

    [SerializeField]
    private ShapeMoveController moveController;
    //Родителский объект для фигур
    [SerializeField]
    private GameObject parent;

    private void Start()
    {
    /*
     *Спаун фигур созданых из префабов 
     *и их добавление в массив ShapesAr класса ShapeMoveController
    */
        for ( int i = 0; i< 5; i++)
        {
            moveController.ShapesArr[i] = Instantiate(ShapePrefab[i],
                                          Vector3.zero,Quaternion.identity,parent.transform);
        }       
    }    
}
