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
    [Header ("Настройки ножа")]
    public float speed = 7f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_HasMove == true)
        {
            transform.Translate(Vector3.down * speed * Time.fixedDeltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sphere"))
        {
            transform.parent = other.transform;
            _HasMove = false;
            _CanLose = true;
            Sphere._Mover = true;
        }
        if (other.gameObject.CompareTag("Knife") && _CanLose == true)
        {
            _Restart = true;
            knifeBut.SetActive(false);
        }
    }
}
