using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLevel : MonoBehaviour
{
    [SerializeField] private GameObject lvSelect;
    public void ShowLevelSelection()
    {
        lvSelect.SetActive(true);
    }
}