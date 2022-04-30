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

    public static MomDialogue instance;

    public IEnumerator momhit()
    {
        one.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        one.SetActive(false);
        two.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        two.SetActive(false);   
    }

    private void Awake() => instance = this;
}
