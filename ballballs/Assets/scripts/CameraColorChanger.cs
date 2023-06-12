using UnityEngine;
using System.Collections;

public class CameraColorChanger : MonoBehaviour
{
    public Color[] colors;
    public float fadeDuration = 1f;
    public float waitDuration = 1f; // The time to wait after the fade is complete

    private int currentColorIndex = 0;
    private Camera cameraComponent;

    private void Start()
    {
        cameraComponent = GetComponent<Camera>();
        cameraComponent.backgroundColor = colors[currentColorIndex];
        StartCoroutine(ColorCycle());
    }

    private IEnumerator ColorCycle()
    {
        while (true)
        {
            // Wait for the fade to complete
            yield return StartCoroutine(FadeToColor(colors[currentColorIndex], fadeDuration));

            // Wait for the specified time
            yield return new WaitForSeconds(waitDuration);

            // Switch to the next color
            currentColorIndex++;
            if (currentColorIndex >= colors.Length)
            {
                currentColorIndex = 0;
            }
        }
    }

    private IEnumerator FadeToColor(Color targetColor, float duration)
    {
        Color initialColor = cameraComponent.backgroundColor;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            cameraComponent.backgroundColor = Color.Lerp(initialColor, targetColor, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        cameraComponent.backgroundColor = targetColor;
    }
}