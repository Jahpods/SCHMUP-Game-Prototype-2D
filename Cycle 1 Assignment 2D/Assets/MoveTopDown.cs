using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTopDown : MonoBehaviour
{
    private Vector3 position;
    private float rotateSpeed = 500.0f;
    private float speed = 500.0f;
    private float tilt = 1.0f;

    void Update()
    {
        position = transform.position;

        //Move();

        transform.position = position;
    }

    void FixedUpdate()
    {
        MovePhysics();

        //MoveTank();

        //LookAtMouse();

        //Tilt();
    }

    private void Move()
    {
        if (Input.GetKey("w"))
        {
            position.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            position.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            position.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            position.x += speed * Time.deltaTime;
        }
    }

    private void MovePhysics()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal, moveVertical, 0.0f);
        GetComponent<Rigidbody2D>().velocity = move * speed * Time.fixedDeltaTime;
    }

    private void MoveTank()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.back * moveHorizontal * rotateSpeed * Time.fixedDeltaTime);
        GetComponent<Rigidbody>().velocity = moveVertical * transform.up * speed * Time.fixedDeltaTime;
    }

    private void LookAtMouse()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        float moveVertical = Input.GetAxis("Vertical");
        GetComponent<Rigidbody>().velocity = moveVertical * transform.up * speed * Time.fixedDeltaTime;
    }

    private void Tilt()
    {
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * tilt * -1);
    }
}
