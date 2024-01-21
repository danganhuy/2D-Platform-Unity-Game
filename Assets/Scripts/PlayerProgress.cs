using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProgress
{
    public static int LvCount = 7;
    public static bool[] unlocked;
    public static int[] cherriesCollected;

    [System.Serializable]
    public class SaveData
    {
        public bool[] unlocked;
        public int[] cherriesCollected;
        public SaveData()
        {
            this.unlocked = PlayerProgress.unlocked;
            this.cherriesCollected = PlayerProgress.cherriesCollected;
        }
        public void DefaultData()
        {
            PlayerProgress.unlocked = new bool[LvCount];
            PlayerProgress.cherriesCollected = new int[LvCount];

            PlayerProgress.unlocked[0] = true;
            PlayerProgress.cherriesCollected[0] = 0;
            for (int i = 1; i < LvCount; i++)
            {
                PlayerProgress.unlocked[i] = false;
                PlayerProgress.cherriesCollected[i] = 0;
            }
        }
        public void LoadData(SaveData data)
        {
            PlayerProgress.unlocked = data.unlocked;
            PlayerProgress.cherriesCollected = data.cherriesCollected;
        }
    }
    public PlayerProgress(SaveData data)
    {
        PlayerProgress.unlocked = data.unlocked;
        PlayerProgress.cherriesCollected = data.cherriesCollected;
    }
    public static void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public static void LoadLevel(int level)
    {
        try
        {
            if (PlayerProgress.unlocked[level-1])
            {
                SceneManager.LoadSceneAsync(level);
            }
            else
                return;
        }
        catch 
        {
            return;
        }
    }
    public static void UnlockProcress()
    {
        PlayerProgress.unlocked[SceneManager.GetActiveScene().buildIndex] = true;
        SaveSystem.SaveGame();
    }
    public static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public static void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
