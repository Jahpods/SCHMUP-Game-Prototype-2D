using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;

    private Rigidbody2D body;
    private Vector2 axisMovement;

    private void Start()
    {
        health = maxHealth;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKey(KeyCode.W) && !isMoving)
          StartCoroutine(MovePlayer(Vector3.up));

      if (Input.GetKey(KeyCode.A) && !isMoving)
          StartCoroutine(MovePlayer(Vector3.left));

      if (Input.GetKey(KeyCode.S) && !isMoving)
          StartCoroutine(MovePlayer(Vector3.down));

      if (Input.GetKey(KeyCode.D) && !isMoving)
          StartCoroutine(MovePlayer(Vector3.right));

        axisMovement.x = Input.GetAxisRaw("Horizontal");
      
    }

    private IEnumerator MovePlayer(Vector3 direction) 
    {

        isMoving = true;

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsedTime <timeToMove) 
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void CheckForFlipping()
    {
        bool movingLeft = axisMovement.x < 0;
        bool movingRight = axisMovement.x > 0;
    }
    
}
