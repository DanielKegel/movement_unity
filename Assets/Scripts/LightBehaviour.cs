using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{

    public Light flashLight;
    public Light redLight;

    private bool isactive;
    private bool redactive;
    // Start is called before the first frame update
    void Start()
    {
        isactive = true;
        redactive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(isactive == false || redactive == true)
            {
                flashLight.enabled = true;
                isactive = true;
                redLight.enabled = false;
                redactive = false;
            }
            else if (isactive == true)
            {
                flashLight.enabled = false;
                isactive = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            if (redactive == false || isactive == true)
            {
                redLight.enabled = true;
                redactive = true;
                flashLight.enabled = false;
                isactive = false;
            }
            else if (redactive == true)
            {
                redLight.enabled = false;
                redactive = false; 
            }
        }
    }
}
