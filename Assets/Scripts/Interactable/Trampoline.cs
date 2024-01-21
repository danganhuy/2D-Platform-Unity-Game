using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private enum TrampolineState {Idle, Activate};
    private TrampolineState state = TrampolineState.Idle;
    private Animator animator;

    [SerializeField] private int BounceHeight = 22;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            state = TrampolineState.Activate;
            animator.SetInteger("state", (int)state);
            other.attachedRigidbody.velocity = new Vector2(other.attachedRigidbody.velocity.x, BounceHeight);
        }
    }
    private void StopBouncing()
    {
        state = TrampolineState.Idle;
        animator.SetInteger("state", (int)state);
    }
}
