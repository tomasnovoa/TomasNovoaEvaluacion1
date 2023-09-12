using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;


public class Player : MonoBehaviour
{
    public float force;
    public float velocity = 5; 
    private bool OnDown = true;
    private Rigidbody rb;
    private Vector2 input;
    public StudioEventEmitter pasos;
    private bool audiorun;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    private void Update()
    {
        OnDown = Physics.Raycast(transform.position, Vector3.down,0.6f);
    }
    
    private void FixedUpdate()
    {
      
        Vector3 velocity = new Vector3 (input.x, 0, 0);
        rb.position += (velocity * Time.fixedDeltaTime );

       
       
        
    }

    private void OnEnable()
    {
        InputManager.OnJump += HandleJumped;
        InputManager.OnPlayerMovement += HandleMovement;
        InputManager.OnPause += HandlePause;
    }

    private void OnDisable()
    {
        InputManager.OnJump -= HandleJumped;
        InputManager.OnPlayerMovement -= HandleMovement;
        InputManager.OnPause -= HandlePause;
    }
    private void HandleMovement(Vector2 input)
    {
        this.input = input;
        
        if (input == Vector2.zero && audiorun)
        {
            pasos.Stop();
            audiorun = false;
            
        }
        else
        {
            pasos.Play();
            audiorun = true;
        }

    }
    private void HandleJumped(bool a)
    {
        if (a)
        { 
            if (OnDown)
            {
                rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            }
        }
    }
    private void HandlePause()
    {
        
            Time.timeScale = 0;
        
        

    }



}
