using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    CharacterController controller;
    public GameObject player;
    public Animator animator;


    
    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", controller.velocity.magnitude);

    }
}
