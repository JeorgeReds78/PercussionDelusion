using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Points : MonoBehaviour
{
    
    public int score;

    public int stage;

    public static Points instance;

    public void actualizar(int score1)
    {
        score = score1;
        PlayerPrefs.SetInt("score", score);
    }

    public void actualizarS(int stage1)
    {
        stage = stage1;
        PlayerPrefs.SetInt("stage", stage1); 
    }

    private void Awake() => instance = this;
}
