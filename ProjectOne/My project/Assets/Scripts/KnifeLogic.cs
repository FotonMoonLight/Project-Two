using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeLogic : MonoBehaviour
{
    public GameObject sphere;
    public static bool _Restart = false;
    public bool _HasMove = true;
    public bool _CanLose = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_HasMove == true)
        {
            transform.Translate(Vector3.down * 5.5f * Time.fixedDeltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sphere"))
        {
            transform.parent = other.transform;
            _HasMove = false;
            _CanLose = true;
        }
        if (other.gameObject.CompareTag("Knife") && _CanLose == true)
        {
            _Restart = true;
        }
    }
}
