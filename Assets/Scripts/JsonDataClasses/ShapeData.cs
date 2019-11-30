using System;
using UnityEngine;

[Serializable]
public class ShapeData
{
    public string modifiedData;
    public Vector3 coordinate;
    public string name;
    public int id;
    public enum type
    {
        Red,
        Green,
        Blue
    };
}