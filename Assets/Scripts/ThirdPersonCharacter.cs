using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacter : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float currentSpeed = 0f;

    public float speed;
    public float gravity;
    
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    

    public float speedSmoothTime = 0.3f;
    private float speedSmoothVelocity;
    public bool isGrounded = false;

    public GameObject gfx;
    Animator animator ;

    

    private void Start() {
        animator = gfx.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
     
    }

    void Move(){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 gravityVector = Vector3.zero;

        if(!controller.isGrounded)
        {
            gravityVector.y -= gravity;
        }  

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            float targetSpeed = speed * direction.magnitude;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
            controller.Move(gravityVector * Time.deltaTime);
        }

        animator.SetFloat("Speed", direction.magnitude, speedSmoothTime, Time.deltaTime );

    }
}
