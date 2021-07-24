using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CircleCollider2D InteractCircleCollider;
    private BoxCollider2D boxCollider;
    private Animator animator;
    private bool isPlayerWalking;
    public bool isInDialogue { get; set; }

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        InteractCircleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInDialogue)
            {
                SceneManager.Instance.dialogueManager.DisplayNextSentence();
            }
            else
            {
                CheckInteraction();
            }
        }
    }

    void FixedUpdate()
    {
        if (!isInDialogue)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            Vector3 moveDelta = new Vector3(x, y, 0);

            if (moveDelta.x > 0)
                transform.localScale = new Vector3(1, 1, 1);
            else if (moveDelta.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);

            RaycastHit2D hitCollider = Physics2D.BoxCast(transform.position,
                                            boxCollider.size,
                                            0,
                                            new Vector2(moveDelta.x, 0),
                                            Mathf.Abs(moveDelta.x * Time.deltaTime),
                                            LayerMask.GetMask("Actor", "Blocking"));

            if (hitCollider.collider == null)
            {
                transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
                if (!isPlayerWalking)
                {
                    isPlayerWalking = true;
                    animator.SetBool("is_walking", true);
                }
            }

            hitCollider = Physics2D.BoxCast(transform.position,
                                            boxCollider.size,
                                            0,
                                            new Vector2(0, moveDelta.y),
                                            Mathf.Abs(moveDelta.y * Time.deltaTime),
                                            LayerMask.GetMask("Actor", "Blocking"));

            if (hitCollider.collider == null)
            {
                transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
                if (!isPlayerWalking)
                {
                    isPlayerWalking = true;
                    animator.SetBool("is_walking", true);
                }
            }

            if (isPlayerWalking && moveDelta == Vector3.zero)
            {
                isPlayerWalking = false;
                animator.SetBool("is_walking", false);
            }
        }
        else
        {
            isPlayerWalking = false;
            animator.SetBool("is_walking", false);
        }
    }

    // TODO: If there are multiple interactions, display the player a list with all interactions available and let him choose which one to interact
    private void CheckInteraction()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, InteractCircleCollider.radius);

        if (hits.Length > 0)
        {
            foreach (Collider2D hit in hits)
            {
                if ((hit.transform.GetComponent<Interactable>()) &&
                    (hit.transform.GetComponent<Interactable>().isInteractEnable))
                {
                    hit.transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }
        }
    }
}
