
using UnityEngine;

public class ScaleWithScreen : MonoBehaviour
{
    public float targetScreenHeight = 388f; // Set the target screen height
    public float targetScale = 0.4f; // Set the target scale for the target screen height

    void Start()
    {
        float screenHeight = Screen.height;
        float scale = targetScale * (screenHeight / targetScreenHeight);
        transform.localScale = new Vector3(scale, scale, scale);
    }
}