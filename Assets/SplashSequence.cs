using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSequence : MonoBehaviour
{

    public static int SceneNumber;

    void Start()
    {
        if (SceneNumber == 0)
        {
            StartCoroutine(ToMainMenu());
        }

        if (SceneNumber == 1)
        {
            StartCoroutine(ToControls());
        }

        if (SceneNumber == 2)
        {
            StartCoroutine(ToGame());
        }

    }


    IEnumerator ToMainMenu()
    {
        yield return new WaitForSeconds(5);
        SceneNumber = 1;
        SceneManager.LoadScene(1);
    }

    IEnumerator ToControls()
    {
        yield return new WaitForSeconds(8);
        SceneNumber = 2;
        SceneManager.LoadScene(2);
    }

    IEnumerator ToGame()
    {
        yield return new WaitForSeconds(8);
        SceneNumber = 3;
        SceneManager.LoadScene(3);
    }

}
