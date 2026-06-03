using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public static Controller Instance { get; private set; }

    [SerializeField] GameObject WaterLine;
    [SerializeField] TMP_Text TimerTxt;

    #region clouds
    [SerializeField] GameObject Cloud1;
    [SerializeField] GameObject Cloud2;
    [SerializeField] GameObject Cloud3;
    [SerializeField] GameObject Cloud4;
    [SerializeField] GameObject Cloud5;
    [SerializeField] GameObject Cloud6;
    [SerializeField] GameObject Cloud7;
    [SerializeField] GameObject Cloud8;
    #endregion

    [SerializeField] GameObject Druppie1;
    [SerializeField] GameObject Druppie2;
    [SerializeField] GameObject Druppie3;
    [SerializeField] GameObject Druppie4;

    bool tutorial;
    int tutorialClicks;
    int timer = 61;
    float waterlvl = 2;
    public float baseWaterlvlChange = 0.02f;
    public float waterlvlChange = 0.02f;
    private int amount = 0;
    private int amountActualPump = 0;


    public List<GameObject> pumps = new List<GameObject>();
    public List<GameObject> actualPumps = new List<GameObject>();
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        tutorial = true;
        Tutorial();

    }
    void TrueStart()
    {
        StartCoroutine(WaterRise());
        StartCoroutine(Timer());
        pumps.Clear();
        GameObject[] foundPumps = GameObject.FindGameObjectsWithTag("Pump");
        pumps.AddRange(foundPumps);
    }
    // Update is called once per frame
    void Update()
    {
        if (waterlvl <= 0 || waterlvl >= 9)
        {
            GameOver();
        }
    }
    public void OnMouseDown()
    {
        Debug.Log("test");
        if (tutorial == true)
        {
            tutorialClicks++;
            Tutorial();
        }
        else
        {
            return;
        }
        
    }

    public void Tutorial()
    {
        switch (tutorialClicks)
        {

            case 0:
                Druppie1.SetActive(true);
                break;

            case 1:
                Druppie2.SetActive(true);
                Druppie1.SetActive(false);
                break;
            case 2:
                Druppie3.SetActive(true);
                Druppie2.SetActive(false);
                break;
            case 3:
                Druppie4.SetActive(true);
                Druppie3.SetActive(false);
                break;
            case 4:
                TrueStart();
                Druppie4.SetActive(false);
                break;


        }
    }

    public void WaterSpeed(bool Destroy)
    {
        Debug.Log("waterspeed");
        pumps.Clear();
        GameObject[] foundPumps = GameObject.FindGameObjectsWithTag("Pump");
        pumps.AddRange(foundPumps);
        actualPumps.Clear();
        GameObject[] foundactualPumps = GameObject.FindGameObjectsWithTag("ActualPump");
        actualPumps.AddRange(foundactualPumps);
        amount = 0;
        amountActualPump = 0;
        waterlvlChange = baseWaterlvlChange;
        foreach (GameObject pump in pumps)
        {
            amount++;
        }
        foreach (GameObject actualPump in actualPumps)
        {
            amountActualPump++;
        }
        if (Destroy == false)
        {
            waterlvlChange = 0.02f * (amount - amountActualPump) + baseWaterlvlChange;
        }
        else
        {
            //amount--;
            waterlvlChange = 0.02f * (amount - amountActualPump) + baseWaterlvlChange;
        }


    }

    IEnumerator WaterRise()
    {
        while (waterlvl <= 10)
        {
            waterlvl += waterlvlChange;
            WaterLine.transform.localScale = new Vector3(2, waterlvl, 2);
            yield return new WaitForSeconds(0.1f);
        }

    }

    IEnumerator Timer()
    {
        while (timer > 0)
        {
            timer--;
            TimerTxt.text = timer.ToString();
            yield return new WaitForSecondsRealtime(1);

            WaterSpeed(false);
            switch (timer)
            {
                case 60:
                    Cloud1.SetActive(true);
                    Cloud2.SetActive(true);
                    break;

                case 50:
                    baseWaterlvlChange = 0.04f;
                    Cloud1.SetActive(true);
                    Cloud2.SetActive(true);
                    Cloud3.SetActive(true);
                    Cloud4.SetActive(true);
                    break;

                case 40:
                    baseWaterlvlChange = -0.02f;
                    Cloud1.SetActive(false);
                    Cloud2.SetActive(false);
                    Cloud3.SetActive(false);
                    Cloud4.SetActive(false);
                    Cloud5.SetActive(false);
                    Cloud6.SetActive(false);
                    Cloud7.SetActive(false);
                    Cloud8.SetActive(false);
                    break;

                case 30:
                    baseWaterlvlChange = 0.06f;
                    Cloud1.SetActive(true);
                    Cloud2.SetActive(true);
                    Cloud3.SetActive(true);
                    Cloud4.SetActive(true);
                    Cloud5.SetActive(true);
                    Cloud6.SetActive(true);
                    Cloud7.SetActive(true);
                    Cloud8.SetActive(true);
                    break;

                case 20:
                    baseWaterlvlChange = 0.02f;
                    Cloud3.SetActive(false);
                    Cloud4.SetActive(false);
                    Cloud5.SetActive(false);
                    Cloud6.SetActive(false);
                    Cloud7.SetActive(false);
                    Cloud8.SetActive(false);
                    break;

                case 10:
                    baseWaterlvlChange = 0.04f;
                    Cloud3.SetActive(true);
                    Cloud4.SetActive(true);
                    break;


            }
            /*if (timer == 50)
            {
                baseWaterlvlChange = 0.04f;
            }*/
        }
            if (timer <= 0)
            {
                GameWin();
            }
        
    }

    private void GameOver()
    {
        SceneManager.LoadScene("DefeatScene");
    }

    private void GameWin()
    {
        SceneManager.LoadScene("WinScene");
    }
}
