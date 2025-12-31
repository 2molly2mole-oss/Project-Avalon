using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreenHandlerScript : MonoBehaviour
{

    [SerializeField] float lengh_for_wait;    
    float alpha = 0f;
    [SerializeField] GameObject Fade_screen;
    Color fade_color;
    public bool Screen_is_hid;
   

    public void Start_delay()
    {
        alpha = 0f;
        StopAllCoroutines();
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(lengh_for_wait);
        alpha = alpha + 0.01f;
        fade_color.a = alpha;
        Fade_screen.GetComponent<Image>().color = fade_color;
        if (Fade_screen.GetComponent<Image>().color.a <= 1f)
        {
            StartCoroutine(Fade());
        }
        else
        {
            StartCoroutine(delay());
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1);
        Screen_is_hid = true;
        StartCoroutine(UnFade());
        StartCoroutine(screenishidDelay());
    }

    IEnumerator screenishidDelay()
    {
        yield return new WaitForSeconds(3);
        Screen_is_hid = false;
    }


    IEnumerator UnFade()
    {
        yield return new WaitForSeconds(lengh_for_wait);
        alpha = alpha - 0.01f;
        fade_color.a = alpha;
        Fade_screen.GetComponent<Image>().color = fade_color;

        StartCoroutine(UnFade());        
    }
}

