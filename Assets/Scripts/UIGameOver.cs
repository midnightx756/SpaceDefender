using UnityEngine;
using TMPro;
public class UIGameOver : MonoBehaviour
{
    ScoreKeeper scoreKeeper; 
    [SerializeField] TextMeshProUGUI scoreText;
    void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    void Start(){
        scoreText.text = "You Scored\n" +scoreKeeper.getScore();
    }
}
