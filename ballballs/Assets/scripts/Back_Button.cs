using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Back_Button : MonoBehaviour
{
    public SceneFader sceneFader;

    void Start()
    {
        Button backButton = GetComponent<Button>();
        backButton.onClick.AddListener(LoadGameScene);
    }

    void LoadGameScene()
    {
        sceneFader.FadeToScene("Start_Menu");
    }

}
