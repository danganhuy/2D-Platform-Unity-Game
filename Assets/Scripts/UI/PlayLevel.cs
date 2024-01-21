using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayLevel : MonoBehaviour
{
    [SerializeField] private Button[] bt;
    public void CheckButtonState()
    {
        for (int i=0; i<PlayerProgress.LvCount; i++)
        {
            if (PlayerProgress.unlocked[i])
                bt[i].interactable = true;
            else
                bt[i].interactable = false;
        }
    }
    public void LoadLevel(int level)
    {
        PlayerProgress.LoadLevel(level);
    }
}
