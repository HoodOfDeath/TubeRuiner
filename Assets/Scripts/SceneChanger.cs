using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("TubeRuiner");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}