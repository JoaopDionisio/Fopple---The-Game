using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public SceneFader sceneFader;

    void Start()
    {
        Button startButton = GetComponent<Button>();
        startButton.onClick.AddListener(LoadGameScene);
    }

    void LoadGameScene()
    {
        sceneFader.FadeToScene("Game");
    }

}