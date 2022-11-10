using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentHands : MonoBehaviour
{
 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("RejectButton") || collision.gameObject.tag.Equals("AddButton"))
        {
           // Debug.LogError("ascas");
            collision.gameObject.GetComponent<button3d>().onclick();
        }
    }
}
