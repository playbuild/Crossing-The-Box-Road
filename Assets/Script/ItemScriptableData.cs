using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DataType
{
    Speed,
    Color
}


[CreateAssetMenu(fileName = "CarStat", menuName = "New Stat")]

public class CarData : ScriptableObject
{
    [Header("Data")]
    public DataType type;
    public Material Color;
    public float Speed;
    public GameObject CarPrefab;
}