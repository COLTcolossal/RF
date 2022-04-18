using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1Music : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    private static BGmusic bgMusic;
    static AudioSource audioSrc;
    public static AudioClip Boss1music;
    

    void Awake()
    {


    }
    //Add nothing right here (just cause).
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        
        Boss1music = Resources.Load<AudioClip>("JesusReturn");
        //audioSrc.Play();

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "JesusReturn":
                audioSrc.PlayOneShot(Boss1music);
                break;

         
        }
    }

    public void ChangeVolume()
    {
        audioSrc.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    void Update()
    {

    }
}
