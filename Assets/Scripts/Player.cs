using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _pace = 5f;
    [SerializeField] private float _jumpHeight = 2f; 
    
    private float _gravity = -50f;
    private CharacterController _characterController;
    private float _yValue;
    private bool _groundCheck;
    private float _baseSpeed;
    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _baseSpeed = 1f;
        //transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);
        _groundCheck = Physics.CheckSphere(transform.position, 0.1f, _ground, QueryTriggerInteraction.Ignore);
        
        //if (_groundCheck && velocity.y < 0)
        //{
        //    velocity.y = 0;
        //}
        //else
        //{
        //    velocity.y += _gravity * Time.deltaTime;
        //}

        if (_groundCheck)
        {
            _yValue = 0;
        }
        else
        {
            _yValue += _gravity * Time.deltaTime;
        }

        // Let the player jump
        if (_groundCheck && Input.GetButtonDown("Jump"))
        {
            
            _yValue += Mathf.Sqrt(_jumpHeight * -2 * _gravity);
        }
        
        // Move the player forward
        //_characterController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);
        _characterController.Move(new Vector3(_baseSpeed * _pace, _yValue, 0) * Time.deltaTime);
        // Let the player jump
        //if (_groundCheck && Input.GetButtonDown("Jump"))
        //{
        //   
        //    _rosenkohl.y += Mathf.Sqrt(jumpHeight * -2 * _gravity);
        //}
        
        // (Idee: Move the player up and down on y-axis)
        //_characterController.Move(_rosenkohl * Time.deltaTime);
    }
}
