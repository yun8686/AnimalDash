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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 vc = characterRigidBody.position;
            vc.x = -.5f;
            characterRigidBody.position = vc;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 vc = characterRigidBody.position;
            vc.x = .5f;
            characterRigidBody.position = vc;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 vc = characterRigidBody.position;
            vc.x = 0;
            characterRigidBody.position = vc;
        }

        Vector3 moveVector = Vector3.zero;
        if (Input.GetMouseButtonDown(0))
        {
            Jump(ref moveVector);
        }
        if (MAX_SPEED > characterRigidBody.velocity.z)
        {
            moveVector.z = SPEED;
        }
        else
        {
            characterRigidBody.velocity = new Vector3(
                characterRigidBody.velocity.x,
                characterRigidBody.velocity.y,
                30
                );
            MAX_SPEED = 30;
        }
        characterRigidBody.AddForce(moveVector);
        mainCamera.transform.position = new Vector3(0, (float)(transform.position.y + 1.8), (float)(transform.position.z - 6));
    }

    void Jump(ref Vector3 moveVector)
    {
        moveVector.y = JUMP;
    }
}
