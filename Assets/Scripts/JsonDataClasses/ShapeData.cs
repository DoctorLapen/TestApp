using System;
using UnityEngine;

[Serializable]
public class ShapeData
{
    public string modifiedData;
    public Vector3 coordinate;
    public string name;
    public int id;
    public  TypeEnum type;
}
[Serializable]
public enum TypeEnum
{
    Red,
    Green,
    Blue
};