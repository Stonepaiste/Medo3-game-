using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.InputSystem.Controls;
using Cinemachine;
using UnityEditor.ShaderGraph.Internal;

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
    InputAction lookAction;
    InputAction runAction;
    InputAction flashlightAction;
    InputAction interactAction;
  
   //Camera
    Transform cameraTransform;

    //Audio 
    private EventInstance _flashlightOn;
    private EventInstance _flashlightOff;
    private EventInstance FootstepsForest;
    private EventInstance FootstepsWood;
    public bool footstepsplaying;
    public bool isInside;

    //Flashlight
    bool flashlightOnOff = false;
    Light lightSource;
    [SerializeField] float range = 100f; // Adjust the radius as needed
    public Transform lightPoint;
    CinemachineBrain PlayerPOVCamera;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["move"];
        lookAction = playerInput.actions["look"];
        runAction = playerInput.actions["run"];
        flashlightAction = playerInput.actions["flashlight"];
        interactAction = playerInput.actions["interact"];
        lightSource = this.gameObject.GetComponentInChildren<Light>();
        PlayerPOVCamera = FindObjectOfType<CinemachineBrain>();
        lightSource.enabled = false;
    }

    private void Start()
    {
        LockAndHideCursor();

        cameraTransform = Camera.main.transform;
        // initializing the footsteps instance
        FootstepsForest =FmodAudioManager.Instance.CreateEventInstance(FmodEvents.Instance.FootstepsForest);
        FootstepsWood = FmodAudioManager.Instance.CreateEventInstance((FmodEvents.Instance.FootstepsWood));
    }

    private void Update()
    {
        /*if (Cursor.lockState != CursorLockMode.Locked || Cursor.visible)
        {
            LockAndHideCursor();
        }
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            LockAndHideCursor();
        }*/

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        Move();
        HandleFootsteps();
        HandleFlashlight(flashlightOnOff);
        Look();

    }

    private void LockAndHideCursor()
    {
        /*Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false;*/               // Make the cursor invisible
    }

    /*private void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            LockAndHideCursor();
        }
    }*/

    private void Move()
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
    }

    void OnLook()
    {

    }

    void Look()
    {
        lightPoint.transform.rotation = PlayerPOVCamera.transform.rotation;
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

    private void OnFlashlight()
    {
        flashlightOnOff = !flashlightOnOff;
        Debug.Log("This works");
    }

    private void HandleFlashlight(bool flashlightOnOff)
    {
        if (flashlightOnOff)
        {
            lightSource.enabled = true;
            Debug.Log("Flashlight is on");
            Flashlight();
            _flashlightOn.start();
            _flashlightOn = RuntimeManager.CreateInstance(FmodEvents.Instance.FlashlightOn);
        }
        else if (!flashlightOnOff)
        {
            lightSource.enabled = false;
            Debug.Log("Flashlight is off");
            _flashlightOff.start();
            _flashlightOff = RuntimeManager.CreateInstance(FmodEvents.Instance.FlashlightOff);
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
            otherFootsteps.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

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
            FootstepsForest.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            FootstepsWood.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            footstepsplaying = false;
        }
    }

    void Flashlight()
    {
        RaycastHit hit;

        //Burning shadowmonsters if raycast hits object with tag "Enemy"
        if (Physics.Raycast(lightPoint.position, lightPoint.transform.forward, out hit, range) && hit.transform.tag == "Enemy")
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            target.TakeDamage();
            Debug.DrawLine(lightPoint.position, hit.point, Color.yellow);  //Debug line for raycast
            //AudioLibrary.PlaySound("Burn");
        }
    }

        public void SetFootstepArea(bool inside)
    {
        isInside = inside;
    }
}
