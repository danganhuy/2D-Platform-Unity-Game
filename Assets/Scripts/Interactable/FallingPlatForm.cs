using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatForm : MonoBehaviour
{
    [SerializeField] private GameObject fallingPlatform;
    private Animator animator;
    private Rigidbody2D rb;
    
    private int fallingSpeed = 12;
    private int offTime = 1;
    private int fallingTime = 1;
    private int respawnTime = 2;
    private bool stepped = false;

    void Start()
    {
        animator = fallingPlatform.GetComponent<Animator>();
        rb = fallingPlatform.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && !stepped)
        {
            stepped = true;
            StartCoroutine(TurnOff());
        }
    }

    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(offTime);
        animator.SetBool("falling", true);
        rb.velocity = new Vector2(0,-fallingSpeed);

        yield return new WaitForSeconds(fallingTime);
        rb.velocity = Vector2.zero;
        fallingPlatform.SetActive(false);

        yield return new WaitForSeconds(respawnTime);
        fallingPlatform.transform.position = transform.position;
        animator.SetBool("falling", false);
        fallingPlatform.SetActive(true);
        stepped = false;
    }
}
