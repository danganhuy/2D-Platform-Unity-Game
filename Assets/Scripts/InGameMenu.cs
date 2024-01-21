using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    private bool GameIsPause = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject finishMenu;
    [SerializeField] private Text cherriesText;

    private void Start()
    {
        GameIsPause = false;
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }
    public void UpdateText(int cherries)
    {
        cherriesText.text = "Cherries: " + cherries;
    }
    public void Restart()
    {
        PlayerProgress.RestartLevel();
    }
    public void Next()
    {
        PlayerProgress.NextLevel();
    }
    public void FinishMenu()
    {
        finishMenu.SetActive(true);
        GameIsPause = true;
        Time.timeScale = 0f;
    }
    public void PauseMenu()
    {
        if(!GameIsPause)
        {
            pauseMenu.SetActive(true);
            GameIsPause = true;
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            GameIsPause = false;
            Time.timeScale = 1f;
        }
    }
    public void BackToMenu()
    {
        PlayerProgress.ToMenu();
    }
}
