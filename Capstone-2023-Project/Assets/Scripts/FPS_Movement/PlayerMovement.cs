using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

// basic fps movement, taken from brackeys video
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform playerBody;

    public float baseSpeed = 12f;
    public float slideSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 4f;
    public float momentumIncrease;
    public float momentumIncreaseDecay = .1f;
    public float momentumDecrease;
    public float momentumDecreaseDelay;
    public float momentumMax;
    public float momentumSlideMax;

    // ref to groundchecking obj
    public Transform groundCheck;
    public float groundDist = 0.4f;
    public LayerMask groundMask;
    [SerializeField]
    float coyoteTime;

    Vector3 velocity;
    bool isGrounded;
    public bool isSliding {get; private set;}
    delegate Vector3 MoveFunction();
    MoveFunction move;
    [SerializeField]
    float momentum;
    Vector3 slideDirection;     // not resetting correctly
    bool slideSet;
    float momentumDecreaseTimer = 0;
    [SerializeField]
    float slideHeightBuffer = .5f;
    float internalMomentumIncrease;
    [SerializeField]
    Text momentumText;
    public bool moveEnabled = true;


/* TODO: use events for this bc the ui and the camera and whatever else needs to 
know about sliding are compltely different and they can just 
recieve an event instead of having to reference this class 

    UnityEvent slideStartEvent, slideStopEvent;

    void Start() {
        if(slideStartEvent == null) {
            slideStartEvent = new UnityEvent();
        }
        slideStartEvent.AddListener(SlideStart);
        if(slideEndEvent == null) {
            slideEndEvent = new UnityEvent();
        }
        slideEndEvent.AddListener(SlideEnd);

    }

*/

    void Update()
    {
        if (moveEnabled) {
            UpdateMovement();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("testRoom");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Level1 Test");
        }
    }

    void UpdateMovement() {
        if (Physics.CheckSphere(groundCheck.position, groundDist, groundMask)) {
            isGrounded = true;
        } else {
            StartCoroutine(CoyoteTimer());
        }

        // checking if grounded
        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Slide")) {
            isSliding = true;
            internalMomentumIncrease = momentumIncrease;
        }
        bool jumpRaycastResult = Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), slideHeightBuffer, groundMask);
        //Debug.Log(jumpRaycastResult);
        if (Input.GetButtonUp("Slide") || !jumpRaycastResult) { 
            isSliding = false; 
        }

        if (isSliding && isGrounded) {
            move = SlideMovement;
        } else {
            move = BaseMovement;
        }
        controller.Move(move() * Time.deltaTime);

        // jump controls
        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isGrounded = false;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        // demo screen print
        // momentumText.text = "Momentum: " + momentum;
    }

    Vector3 GetInputDirection() {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        return transform.right * x + transform.forward * z;
    }

    Vector3 BaseMovement() {
        // base movement checks
        if (momentum != 1 && isGrounded) {
            if (momentumDecreaseTimer <= 0)
            {
                momentum -= momentumDecrease;
                if (momentum < 1) {
                    momentum = 1;
                }
            } else {
                momentumDecreaseTimer -= 1 * Time.deltaTime;
            }
        }
        if (slideSet) {
            slideDirection = Vector3.zero;
            slideSet = false;
        }
        // horizontal movement
        return GetInputDirection() * baseSpeed * momentum;
    }

    Vector3 SlideMovement() {
        if (momentum <= momentumMax) {
            momentum += internalMomentumIncrease;
            internalMomentumIncrease *= momentumIncreaseDecay;
            if (momentum > momentumMax) {
                momentum = momentumMax;
            }
            momentumDecreaseTimer = momentumDecreaseDelay;
        }
        if (!slideSet) {
            slideDirection = GetInputDirection();
            Debug.Log(slideDirection);
            if (slideDirection.Equals(Vector3.zero)) {
                Debug.Log("Getting direction from rotation");
                slideDirection = transform.forward;
            }
            slideSet = true;
        }
        return slideDirection * slideSpeed;
    }

    IEnumerator CoyoteTimer() {
        yield return new WaitForSeconds(coyoteTime);
        isGrounded = false;
    }

}
