using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody playerRigid;
    public float speed = default;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow) == true)
        //{
        //    playerRigid.AddForce(0f, 0f, speed);
        //}

        //if (Input.GetKey(KeyCode.DownArrow) == true)
        //{
        //    playerRigid.AddForce(0f, 0f, -speed);
        //}

        //if (Input.GetKey(KeyCode.RightArrow) == true)
        //{
        //    playerRigid.AddForce(speed, 0f, 0f);
        //}

        //if (Input.GetKey(KeyCode.LeftArrow) == true)
        //{
        //    playerRigid.AddForce(-speed, 0f, 0f);
        //}

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        // Horizontal, Vertical은 Edit의 Project Settings의 Input Manager에서 바꿀 수 있다

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        playerRigid.velocity = newVelocity;
    }       // Update()

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}       // class PlayerControler
