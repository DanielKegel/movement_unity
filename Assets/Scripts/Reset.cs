using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Move the object to the same position as the parent:
            transform.position = new Vector3(0, 1, 0);

        }
    }
}
    
