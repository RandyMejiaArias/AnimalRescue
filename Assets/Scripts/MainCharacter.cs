using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    public float rotateSpeed = 100.0f;
    public float runSpeed;
    public Animator animator;
    public float x, y;

    public float initialSpeed;
    public float crouchedSpeed;

    public bool iAmCrouched;
    public int characterLevel;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        initialSpeed = movementSpeed;
        crouchedSpeed = movementSpeed * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * rotateSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * movementSpeed);

        animator.SetFloat("SpeedX", x);
        animator.SetFloat("SpeedY", y);

        if(Input.GetKey(KeyCode.LeftShift) && !iAmCrouched) {
            runSpeed = initialSpeed * 1.5f;
            movementSpeed = runSpeed;
            if(y != 0)
                animator.SetBool("Running", true);
            else 
                animator.SetBool("Running", false);
        } else {
            animator.SetBool("Running", false);
            if(iAmCrouched)
                movementSpeed = crouchedSpeed;
            else
                movementSpeed = initialSpeed;
        }

        if(Input.GetKey(KeyCode.LeftControl)) {
            animator.SetBool("Crouched", true);
            iAmCrouched = true;
        } else {
            animator.SetBool("Crouched", false);
            iAmCrouched = false;
        }
    }
}
