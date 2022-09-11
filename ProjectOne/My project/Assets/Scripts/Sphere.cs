using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public GameObject[] buttons;
    public static bool _Mover = false;
    public GameObject Mover;
    private bool corector = false;

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
        if (_Mover == true)
        {
            if (Mover.transform.position.y <= 1.4f && corector == false)
            {
               Mover.transform.Translate(Vector3.up * 1f * Time.fixedDeltaTime);
                
            }
            if (Mover.transform.position.y >= 1.38 && corector == true)
            {
                Mover.transform.Translate(Vector3.down * 1f * Time.fixedDeltaTime);
            }

            if(Mover.transform.position.y > 1.4f)
            {
                corector = true;
            }
            if(Mover.transform.position.y <= 1.38f)
            {
                _Mover = false;
                corector = false;
            }
            
        }
    }
}
