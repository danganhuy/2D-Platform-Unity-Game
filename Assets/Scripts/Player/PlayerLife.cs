using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator animator;
    private bool dead = false;

    [SerializeField] private AudioSource deathSound;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.CompareTag("Trap") && !dead)
        {
            Die();
            dead = true;
        }
    }

    private void Die()
    {
        deathSound.Play();
        rigid.bodyType = RigidbodyType2D.Static;
        ItemCollector.totalCherries -= ItemCollector.cherries;
        animator.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
