using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 1f;

    private void Start()
    {
        fadeImage.gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        fadeImage.gameObject.SetActive(true);
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeIn()
    {
        fadeImage.canvasRenderer.SetAlpha(1f);
        fadeImage.CrossFadeAlpha(0f, fadeSpeed, false);
        yield return new WaitForSecondsRealtime(fadeSpeed);
        fadeImage.gameObject.SetActive(false);
    }

    IEnumerator FadeOut(string sceneName)
    {
        fadeImage.canvasRenderer.SetAlpha(0f);
        fadeImage.CrossFadeAlpha(1f, fadeSpeed, false);
        yield return new WaitForSecondsRealtime(fadeSpeed);
        SceneManager.LoadScene(sceneName);
    }
}