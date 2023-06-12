using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundaries : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject topBoundary, bottomBoundary, leftBoundary, rightBoundary;

    void Start()
    {
        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        topBoundary.transform.position = new Vector2(0, screenBounds.y + 0.5f);
        bottomBoundary.transform.position = new Vector2(0, -screenBounds.y - 0.5f);
        leftBoundary.transform.position = new Vector2(-screenBounds.x - 0.5f, 0);
        rightBoundary.transform.position = new Vector2(screenBounds.x + 0.5f, 0);

        float boundaryThickness = 1f;
        topBoundary.transform.localScale = new Vector2(screenBounds.x * 2, boundaryThickness);
        bottomBoundary.transform.localScale = new Vector2(screenBounds.x * 2, boundaryThickness);
        leftBoundary.transform.localScale = new Vector2(boundaryThickness, screenBounds.y * 2);
        rightBoundary.transform.localScale = new Vector2(boundaryThickness, screenBounds.y * 2);
    }
}