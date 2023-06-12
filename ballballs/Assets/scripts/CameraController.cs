using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ChangeBackgroundColor(int level)
    {
        switch (level)
        {
            case 1:
                gameObject.GetComponent<Camera>().backgroundColor = new Color32(65, 167, 180, 255);
                break;
            case 2:
                gameObject.GetComponent<Camera>().backgroundColor = new Color32(65, 180, 125, 255);
                break;
            case 3:
                gameObject.GetComponent<Camera>().backgroundColor = new Color32(180, 65, 120, 255);
                break; 
            case 4:
                gameObject.GetComponent<Camera>().backgroundColor = new Color32(0, 0, 0, 255);
                break;
            case 5:
                gameObject.GetComponent<Camera>().backgroundColor = new Color32(28, 35, 239, 255);
                break; 

        }
    }
}
