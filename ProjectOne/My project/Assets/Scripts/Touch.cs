using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Touch : MonoBehaviour
{
    public GameObject knife;
    public GameObject point;


    private bool _HasAttack = true;
    void Update()
    {
        
    }
    IEnumerator reloadTime()
    {
        yield return new WaitForSeconds(0.3f);
        _HasAttack = true;
    }
    public void OnTouch()
    {
        if (_HasAttack == true && KnifeLogic._Restart == false)
        {
            Instantiate(knife, point.transform.position, point.transform.rotation);
            StartCoroutine(reloadTime());
            _HasAttack = false;
        }
    }
    public void RestartButton()
    {
        KnifeLogic._Restart = false;
        SceneManager.LoadScene("Game");
    }
}
