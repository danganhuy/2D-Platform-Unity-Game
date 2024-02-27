using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionSelect;
    [SerializeField] private GameObject lvSelect;
    public void ShowOptionSelect()
    {
        lvSelect.SetActive(false);
        optionSelect.SetActive(true);
    }
    public void ShowLevelSelection()
    {
        lvSelect.SetActive(true);
        optionSelect.SetActive(false);
    }
}