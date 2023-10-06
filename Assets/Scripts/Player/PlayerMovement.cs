using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Transform mainCamera;
    private Vector3 direction;
    private CharacterController characterController;
    private float rotationTime = 0.1f;
    private float rotationSpeed;
    private float gravity = 30f;
    private float jumpSpeed = 18f;
    private float verticalMovement = 0;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        BuildSurfaceMovement();
        BuildVerticalMovement();
        characterController.Move(direction);
    }

    private void BuildSurfaceMovement()
    {
        //TODO:Get axis raw for gamepad
        //Get inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, 0f, vertical);

        //Cancel higher movement speed
        if (direction.magnitude > 1.0f) direction = direction.normalized;

        // Move only if not in deadzone
        if (direction.magnitude >= 0.1f)
        {
            //Get angle of movement
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;

            //Smooth angle
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, rotationTime);

            //Set player rotation
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //Set direction vector
            Vector3 directionWithCamera = (Quaternion.Euler(0f, angle, 0f) * Vector3.forward).normalized; 
            float originalMovementMagnitude = direction.magnitude; 
            direction.x = directionWithCamera.x * movementSpeed * originalMovementMagnitude * Time.deltaTime; 
            direction.z = directionWithCamera.z * movementSpeed * originalMovementMagnitude * Time.deltaTime;
        }
        else
        {
            //No movement
            direction = Vector3.zero;
        }
    }

    private void BuildVerticalMovement()
    {
        //Check if player jumps and is grounded
        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            verticalMovement = jumpSpeed;
        }

        //Simulate gravity
        verticalMovement -= gravity * Time.deltaTime;
        //Set direction vector
        direction.y = verticalMovement * Time.deltaTime;
    }
}
