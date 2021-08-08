using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
   
    void Update()
    {
        if (Input.GetKey("escape")) // Application Quits when the Escape Key is pressed

            Application.Quit();
    }
}
