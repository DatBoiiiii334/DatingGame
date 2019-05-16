using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    //public GameObject Background1;
    //public GameObject Background2;

    //private Animator Fade_Animator;


    private void Start()
    {
        //Fade_Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            //StartCoroutine(Fade(Background1,Background2));
        }
    }


    //public IEnumerator Fade(GameObject CurrentBG, GameObject DesiredBG)
    //{
    //    Fade_Animator.SetBool("GoToBlack", true);
    //    yield return new WaitForSeconds(1);
    //    Fade_Animator.SetBool("GoToBlack", false);

    //    yield return null;
    //    CurrentBG.SetActive(false);
    //    DesiredBG.SetActive(true);
    //    StopAllCoroutines();
    //}
}
