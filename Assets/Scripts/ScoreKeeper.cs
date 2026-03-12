using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;
    public static ScoreKeeper instance { get; private set; }
    void Awake(){
        ManageSingleton();
    }

    void ManageSingleton(){
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int getScore()
    {
        return score;
    }

    public void modifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
       // Debug.Log(score);
    }

    public void resetScore()
    {
        score = 0;
    }
}
