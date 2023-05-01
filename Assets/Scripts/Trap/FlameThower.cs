using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThower : MonoBehaviour
{
    [SerializeField] private float delay = 0;

    private Animator animator;
    private bool activated = true;

    private int turnOn = 2;
    private int turnOff = 3;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(SwitchState());
    }

    IEnumerator SwitchState()
    {
        yield return new WaitForSeconds(turnOff);
        activated = false;
        animator.SetBool("activate", false);
        this.gameObject.tag = "Untagged";

        yield return new WaitForSeconds(turnOn);
        activated = true;
        animator.SetBool("activate", true);

        StartCoroutine(SwitchState());
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        Debug.Log(activated);
        Debug.Log(this.gameObject.tag);
        if (other.gameObject.name == "Player" && activated)
        {
            this.gameObject.tag = "Trap";
        }
    }
}
