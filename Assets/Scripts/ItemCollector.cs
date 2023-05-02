using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int cherries = 0;
    public static int totalCherries;
    public Text cherriesText;
    [SerializeField] private AudioSource collectionSound;

    private void Start()
    {
        cherries = 0;
        cherriesText.text = "Cherries: " + cherries + "\nTotal Cherries: " + totalCherries;
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectionSound.Play();
            Destroy(collision.gameObject);
            cherries++;
            totalCherries++;
            cherriesText.text = "Cherries: " + cherries + "\nTotal Cherries: " + totalCherries;
        }
    }
}
