using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private int level1_top; // assign the Legacy Text UI component to this variable in the Inspector
    [SerializeField] private int level2_top; // assign the Legacy Text UI component to this variable in the Inspector
    [SerializeField] private int level3_top; // assign the Legacy Text UI component to this variable in the Inspector
    [SerializeField] private int level4_top; // assign the Legacy Text UI component to this variable in the Inspector


    public GameObject gameOverCanvas;
    public GameObject BGMusic;
    public GameObject CameraObject;

    public GameObject followerPrefab; 
    public GameObject player;

    public CameraController camController;

    public static int level;

    [SerializeField]
    private AudioClip Game_Over_Sound;
    // Start is called before the first frame update
    void Start()
    {
        CameraObject = GameObject.Find("Main Camera");
        level = 1;
        gameOverCanvas.SetActive(false);
    }
    void Update()
    {
        if (scoreScript.score < level1_top && level == 2)
        {
            level = 1;
            BGMusic.GetComponent<BGMusic_Script>().playlevel(1, false);
            camController.ChangeBackgroundColor(1);
        }
        else if (scoreScript.score >= level1_top && level == 1)
        {
            level = 2;
            BGMusic.GetComponent<BGMusic_Script>().playlevel(2, false);
            camController.ChangeBackgroundColor(2);
        }
        else if (scoreScript.score < level2_top && level == 3)
        {
            level = 2;
            BGMusic.GetComponent<BGMusic_Script>().playlevel(2, false);
            camController.ChangeBackgroundColor(2);
        }
        else if (scoreScript.score >= level2_top && level == 2)
        {
            level = 3;
            BGMusic.GetComponent<BGMusic_Script>().playlevel(3, true);
            camController.ChangeBackgroundColor(3);
        }
        else if (scoreScript.score < level3_top && level == 4)
        {
            level = 3;
            BGMusic.GetComponent<BGMusic_Script>().playlevel(3, false);
            camController.ChangeBackgroundColor(3);
        }
        else if (scoreScript.score >= level3_top && level == 3)
        {
            level = 4;
            BGMusic.GetComponent<BGMusic_Script>().playlevel(4, true);
            camController.ChangeBackgroundColor(4);
        }
        else if (scoreScript.score < level4_top && level == 5)
        {
            level = 4;
            BGMusic.GetComponent<BGMusic_Script>().playlevel(4, false);
            camController.ChangeBackgroundColor(4);
        }
        else if (scoreScript.score >= level4_top && level == 4)
        {
            level = 5;
            BGMusic.GetComponent<BGMusic_Script>().playlevel(5, true);
            camController.ChangeBackgroundColor(5);
        }


    }


    // Update is called once per frame
    public void GameOver()
    {
        /*
        if (scoreScript.score > Master_Manager_Script.highscore)
        {
            Master_Manager_Script.highscore = scoreScript.score;
            WriteToFile("Highscore", Master_Manager_Script.highscore.ToString());
        }
        */
        AudioSource.PlayClipAtPoint(Game_Over_Sound, CameraObject.transform.position, 0.5f);


        Debug.Log("GAME OVER");
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;


    }
    void Awake()
    {
        // Make this object persistent
        //DontDestroyOnLoad(gameObject);
    }
    void WriteToFile(string filename, string text)
    {
        // Delete the file if it exists
        if (File.Exists(filename))
        {
            File.Delete(filename);
        }
        // Append the text to the file or create a new file if it doesn't exist
        using (StreamWriter writer = new StreamWriter(filename, true))
        {
            writer.WriteLine(text);
        }
    }
}
