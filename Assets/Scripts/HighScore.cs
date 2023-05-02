using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField] private Text highScoreText;
    void Start()
    {
        highScoreText.text = "Your total score: " + ItemCollector.totalCherries + "\nHighScore: " + PlayerPrefs.GetInt("HighScore");
    }
}
