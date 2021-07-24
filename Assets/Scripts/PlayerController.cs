using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    float moveSpeed = 5;
    float rotateSpeed = 0.3f;
    float jumpForce = 5;
    Rigidbody rigidbody;
    ParentChanger parentChanger;
    Vector3 startPosition;
    Animator animator;
    bool isPlaying = false;
    string xAxis;
    string zAxis;
    [SerializeField]
    Transform playerHead;

    bool useLeft;
    bool useRight;
    [SerializeField]
    GameObject playerCamera;

    [SerializeField]
    float cameraAngle = 0;

    [SerializeField]
    PvPUIManager pvpUImanager;

    enum ID
    {
        Solo,
        One,
        Two
    }

    [SerializeField]
    ID id;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        parentChanger = GetComponent<ParentChanger>();
        animator = GetComponentInChildren<Animator>();
        switch (id)
        {
            case ID.Solo:
                xAxis = "Horizontal";
                zAxis = "Vertical";
                useLeft = true;
                useRight = true;
                break;
            case ID.One:
                xAxis = "1P_H";
                zAxis = "1P_V";
                useLeft = true;
                break;
            case ID.Two:
                xAxis = "2P_H";
                zAxis = "2P_V";
                useRight = true;
                break;
        }
        startPosition = transform.position+new Vector3(0,5,0);
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
            
            if (((Input.GetKeyDown(KeyCode.RightShift)&&useRight)||(Input.GetKeyDown(KeyCode.LeftShift)&&useLeft)) && parentChanger.isGround)
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

 
    void GameOver()
    {
        isPlaying = false;
    }

    void GetItem()
    {
        if (id == ID.One)
        {
            pvpUImanager.PlayerOneGetItem();
        }
        else if(id==ID.Two)
        {
            pvpUImanager.PlayerTwoGetItem();
        }
    }
    void GameStart()
    {
        isPlaying = true;
    }

}
