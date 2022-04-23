using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomDialogue : MonoBehaviour
{

    [SerializeField]
    private GameObject one;

    [SerializeField]
    private GameObject two;

    public static bool momhit = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        momhit = true;
        print(momhit);
        MuevePersonaje.instance.velocidadX = 0;
        MuevePersonaje.instance.velocidadY = 0;
        StartCoroutine(mostrardialogo());
        
    }

    public IEnumerator mostrardialogo()
    {
        
        one.SetActive(momhit);
        yield return new WaitForSeconds(2.5f);
        one.SetActive(false);
        two.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        two.SetActive(false);
        MuevePersonaje.instance.velocidadX = 5;
        MuevePersonaje.instance.velocidadY = 1;


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        momhit = false;
        print(momhit);

    }
}
