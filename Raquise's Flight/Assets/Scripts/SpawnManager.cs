using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject MG;
    public GameObject CN;
    public GameObject SG;
    public GameObject BP;
    public GameObject GatCurse;

    public GameObject Gatlens;

    
   // public GameObject bGmusic;


    void Start()
    {
        MG.SetActive(false);
        CN.SetActive(false);
        SG.SetActive(false);
        BP.SetActive(false);
        GatCurse.SetActive(false);
        Gatlens.SetActive(false);

        StartCoroutine(MGpwr());
        StartCoroutine(CNpwr());
        StartCoroutine(SGpwr());
        StartCoroutine(BPpwr());
        
        StartCoroutine(Gatlen());
        StartCoroutine(GatlenCurse());
        
        //StartCoroutine(GatlenCurse2());
       // StartCoroutine(GatlenCurse3());

    }

    
    void Update()
    {
        
    }

    private IEnumerator MGpwr()
    {

        yield return new WaitForSeconds(17);
        MG.SetActive(true);
    }


    private IEnumerator CNpwr()
    {

        yield return new WaitForSeconds(40);
        CN.SetActive(true);
    }

    private IEnumerator SGpwr()
    {

        yield return new WaitForSeconds(30);
        SG.SetActive(true);
    }

    private IEnumerator BPpwr()
    {

        yield return new WaitForSeconds(50);
        BP.SetActive(true);
    }

    private IEnumerator GatlenCurse()
    {

        yield return new WaitForSeconds(4);
        GatCurse.SetActive(true);
    }

   

    private IEnumerator Gatlen()
    {

        yield return new WaitForSeconds(2);
        Gatlens.SetActive(true);
    }

}
