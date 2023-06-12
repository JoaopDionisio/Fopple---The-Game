using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public SceneFader sceneFader;
    void Start()
    {
        Button restartButton = GetComponent<Button>();
        restartButton.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        Time.timeScale = 1;
        sceneFader.FadeToScene("Game");
    }
}
