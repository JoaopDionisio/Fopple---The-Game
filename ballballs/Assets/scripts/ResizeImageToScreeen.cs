using UnityEngine;
using UnityEngine.UI;

public class ResizeImageToScreen : MonoBehaviour
{
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        Resize();
    }

    private void Update()
    {
    }

    private void Resize()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float imageWidth = image.sprite.rect.width;
        float imageHeight = image.sprite.rect.height;

        float screenRatio = screenWidth / screenHeight;
        float imageRatio = imageWidth / imageHeight;

        if (screenRatio > imageRatio)
        {
            float scale = screenHeight / imageHeight;
            image.rectTransform.sizeDelta = new Vector2(imageWidth * scale, screenHeight);
        }
        else
        {
            float scale = screenWidth / imageWidth;
            image.rectTransform.sizeDelta = new Vector2(screenWidth, imageHeight * scale);
        }
    }
}