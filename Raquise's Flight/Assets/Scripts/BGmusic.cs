using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGmusic : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    
    
    public static BGmusic instance;
    public AudioSource BGM;
    
    public GameObject Boss1;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    //Add nothing right here (just cause).
    void Start()
    {
       
    

       


        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }

    }

    public void SwapTrack(AudioClip newClip)
    {

        BGM.Stop();
        BGM.clip = newClip;
        BGM.Play();

    }
    

    public void ChangeVolume()
    {
        BGM.volume = volumeSlider.value;
       
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

