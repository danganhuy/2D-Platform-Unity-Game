using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    private bool GameIsPause = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject finishMenu;
    [SerializeField] private GameObject option;
    private AudioSource MusicAudio;
    private AudioSource[] SoundAudio;
    private void GetAudioSource()
    {
        MusicAudio = GameObject.Find("BG Music").GetComponent<AudioSource>();
        SoundAudio = GameObject.Find("Player").GetComponents<AudioSource>();
    }
    private void Start()
    {
        GetAudioSource();
        GameIsPause = false;
        Time.timeScale = 1f;
        UpdateVolume();
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
        GameObject cherriesText = GameObject.Find("/Canvas/Text");
        cherriesText.GetComponent<Text>().text = "Cherries: " + cherries;
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
            UpdateVolume();
        }
    }

    [System.Obsolete]
    public void Option()
    {
        option.SetActive(!option.active);
    }
    public void BackToMenu()
    {
        PlayerProgress.ToMenu();
    }
    public void UpdateVolume()
    {
        MusicAudio.volume = Volume.musicVolume;
        foreach (AudioSource sound in SoundAudio)
        {
            sound.volume = Volume.soundVolume;
        }
        Debug.Log($"Music: {Volume.musicVolume}");
        Debug.Log($"Music: {MusicAudio.volume}");
        Debug.Log($"Sound: {Volume.soundVolume}");
        Debug.Log($"Sound: {SoundAudio[1].volume}");
    }
}
