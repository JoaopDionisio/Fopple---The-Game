using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit_Button : MonoBehaviour
{
    void Start()
    {
        Button quitButton = GetComponent<Button>();
        quitButton.onClick.AddListener(QuitGame);
    }

    void QuitGame()
    {
        StartCoroutine(DelayedLoad());
    }

    IEnumerator DelayedLoad()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        Application.Quit();
    }
}
