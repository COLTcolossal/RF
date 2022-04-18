using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public static SoundManager instance;
    public static AudioClip coinPickUpSound, playerHurt, shootSound, GatXplode, explode, enemyHit, spawnThing, powerUp, GCxplode; //Add commas then more sound for epicness.
    static AudioSource audioSrc;

   void Start()
    {
       
        
        coinPickUpSound = Resources.Load<AudioClip>("coinPickUp");
        playerHurt = Resources.Load<AudioClip>("playerHurt");
        shootSound = Resources.Load<AudioClip>("GunShot");
        GatXplode = Resources.Load<AudioClip>("gatXplode");
        explode = Resources.Load<AudioClip>("explosionEffectSFX");
        enemyHit = Resources.Load<AudioClip>("hitHurt");
        spawnThing = Resources.Load<AudioClip>("SpawnThing");
        powerUp = Resources.Load<AudioClip>("powerUp");
        GCxplode = Resources.Load<AudioClip>("GCxplode");
        audioSrc = GetComponent<AudioSource>();

        if (!PlayerPrefs.HasKey("soundVolume"))
        {
            PlayerPrefs.SetFloat("soundVolume", 1);
            Load();
        }
        else
        {
            Load();
        }

    }
    
    public static void PlaySound (string clip)
    {
        switch (clip) 
        {
            case "coinPickUp":
                audioSrc.PlayOneShot(coinPickUpSound);
                break;

            case "playerHurt":
                audioSrc.PlayOneShot(playerHurt);
                break;

            case "GunShot":
                audioSrc.PlayOneShot(shootSound);
                break;

            case "gatXplode":
                audioSrc.PlayOneShot(GatXplode);
                break;
            case "explosionEffectSFX":
                audioSrc.PlayOneShot(explode);
                break;
            case "hitHurt":
                audioSrc.PlayOneShot(enemyHit);
                break;

            case "SpawnThing":
                audioSrc.PlayOneShot(spawnThing);
                break;

            case "powerUp":
                audioSrc.PlayOneShot(powerUp);
                break;

            case "GCxplode":
                audioSrc.PlayOneShot(GCxplode);
                break;
        }
    }
    
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeVolumeSound()
    {
        audioSrc.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("soundVolume", volumeSlider.value);
    }

}
