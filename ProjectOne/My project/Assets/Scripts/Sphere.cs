using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sphere : MonoBehaviour
{
    public GameObject[] buttons;
    public static bool _Mover = false;
    public GameObject Mover;
    public int _HpTree;
    public int _Speed;
    private bool corector = false;
    private void Start()
    {
        _HpTree = Random.Range(5, 12);
    }


    void FixedUpdate()
    {
        SphereStats();
        transform.Rotate(Vector3.forward * _Speed * Time.fixedDeltaTime);
        if(KnifeLogic._Restart == true)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(true);
            }
        }
        if (_Mover == true)
        {
            if (Mover.transform.position.y <= 1.41f && corector == false)
            {
               Mover.transform.Translate(Vector3.up * 0.5f * Time.fixedDeltaTime);
                
            }
            if (Mover.transform.position.y >= 1.38 && corector == true)
            {
                Mover.transform.Translate(Vector3.down * 0.5f * Time.fixedDeltaTime);
            }

            if(Mover.transform.position.y > 1.41f)
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
    private void SphereStats()
    {
        if(_HpTree == 0)
        {
            GameObject[] gm = GameObject.FindGameObjectsWithTag("Knife");
            for(int i = 0; i < gm.Length; i++)
            {
                Destroy(gm[i]);
            }
            _HpTree = Random.Range(5, 12);
        }
    }
}
