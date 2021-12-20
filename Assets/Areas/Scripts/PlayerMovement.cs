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

    [SerializeField] private int maxJump = 1;


    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;

    private int jumpCount;

    private bool grounded;
    private bool jumping;
    private bool facingR;

    //Utilities
    public bool tabiOn;
    public bool aidsBootOn;
    public bool dashOn;

    public bool grappled = GrappleHook.grappled;

    //Util Modifiers
    public int aidsBootSpeed;

    //Util Cooldown

    void Start() {
        jumpCount = 2;

        Primary.primarySelect = " PissMan";
        Secondary.secondarySelect = " PissBaby";
    }

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        isGrounded();
        jump();
        xMovement();

        checkEquippables();
        checkModifiers();

        print("Primary is" + Primary.primarySelect);
        print("Secondary is" + Secondary.secondarySelect);
    }

    private void jump() {
        if (tabiOn && !grappled) {

            if (Input.GetButtonDown("Jump") && jumpCount < maxJump) {
                body.velocity = new Vector2(body.velocity.y, jumpHeight);
                jumpCount++;
            }

        } else {
            if (Input.GetButtonDown("Jump") && grounded) {
                body.velocity = new Vector2(body.velocity.y, jumpHeight);
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
        } else {
            //jumpCount++;
        }

    }

    private void checkEquippables() {
        tabiOn = PlayerTools.tabiOn;
        aidsBootOn = PlayerTools.aidsBootOn;
        dashOn = PlayerTools.dashOn;
    }

    private void checkModifiers() {
        aidsBootSpeed = PlayerTools.aidsBootSpeed;
        grappled = GrappleHook.grappled;
    }

}
