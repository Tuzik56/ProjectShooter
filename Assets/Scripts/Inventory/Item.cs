using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Item/Create New Item")]

public class Item : ScriptableObject
{
    public int id;
    public Sprite icon;
    public GameObject gameObj;
    public Vector3 position;
    public Vector3 rotation;
}
