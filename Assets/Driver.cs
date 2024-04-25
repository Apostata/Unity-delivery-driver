using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 150;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float slowSpeed = 5;
    [SerializeField] float fastSpeed = 15;
    float initialSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boost"))
        {
            Debug.Log("Fast" + other.gameObject.name);
            if(moveSpeed == initialSpeed){
                moveSpeed = fastSpeed;
                Task.Delay(3000).ContinueWith(t => moveSpeed = initialSpeed);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Slow" + other.gameObject.name);
         if(moveSpeed == initialSpeed){
            moveSpeed = slowSpeed;
            Task.Delay(3000).ContinueWith(t => moveSpeed = initialSpeed);
        }
    }
}
