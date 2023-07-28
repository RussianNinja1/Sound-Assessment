using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public int Finish;
    private IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(Finish);
    }
    void OnTriggerEnter(Collider other)
    {
        //When object with the Player tag enters finish goal collision and loads the main menu
        if (other.CompareTag("pickup"))
        {
            StartCoroutine(EndLevel());
        }
    }
}


