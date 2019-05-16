using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralManager : MonoBehaviour
{
    //____________Menu Related___________
    public GameObject Menu;
    private bool Menu_On;

    //____________Map Related___________
    public Text MapTitle;
    public Text MapScript;
    public GameObject Map;
    private bool Map_On;

    //-------____Map Locations______
    public bool Location_Bar;
    public bool Location_TownSquare;

    public GameObject Bar;
    public GameObject TownSquare;

    private GameObject CurrentPos;


    //______Reference to other scripts_____
    BackgroundManager _backgroundManager;
    public Animator Fade_Animator;

    void Start()
    {
        _backgroundManager = GetComponent<BackgroundManager>();
        //Fade_Animator = GetComponent<Animator>();
        CurrentPos = Bar;
    }

    public void Update()
    {
        OpenWindows();
        OpenMap();
    }

    void OpenWindows()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            if (Menu_On) {
                Menu.SetActive(false);
                Menu_On = false;
            }
            else {
                Menu.SetActive(true);
                Menu_On = true;
            }
        }

        //Om De kaart te openen
        if (Input.GetKeyDown(KeyCode.M)) {
            if (Map_On) {
                Map.SetActive(false);
                Map_On = false;
            }
            else {
                Map.SetActive(true);
                Map_On = true;
            }
        }
    }

    //Code om de map te openen en om locaties toe te voegen
    void OpenMap(){
       
            if (MapTitle == null) {
                MapTitle.text = "";
                MapScript.text = "-Click on a location marker to fast travel!";
            }
            else {
            if (Location_Bar) {
                MapTitle.text = "Bar";     //Schrijf hier wat je locatie naam is
                MapScript.text = "A small town bar";    //En schrijf hier wat de discriptie van de locatie is
                Location_TownSquare = false;
            }
            else if (Location_TownSquare) {
                MapTitle.text = "TownSquare";     //Schrijf hier wat je locatie naam is
                MapScript.text = "Neer the centre of town";    //En schrijf hier wat de discriptie van de locatie is
                Location_Bar = false;
            }
        }
    }

    public void SelectLocationBar()
    {
        Location_Bar = true;
        Location_TownSquare = false;
    }

    public void SelectLocationTownSquare()
    {
        Location_TownSquare = true;
        Location_Bar = false;
    }

    public void FastTravel()
    {
        Map.SetActive(false);
        Map_On = false;

        if (Location_Bar) {
            StartCoroutine(Fade(CurrentPos, Bar));
            CurrentPos = Bar;
        }
        if (Location_TownSquare) {
            StartCoroutine(Fade(CurrentPos, TownSquare));
            CurrentPos = TownSquare;
        }
    }

    public IEnumerator Fade(GameObject CurrentBG, GameObject DesiredBG)
    {
        Fade_Animator.SetBool("GoToBlack", true);
        yield return new WaitForSeconds(1);
        Fade_Animator.SetBool("GoToBlack", false);

        yield return null;
        CurrentBG.SetActive(false);
        DesiredBG.SetActive(true);
        StopAllCoroutines();
    }
}