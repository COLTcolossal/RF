using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool DeadScreenActive = false;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameObject BGmusic;
    public GameObject PauseButton;
    public AudioSource pauseBGmusic;
    public GameObject pausedFirst, settingsFirst, backPausedFirst;
    public GameObject deadscreen;
    public GameObject countDown;

    void Start()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        
        if (deadscreen.activeInHierarchy == false)
        {
            PauseButton.transform.gameObject.SetActive(true);
        }

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == false)
            {
                PauseGame();
            }
            else
            {
                Resume();
            }
            
        }

        if (Input.GetKeyDown("joystick button 7"))
        {
            if (GameIsPaused == false)
            {
                PauseGame();
            }
            else
            {
                Resume();
            }

        }

        if (GameIsPaused == true)
        {
            deadscreen.SetActive(false);
        }

       

    }





    public void Resume()
    {
        if (settingsMenuUI.activeInHierarchy == false)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;



            pauseBGmusic.Play();





            if (deadscreen.activeInHierarchy == false)
            {
                PauseButton.transform.gameObject.SetActive(true);
            }
        }
    }

    public void PauseGame()
    {
       if ((deadscreen.activeInHierarchy == false) && (countDown.activeInHierarchy == false))
        {


            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            PauseButton.transform.gameObject.SetActive(false);
            if (BGmusic != null)
            {
                pauseBGmusic.Pause();
            }

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(pausedFirst);


        }

    }

    public void Settings()
    {

        settingsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsFirst);

    }

    public void BackSettings()
    {

        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(backPausedFirst);

    }


    public void LoadMenu()
    {
        Time.timeScale = 1f;       
        SceneManager.LoadScene("MainMenu");

        if (BGmusic != null)
        {
            Destroy(BGmusic);
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    

}
