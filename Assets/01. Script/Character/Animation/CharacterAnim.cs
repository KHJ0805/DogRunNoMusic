using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("WigglingTail");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioSource collisionSound = GetComponent<AudioSource>();
        if (collision.gameObject.CompareTag("Object"))
        {
            collisionSound.Play();
            animator.Play("AngryStart");
        }
    }
}
