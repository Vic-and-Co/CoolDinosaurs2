using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;

    [SerializeField] private float speed;
    [SerializeField] private float airSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpForce;

    [SerializeField] private int boostJump = 2;


    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;

    private int jumpCount;
    private float jumpTimeCounter;
    public float jumpTime;

    private bool grounded;
    private bool jumping;
    private bool facingR;

    public static bool teleport;
    public static bool teleported;

    //Utilities
    public bool tabiOn;
    public bool aidsBootOn;
    public bool dashOn;

    public bool grappled = GrappleHook.grappled;

    //Util Modifiers
    public int aidsBootSpeed;

    //Util Cooldown

    //Keybinds
    public static KeyCode interectKey = KeyCode.F;

    void Start() {
        jumpCount = 2;

        Primary.primarySelect = "None";
        Secondary.secondarySelect = "None";
    }

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        isGrounded();
        jump();
        xMovement();
        teleportOnWorldChange();

        checkEquippables();
        checkModifiers();
    }

    private void jump() {
        if (tabiOn && !grappled) {
            if (Input.GetButtonDown("Jump") && grounded) {
                body.velocity = Vector2.up * jumpForce;
            }

            if (Input.GetButtonDown("Jump") && jumpCount < boostJump) {
                jumpTimeCounter = jumpTime;
            }
            if (Input.GetButton("Jump")) { //Jump Cut
                if (jumpTimeCounter > 0 && jumpCount < boostJump) {
                    body.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;

                } 
            }


            if (Input.GetButtonUp("Jump")) {
                jumpCount++;
            }


        } else {
            if (Input.GetButtonDown("Jump") && grounded) {

                jumpTimeCounter = jumpTime;
                body.velocity = Vector2.up * jumpForce;
            }
            if(Input.GetButton("Jump")) { //Jump Cut
                if (jumpTimeCounter > 0 && jumpCount < 1) {
                    body.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                } else {
                    jumpCount++;
                }
            }

            if(Input.GetButtonUp("Jump")) {
                jumpCount++;
            }

            
        }

        jumping = false;

    }

    private void xMovement() {
        dirFacing();
        if (grounded) {
            dashMove();
            body.velocity = new Vector3(Input.GetAxis("Horizontal") * (speed + aidsBootSpeed), body.velocity.y);
        } else {
            dashMove();
            body.velocity = new Vector3(Input.GetAxis("Horizontal") * (airSpeed + aidsBootSpeed), body.velocity.y);
        }

    }

    private void dashMove() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            print("DASH");
            if (facingR) {
                body.velocity = new Vector3(30, body.velocity.y);
                print("right");
            }
            else if (!facingR) {
                body.velocity = new Vector3(-30, body.velocity.y);

                print("left");
            }
        }
    }

    private void dirFacing() {
        if (Input.GetKey(KeyCode.D)) {
            facingR = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Input.GetKey(KeyCode.A)) {
            facingR = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void isGrounded() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if (grounded) {
            jumpCount = 0;
            jumpTimeCounter = jumpTime;
        } else {
            //jumpCount++;
        }

    }

    public static void teleportPlayer() {
        teleport = true;
        teleported = false;
    }

    private void teleportOnWorldChange() {
        if (teleport & !teleported) {
            if(WorldManager.currentGameWorld == "MainHub") {
                //change coords here -30, -63
                body.position = new Vector3(-30f, -63f);
                teleport = false;
                teleported = true;
            }
        }
    }

    private void checkEquippables() {
        tabiOn = PlayerTools.tabiOwn;
        aidsBootOn = PlayerTools.aidsBootOwn;
        dashOn = PlayerTools.dashOwn;
    }

    private void checkModifiers() {
        aidsBootSpeed = PlayerTools.aidsBootSpeed;
        grappled = GrappleHook.grappled;
    }

}
