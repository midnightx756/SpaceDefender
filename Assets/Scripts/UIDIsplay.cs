using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class UIDIsplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    //ScoreKeeper scoreKeeper;
    [SerializeField]HealthScript healthpoints;
    [SerializeField] Slider healthbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        healthpoints = FindFirstObjectByType<HealthScript>();
        //scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        if(healthpoints != null)
        healthbar.maxValue = healthpoints.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreKeeper.instance != null)
            scoreText.text = ScoreKeeper.instance.getScore().ToString("000000000");
        if(healthpoints != null)
            healthbar.value = healthpoints.GetHealth();
    }
}
