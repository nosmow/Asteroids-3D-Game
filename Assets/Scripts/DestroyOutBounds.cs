using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBounds : MonoBehaviour
{
    float horizontal = 22f; 
    float vertical = 22f;

    void Update()
    {
        if (transform.position.x > horizontal || transform.position.x < -horizontal)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z > vertical || transform.position.z < -vertical)
        {
            Destroy(gameObject);
        }
    }
}
