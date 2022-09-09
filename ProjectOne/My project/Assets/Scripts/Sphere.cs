using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public GameObject[] buttons;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * 20f * Time.fixedDeltaTime);
        if(KnifeLogic._Restart == true)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(true);
            }
        }
    }
}
