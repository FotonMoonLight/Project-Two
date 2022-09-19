using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeLogic : MonoBehaviour
{
    public GameObject sphere;
    public GameObject knifeBut;
    public static bool _Restart = false;
    public bool _HasMove = true;
    public bool _CanLose = false;
    private bool _DamageTrue = false;
    [Header ("Настройки ножа")]
    public float speed = 7f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_HasMove == true)
        {
            transform.Translate(Vector3.down * speed * Time.fixedDeltaTime);
        }
        HpDamager();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sphere"))
        {
            transform.parent = other.transform;
            _HasMove = false;
            _CanLose = true;
            Sphere._Mover = true;
            _DamageTrue = true;
        }
        if (other.gameObject.CompareTag("Knife") && _CanLose == true)
        {
            _Restart = true;
            knifeBut.SetActive(false);
        }
        if (other.gameObject.CompareTag("Apple"))
        {
            sphere = GameObject.FindGameObjectWithTag("Sphere");
            sphere.GetComponent<Sphere>()._AppleTrans = false;
        }
    }
    private void HpDamager()
    {
        if (_DamageTrue == true)
        {
            sphere = GameObject.FindGameObjectWithTag("Sphere");
            sphere.GetComponent<Sphere>()._HpTree -= 1;
            _DamageTrue = false;
        }
    }
}
