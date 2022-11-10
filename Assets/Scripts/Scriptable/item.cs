using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "New/item")]
public class item : ScriptableObject
{
    public GameObject obj;
    public Sprite itemImg;
    public Sprite reactionImage;
   // for now setting name //
    //public int priority;
    public int value;
   // public int itemCount;
    public bool isPaid;
    public string[] possibleReactionsMsgs;
    public AudioClip[] possibleReactionsSounds;
}
public enum itemType
{
    cash,
    AlternativeToCash,
    dumbThing,
    worthyThing
}
