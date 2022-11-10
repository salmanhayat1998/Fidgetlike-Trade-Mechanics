using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardCollisions : MonoBehaviour
{
    public GameObject particles;
    GameObject obj;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="item")
        {
             obj =Instantiate(particles, collision.transform.position, Quaternion.identity);
            Destroy(obj, 0.3f);
        }
    }
    
}
