using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="New/Inventory")]
public class itemHolder : ScriptableObject
{
    public List<itemInHolder> items = new List<itemInHolder>();
    
}


[System.Serializable]
public class itemInHolder
{
    public string itemname;
    public item item;
    public int itemCount;
}