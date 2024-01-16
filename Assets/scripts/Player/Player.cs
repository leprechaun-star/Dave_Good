using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    // This is just for the movemnt of the player and the mouse
    private Vector3 moveDirection;
    private Vector2 playerLook;
    private float xRot;

    // This is for the force and the exeloration of the player and camera speed
    [Header("Player")]
    [SerializeField] private Transform GroundTransform;
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] public LayerMask GroundMask;
    
    [Space]
    
    [SerializeField] public float Speed;
    [SerializeField] public float WalkSpeed;
    [SerializeField] public float CrouchSpeed;
    [SerializeField] public float SprintSpeed;
    [SerializeField] public float Sensitivity;
    [SerializeField] public float Jumpforce;

    [Space]

    [SerializeField] public float GroundedDrag;

    [Space]

    [SerializeField] public bool CanCrouch;
    [SerializeField] public bool CanJump;
    [SerializeField] public bool canSprint;
    
    [Header("Player Move stuff")]
    [SerializeField] public PlayerMoevementActions Playercontrolls;
    private InputAction move;
    private InputAction look;
    private InputAction Jump;
    private InputAction Sprint;
    private InputAction crouching;
    
    [Space]
    
    [Header("Stats")]
    [SerializeField] public float curHp;
    [SerializeField] public float maxHp;
    [SerializeField] public float DoHealth = 5;
    [SerializeField] public bool Heal;
    
    [Space]
    
    [Header("Crouching")]
    [SerializeField] public bool isCrouching;
    [SerializeField] public Vector3 Standing;
    [SerializeField] public Vector3 Sneaking;
    [SerializeField] public GameObject CamStanding;
    [SerializeField] public GameObject CamSneaking;

    [Space]

    [SerializeField] public float ObjectEnter;
    [SerializeField] public float CheckChecker;
    [SerializeField] public GameObject CrouchCheck;
    [SerializeField] public GameObject PlayerCheck;


    private void Start()
    {
        //this does something
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;

        //this is for the Health Bar UI
        curHp = maxHp;
        PlayerBody = GetComponent<Rigidbody>();
    }

    void Awake()
    {
        Playercontrolls = new PlayerMoevementActions();
    }

    private void OnEnable()
    {
        move = Playercontrolls.Player.Move;
        look = Playercontrolls.Player.Look;
        Jump = Playercontrolls.Player.Jump;
        Sprint = Playercontrolls.Player.Sprint;
        crouching = Playercontrolls.Player.Crouch;
        move.Enable();
        look.Enable();
        Jump.Enable();
        Sprint.Enable();
        crouching.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        look.Disable();
        Jump.Disable();
        Sprint.Disable();
        crouching.Disable();
    }

    private void Update()
    {
        moveDirection = new Vector3(move.ReadValue<Vector3>().x, 0f, move.ReadValue<Vector3>().y);
        playerLook = look.ReadValue<Vector2>() * Time.fixedDeltaTime;

        MovePlayerCamera();
        CrouchMovement();
        Health();
        ControlSpeed();
        MovePlayer();

        if (CanJump)
        {
            PlayerBody.drag = GroundedDrag;
        }
        else
        {
            PlayerBody.drag = 0;
        }


        float playerdistance = Vector3.Distance(CrouchCheck.transform.position, transform.position);
        float EgnorPlayer = Vector3.Distance(PlayerCheck.transform.position, CrouchCheck.transform.position);

        if (playerdistance >= ObjectEnter)
        {
            if (EgnorPlayer >= ObjectEnter)
            {
                if (Physics.CheckSphere(CrouchCheck.transform.position, ObjectEnter))
                {
                    CanCrouch = false;
                }
                else
                {
                    CanCrouch = true;
                }
            }
            else
            {
                CanCrouch = true;
            }
        }

    }

    private void FixedUpdate()
    {
        
    }

    private void MovePlayer()
    {

        //PlayerBody.velocity = new Vector3(MoveVertor.x, PlayerBody.velocity.y, MoveVertor.z);

        Vector3 MoveVertor = transform.TransformDirection(moveDirection) * Speed;
        PlayerBody.AddForce(MoveVertor * 10f, ForceMode.Force);

        //jumping
        if (Jump.WasPressedThisFrame())
        {
            if (CanJump)
            {
                PlayerBody.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
            }
        }

        if (Physics.CheckSphere(GroundTransform.position, 0.25f, GroundMask)){
            CanJump = true;
        }
        else{
            CanJump = false;
        }

        if (canSprint)
        {
            //sprinting
            if (Sprint.IsPressed())
            {
                Speed = SprintSpeed;
            }
            else
            {
                Speed = WalkSpeed;
            }
        }
    }

    private void ControlSpeed()
    {
        Vector3 flatVal = new Vector3(PlayerBody.velocity.x, 0f, PlayerBody.velocity.z);

        if(flatVal.magnitude >= Speed)
        {
            Vector3 limited = flatVal.normalized * Speed;

            PlayerBody.velocity = new Vector3(limited.x, PlayerBody.velocity.y, limited.z);
        }
    }

    private void Health()
    {
        //regaining health
        if (Heal && DoHealth <= 0)
        {
            curHp += Time.fixedDeltaTime + 0.075f;

            if (curHp >= maxHp)
            {
                Heal = false;
                DoHealth = 5;
            }
        }

        if (Heal)
        {
            DoHealth -= Time.fixedDeltaTime;
        }
    }
    
    public void CrouchMovement()
    {
        if (crouching.WasPressedThisFrame())
        {
            isCrouching = !isCrouching;
        }

        if (CanCrouch)
        {
            if (isCrouching)
            {
                GetComponent<CapsuleCollider>().height = 2f;
                GetComponent<CapsuleCollider>().center = Sneaking;
                PlayerCamera.position = CamSneaking.transform.position;
                canSprint = false;
                Speed = CrouchSpeed;
            }
            else
            {
                GetComponent<CapsuleCollider>().height = 3f;
                GetComponent<CapsuleCollider>().center = Standing;
                PlayerCamera.position = CamStanding.transform.position;
                canSprint = true;
            }
        }
        
    }

    private void MovePlayerCamera()
    {
        xRot -= playerLook.y * Sensitivity;

        transform.Rotate(0f, playerLook.x * Sensitivity, 0f);
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }

    public void TakeDamage(int damage)
    {
        curHp -= damage;
        Heal = true;
    }

    public void GiveHealth (int amountToGive)
    {
        curHp = Mathf.Clamp(curHp + amountToGive, 0, maxHp);
    }

}