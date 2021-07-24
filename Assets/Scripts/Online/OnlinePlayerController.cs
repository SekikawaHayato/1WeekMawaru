using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlinePlayerController : MonoBehaviour
{
    float moveSpeed = 5;
    float rotateSpeed = 0.3f;
    float jumpForce = 5;
    Rigidbody rigidbody;
    ParentChanger parentChanger;
    Vector3 startPosition;
    Animator animator;
    bool isPlaying =false;
    string xAxis;
    string zAxis;
    [SerializeField]
    Transform playerHead;

    bool useLeft;
    bool useRight;
    GameObject playerCamera;
    float cameraAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        parentChanger = GetComponent<ParentChanger>();
        animator = GetComponentInChildren<Animator>();
                xAxis = "Horizontal";
                zAxis = "Vertical";
                useLeft = true;
                useRight = true;
        startPosition = transform.position + new Vector3(0, 5, 0);
        playerCamera = GameObject.FindWithTag("MainCamera");
        playerCamera.transform.position = transform.position + 4 * new Vector3(Mathf.Cos(cameraAngle), 0.5f, Mathf.Sin(cameraAngle));
        playerCamera.transform.LookAt(playerHead);
    }

    float x;
    float z;
    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            x = Input.GetAxis(xAxis);
            z = Input.GetAxis(zAxis);
            cameraAngle -= x * Mathf.PI * 2 * rotateSpeed * Time.deltaTime;


            if (z != 0)
            {
                Vector3 playerForward = playerCamera.transform.forward * Mathf.Sign(z);
                playerForward.y = 0;
                transform.forward = playerForward;
            }


            transform.Translate(Mathf.Abs(z) * Vector3.forward * moveSpeed * Time.deltaTime);

            animator.SetFloat("x", x);
            animator.SetFloat("z", z);

            if (((Input.GetKeyDown(KeyCode.RightShift) && useRight) || (Input.GetKeyDown(KeyCode.LeftShift) && useLeft)) && parentChanger.isGround)
            {
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                animator.SetTrigger("Jump");
            }


        }
        playerCamera.transform.position = transform.position + 4 * new Vector3(Mathf.Cos(cameraAngle), 0.5f, Mathf.Sin(cameraAngle));
        playerCamera.transform.LookAt(playerHead);
        if (transform.position.y <= -10)
        {
            transform.position = startPosition;
        }

    }


    void GameStart()
    {
        print("Start");
        isPlaying = true;
    }
    void GameEnd()
    {
        isPlaying = false;
    }

  
}
