using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using FMOD.Studio;

public class PlayerInputHandler : MonoBehaviour
{
   //Input Action
    //[Header("Input Action Asset")]
    //[SerializeField] private InputActionAsset playerControls;

   //Movements
    [Header("Movement Speed")]
    [Tooltip("The walking speed in float")]
    [SerializeField] float walkSpeed;

    [Tooltip("The run speed in float")]
    [SerializeField] float runSpeed;

    Vector2 movePlayer;
    float runPlayer;
    float currentSpeed;

   //Gravity
    [Header("Gravity Value")]
    [Tooltip("The gravity of how fast we fall in float")]
    [SerializeField] float gravityValue;

    bool groundedPlayer;
    Vector3 playerVelocity;
    

   //Components
    CharacterController controller;
    PlayerInput playerInput;
  

    //Input Actions
    InputAction moveAction;
    InputAction runAction;
    InputAction interactAction;
  
   //Camera
    Transform cameraTransform;
    
    //Audio 
  private EventInstance FootstepsForest;
  private EventInstance FootstepsWood;
  public bool footstepsplaying;
  public bool isInside;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["move"];
        runAction = playerInput.actions["run"];
        interactAction = playerInput.actions["interact"];
    }

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        cameraTransform = Camera.main.transform;
        
        // initializing the footsteps instance
        FootstepsForest=FmodAudioManager.Instance.CreateEventInstance(FmodEvents.Instance.FootstepsForest);
        FootstepsWood = FmodAudioManager.Instance.CreateEventInstance((FmodEvents.Instance.FootstepsWood));
    }

    private void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        NewMethod();

        OnMove();
        OnRun();
        HandleFootsteps();
      
    }

    private void FixedUpdate()
    {
        //HandleFootsteps();
    }

    private void NewMethod()
    {
        Vector2 movement = movePlayer;
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        move.Normalize();
        controller.Move(move * Time.deltaTime * walkSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnMove() 
    {
        movePlayer = moveAction.ReadValue<Vector2>().normalized;
 //     movePlayer = value.Get<Vector2>().normalized;
 
    }

    private void OnRun()
    {
       runPlayer = runAction.ReadValue<float>();

        if (runPlayer > 0)
        {
            currentSpeed *= runSpeed;
        }
        else
        {
            currentSpeed *= walkSpeed;
        }
   
  
    }

    
    private void HandleFootsteps()
    {
        // Playing footsteps when the player is moving
        if (playerInput.actions["move"].ReadValue<Vector2>().magnitude > 0.1f)
        {
            // Determine the current footstep sound based on the area
            EventInstance currentFootsteps = isInside ? FootstepsForest : FootstepsWood;
            EventInstance otherFootsteps = isInside ? FootstepsWood : FootstepsForest;

            // Stop the other footstep sound to prevent overlap
            otherFootsteps.stop(STOP_MODE.ALLOWFADEOUT);

            // Play the current footstep sound if it's not already playing
            PLAYBACK_STATE playbackstate;
            currentFootsteps.getPlaybackState(out playbackstate);
            if (playbackstate.Equals(PLAYBACK_STATE.STOPPED))
            {
                currentFootsteps.start();
                footstepsplaying = true;
            }
        }
        else
        {
            // Stop both footstep sounds when the player is not moving
            FootstepsForest.stop(STOP_MODE.ALLOWFADEOUT);
            FootstepsWood.stop(STOP_MODE.ALLOWFADEOUT);
            footstepsplaying = false;
        }
    }

    public void SetFootstepArea(bool inside)
    {
        isInside = inside;
    }
}
