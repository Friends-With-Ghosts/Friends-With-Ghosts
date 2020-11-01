using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ThirdPersonCharacter : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float currentSpeed = 0f;

    public float speed;
    public float sprintSpeed;
    public float gravity;

    public bool isTerrified;
    
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    

    public float speedSmoothTime = 0.3f;
    private float speedSmoothVelocity;
    public bool isGrounded = false;

    public GameObject gfx;
    Animator animator ;

    public bool isAnime = false;
    public bool isScared = false;

    public bool isReadingLore = false;



    

    private void Start() {
        animator = gfx.GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isReadingLore)
        {  
            Move();
            if(Input.GetKeyDown(KeyCode.Escape)){
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

            if(Input.GetKeyDown(KeyCode.B)){
                isAnime = !isAnime;
                animator.SetBool("isAnime", isAnime);
                speed = 10;
            }

            if(Input.GetKeyDown(KeyCode.G)){
                isScared = !isScared;
                animator.SetBool("isScared", isScared);
            }
            if(Input.GetKeyDown(KeyCode.T)){
                isTerrified = !isTerrified;
                animator.SetTrigger("Terrified");    
            }
        }
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

        Vector3 moveDir;

        if(direction != Vector3.zero)
        {
            if(Input.GetKey(KeyCode.LeftShift)){
                speed = sprintSpeed;
            } else {
                speed = 3;
            } 
            if(isAnime){
                speed = 12;
            }
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            float targetSpeed = speed * direction.magnitude;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime*2);
            // Debug.Log(currentSpeed);
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
            controller.Move(gravityVector * Time.deltaTime);
        }else {
            currentSpeed = Mathf.SmoothDamp(currentSpeed, 0, ref speedSmoothVelocity, speedSmoothTime*2);
            
        }

    
        animator.SetFloat("Speed", currentSpeed);
        

    }

    
}
