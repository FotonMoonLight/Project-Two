using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sphere : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject[] points;
    public GameObject apple;
    public static bool _Mover = false;
    public GameObject Mover;
    public GameObject app;
    public int _HpTree;
    public int _Speed;
    public int i;
    public bool _AppleTrans = true;
    private bool corector = false;
    private void Start()
    {
        _HpTree = Random.Range(5, 12);
        i = Random.Range(0, points.Length);
        if(Random.Range(0,100) > 1)
        {
            
            Instantiate(apple, points[i].transform.position, points[i].transform.rotation);
            
        }
    }


    void FixedUpdate()
    {
        if(_AppleTrans == true)
        {
            app = GameObject.Find("Apple(Clone)");
            app.transform.position = points[i].transform.position;
            app.transform.rotation = points[i].transform.rotation;
        }
        else
        {
            Destroy(app);
        }
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
