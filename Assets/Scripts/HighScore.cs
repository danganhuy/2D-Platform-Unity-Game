using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField] private Text highScoreText;
    void Start()
    {
        if (ItemCollector.totalCherries > PlayerPrefs.GetInt("HighScore")/* || PlayerPrefs.GetInt("HighScore") == null*/)
            PlayerPrefs.SetInt("HighScore", ItemCollector.totalCherries);
        highScoreText.text = "Your total score: " + ItemCollector.totalCherries + "\nHighScore: " + PlayerPrefs.GetInt("HighScore");
    }
}
