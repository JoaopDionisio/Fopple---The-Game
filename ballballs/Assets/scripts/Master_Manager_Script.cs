using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Master_Manager_Script : MonoBehaviour
{
    public static Master_Manager_Script instance;
    public static int highscore;
    public float backgroundMusicVolume;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BGMusicSetter(float value)
    {
        backgroundMusicVolume = value;
    }
    private void Awake()
    {
        backgroundMusicVolume = 0.5f;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    int ReadFromFile(string filename)
    {
        // Read the contents of the file
        using (StreamReader reader = new StreamReader(filename))
        {
            string contents = reader.ReadToEnd();
            int intValue;
            if (int.TryParse(contents, out intValue))
            {
                return intValue;
            }
            else
            {
                Debug.LogError("Failed to parse contents of file as integer: " + filename);
                return 0;
            }
        }
    }

}
