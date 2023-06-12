using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuButton : MonoBehaviour
{
    public SceneFader sceneFader;
    void Start()
    {
        Button menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(LoadGameScene);
    }

    void LoadGameScene()
    {
        Time.timeScale = 1;
        sceneFader.FadeToScene("Start_Menu");
    }

}
