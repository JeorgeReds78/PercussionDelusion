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

    [SerializeField]
    private GameObject three;

    public static MomDialogue instance;

    public IEnumerator momhit()
    {
        one.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        one.SetActive(false);
        two.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        two.SetActive(false);
        three.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        three.SetActive(false);
    }

    private void Awake() => instance = this;
}
