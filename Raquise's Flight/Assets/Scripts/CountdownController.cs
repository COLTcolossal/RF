using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    public GameObject manager;

    private void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(CountdownToStart());
        
    }

    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSecondsRealtime(1);

            countdownTime--;
        }
        if(countdownTime <= 0)
        {
            Time.timeScale = 1;
            countdownDisplay.text = "GO!";

            //manager.GetComponent<GameController>().BeginGame();

            yield return new WaitForSecondsRealtime(1);

            countdownDisplay.gameObject.SetActive(false);
        }
        
            
    }
}
