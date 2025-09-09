using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 8f;
    public float runSpeed = 12f;
    public float jumpPower = 8f;

    public float mouseSensitivity = 1f;
    public float gravityModifier = 2f;

    public CharacterController controller;
    public Transform cameraTrans;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    public bool invertX;
    public bool invertY;
    private bool canJump;

    private Vector3 moveInput;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        getInput();


    }

    public void getInput() {
        //Initial gravity?
        float yStore = moveInput.y;

        //Handle Movement
        //GetAxis gives a bit of glide, GetAxisRaw, stops player fast
        Vector3 vertMove = transform.forward * Input.GetAxisRaw("Vertical");
        Vector3 horiMove = transform.right * Input.GetAxisRaw("Horizontal");
        moveInput = (horiMove + vertMove);
        moveInput.Normalize();

        //Handle running or walking
        Vector3 runningOrWalking = (Input.GetKey(KeyCode.LeftShift)) ? moveInput += moveInput * runSpeed : moveInput += moveInput * moveSpeed;
        //moveInput += moveInput * moveSpeed;


        moveInput.y = yStore;
        moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;

        if (controller.isGrounded) {
            moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
        }

        canJump = Physics.OverlapSphere(groundCheckPoint.position, .25f, whatIsGround).Length > 0;

        //Handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && canJump) {
            moveInput.y = jumpPower;
        }

        controller.Move(moveInput * Time.deltaTime);

        

        //Control Camera rotaion
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        //Inverting, but why would u...
        if (invertX) {
            mouseInput.x = -mouseInput.x;
        }
        if (invertY) {
            mouseInput.y = -mouseInput.y;
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        //-mouseInput, to prevent it to invert
        cameraTrans.rotation = Quaternion.Euler(cameraTrans.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));
    }
}
