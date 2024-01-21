using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource fininshSound;
    private bool levelCompeleted = false;
    [SerializeField] private InGameMenu finishMenu;
    private void Start()
    {
        fininshSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompeleted)
        {
            fininshSound.Play();
            levelCompeleted = true;
            Invoke("completeLevel", 2f);
        }
    }

    private void completeLevel()
    {
        finishMenu.FinishMenu();
    }
}
