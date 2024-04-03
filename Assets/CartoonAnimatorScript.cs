using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartoonAnimatorScript : MonoBehaviour
{
    Animator animator;
    float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float decceleration = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool fowardPress = Input.GetKey("r");
        if (fowardPress && velocity < 1.0f){
            velocity += Time.deltaTime * acceleration;
        }      
        if (!fowardPress && velocity > 0.0f){
            velocity -= Time.deltaTime * decceleration;
        }   

        if ( !fowardPress && velocity < 0.0f){
            velocity = 0.0f;
        }   
        animator.SetFloat("Blend",velocity);


        // bool walking = Input.GetKey("q");
        // bool isWalking = animator.GetBool("isWalking");
        // bool running = Input.GetKey("r");
        // bool isRunning = animator.GetBool("isRunning");

        // // if (Input.GetAxis('Vertical')){
        // //     animator.SetBool("isWalking",true);
        // // }

        // if (!isWalking && walking){
        //     animator.SetBool("isWalking",true);
        // }

        // if (isWalking && Input.GetKeyDown("x") ){
        //     animator.SetBool("isWalking",false);
        // }
        // if (!isRunning && (walking && running)){
        //     animator.SetBool("isRunning",true);
        // }

        // if (isRunning && Input.GetKeyDown("v")){
        //     animator.SetBool("isRunning",false);
        // }
    }
}
