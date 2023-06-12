using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic_Script : MonoBehaviour
{

    public AudioSource source1;

    public AudioClip intro_level1;
    public AudioClip level1;
    public AudioClip level2;
    public AudioClip intro_level3;
    public AudioClip level3;
    public AudioClip intro_level4;
    public AudioClip level4;

    public float Music_Volume;

    private void Start()
    {
        Music_Volume = Master_Manager_Script.instance.backgroundMusicVolume;
        source1 = GetComponent<AudioSource>();
        Debug.Log("Music Volume: " + Music_Volume);
        source1.volume = Music_Volume / 5;

        playlevel(1, true);
    }
    void Update()
    {


    }

    public void playlevel(int level, bool intro)
    {
        switch (level)
        {
            case 1:
                source1.loop = false;
                StartCoroutine(PlayNextClipAfterCurrent(intro_level1, intro, level1));
                break;
            case 2:
                source1.loop = false;
                StartCoroutine(PlayNextClipAfterCurrent(level2, false, level2));
                break;
            case 3:
                source1.loop = false;
                StartCoroutine(PlayNextClipAfterCurrent(intro_level3, intro, level3));
                break;
            case 4:
                source1.loop = false;
                StartCoroutine(PlayNextClipAfterCurrent(intro_level4, intro, level4));
                break;
            default:
                break;
        }
    }


    private IEnumerator PlayNextClipAfterCurrent(AudioClip introclip, bool intro, AudioClip nextclip)
    {

        if (intro)
        {
            while (source1.isPlaying)
            {
                yield return null;
            }
            source1.clip = introclip;
            source1.volume = Music_Volume / 5;
            source1.loop = true;
            source1.Play();

            source1.loop = false;
            yield return new WaitForSeconds(introclip.length); // Wait for the current clip to finish playing
            source1.clip = nextclip;
            source1.volume = Music_Volume / 5;
            source1.loop = true;
            source1.Play();
            
        }
        else
        {
            while (source1.isPlaying)
            {
                yield return null;
            }
            source1.clip = nextclip;
            source1.volume = Music_Volume / 5;
            source1.loop = true;
            source1.Play();
        }


    }
}
