using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings_Button : MonoBehaviour
{
    public SceneFader sceneFader;
    void Start()
    {
        Button settingsButton = GetComponent<Button>();
        settingsButton.onClick.AddListener(LoadGameScene);
    }

    void LoadGameScene()
    {
        sceneFader.FadeToScene("Settings");
    }

}
