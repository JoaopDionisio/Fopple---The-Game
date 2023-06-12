using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscoreScript : MonoBehaviour
{
    [SerializeField] private Text highscoreText; // assign the Legacy Text UI component to this variable in the Inspector
    private int highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore = Master_Manager_Script.highscore;
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
