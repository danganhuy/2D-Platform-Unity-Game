using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int cherries;
    public InGameMenu text;
    [SerializeField] private AudioSource collectionSound;
    private void Start()
    {
        cherries = 0;
        text.UpdateText(cherries);
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectionSound.Play();
            Destroy(collision.gameObject);
            cherries++;
            text.UpdateText(cherries);
        }
    }
}
