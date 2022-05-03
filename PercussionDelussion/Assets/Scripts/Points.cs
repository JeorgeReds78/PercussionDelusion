using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    
    public int score;

    public static Points instance;

    public void actualizar(int score1)
    {
        score = score1;
        PlayerPrefs.SetInt("score", score);
    }

    private void Awake() => instance = this;
}
