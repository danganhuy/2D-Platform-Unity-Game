using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSave : MonoBehaviour
{
    [SerializeField] private PlayLevel obj;
    void Start()
    {
        SaveSystem.LoadGame();
        obj.CheckButtonState();
    }
}
