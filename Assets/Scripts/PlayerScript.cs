using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody characterRigidBody;
    Animator animator;
    Vector3 moveDirection = Vector3.zero;

    public float GRAVITY;
    public float JUMP;
    public float SPEED;
    public float MAX_SPEED;

    public GameObject mainCamera;

    private int nowPos = 0; //left:-1, center:0, right:1

    // Start is called before the first frame update
    void Start()
    {
        characterRigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 場所の移動
        if (Input.GetKeyDown(KeyCode.LeftArrow)) MoveLeft();
        else if (Input.GetKeyDown(KeyCode.RightArrow)) MoveRight();
        else if (Input.GetKeyDown(KeyCode.UpArrow)) MoveCenter();

        Vector3 moveVector = Vector3.zero;
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            Debug.Log("タッチ位置"+ Input.mousePosition + "画面幅" + Screen.width);
            float x = Input.mousePosition.x;
            float n = Screen.width / 3;
            int newPos = 0;
            if (x < n) newPos = -1;
            else if (x < n * 2) newPos = 0;
            else newPos = 1;

            if(newPos != nowPos)
            {
                switch (newPos)
                {
                    case -1: MoveLeft(); break;
                    case 0: MoveCenter(); break;
                    case 1: MoveRight(); break;
                }
            }
            else
            {
                Jump(ref moveVector);
            }
        }

        // 速度制限
        if (MAX_SPEED > characterRigidBody.velocity.z)
        {
            moveVector.z = SPEED;
        }
        characterRigidBody.AddForce(moveVector);
        mainCamera.transform.position = new Vector3(0, (float)(transform.position.y + 1.8), (float)(transform.position.z - 6));
    }

    void Jump(ref Vector3 moveVector)
    {
        moveVector.y = JUMP;
    }

    const float moveSize = .5f;
    void MoveLeft()
    {
        Vector3 vc = characterRigidBody.position;
        vc.x = -moveSize;
        nowPos = -1;
        characterRigidBody.position = vc;
    }
    void MoveRight()
    {
        Vector3 vc = characterRigidBody.position;
        vc.x = moveSize;
        nowPos = 1;
        characterRigidBody.position = vc;
    }
    void MoveCenter()
    {
        Vector3 vc = characterRigidBody.position;
        vc.x = 0f;
        nowPos = 0;
        characterRigidBody.position = vc;
    }
}
