using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionalMotion : MonoBehaviour
{
    Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    float accelaration = 0.05f;
    float deceleration = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("z")){
            if ( velocityZ < 0.5f){
                 velocityZ += accelaration;
            }else{
                if (!Input.GetKey("c")){
                    velocityZ = 0.5f;
                }
            }
            velocityX = 0;
            animator.SetFloat("Blend",velocityZ);
            animator.SetFloat("Example",velocityX);
        }else{
            velocityZ = 0;
            animator.SetFloat("Blend",velocityZ);
            animator.SetFloat("Example",velocityX);  
        }

        if (velocityZ > 0 && Input.GetKey("c")){
            if (velocityZ < 2f){
                velocityZ += accelaration;
            }else{
                velocityZ = 2f;
            }
            velocityX = 0;
            animator.SetFloat("Blend",velocityZ);
            animator.SetFloat("Example",velocityX);
        }else{
            animator.SetFloat("Blend",velocityZ);
            animator.SetFloat("Example",velocityX); 
        }

        if (Input.GetKey("x")){
            if (velocityX < 0.5f){
                velocityX += accelaration;
            }else{
                if (!Input.GetKey("b"))velocityX = 0.5f;
            }
            velocityZ = 0;
            animator.SetFloat("Example",velocityX);
            animator.SetFloat("Blend",velocityZ); 
        }else{
            if (!Input.GetKey("v"))velocityX = 0;
            animator.SetFloat("Example",velocityX);
            animator.SetFloat("Blend",velocityZ); 
        }

        if (velocityX > 0 && Input.GetKey("b")){
            if (velocityX < 2f){
                velocityX += accelaration;
            }else{
                velocityX = 2f;
            }
            velocityZ = 0;
            animator.SetFloat("Example",velocityX);
            animator.SetFloat("Blend",velocityZ); 
        }else{
            animator.SetFloat("Example",velocityX);
            animator.SetFloat("Blend",velocityZ); 
        }

        if (Input.GetKey("v")){
            if (velocityX > -0.5f){
                velocityX -= deceleration;
            }else{
                if (!Input.GetKey("n"))velocityX = -0.5f;
            }
            velocityZ = 0;
            animator.SetFloat("Example",velocityX);
            animator.SetFloat("Blend",velocityZ); 
        }else{
            if (!Input.GetKey("x"))velocityX = 0;
            animator.SetFloat("Example",velocityX);
            animator.SetFloat("Blend",velocityZ); 
        }

        if (velocityX < 0 && Input.GetKey("n")){
            if (velocityX > -2f){
                velocityX -= deceleration;
            }else{
                velocityX = -2f;
            }
            velocityZ = 0;
            animator.SetFloat("Example",velocityX);
            animator.SetFloat("Blend",velocityZ); 
        }else{
            animator.SetFloat("Example",velocityX);
            animator.SetFloat("Blend",velocityZ); 
        }
        
        
    }
}
