using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataChangedEventArgs : EventArgs
{
    public ShapeData[] OldData;
    public ShapeData[] NewData;
}
