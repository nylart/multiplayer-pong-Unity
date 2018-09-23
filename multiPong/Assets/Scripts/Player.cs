using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int direction = 0;
    float previousPositionY;

    private float upBound = 4f;
    private float speed = 0.15f;

    Transform playerTransform;

    void Start()
    {
        playerTransform = transform;
        previousPositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            MoveUp();
        else if (Input.GetKey(KeyCode.S))
            MoveDown();

        Bounds();

        if (previousPositionY > transform.position.y)
            direction = -1;
        else if (previousPositionY < transform.position.y)
            direction = 1;
        else
            direction = 0;
    }

    void LateUpdate()
    {
        previousPositionY = transform.position.y;
    }

    void MoveDown()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - speed);
    }

    void MoveUp()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed);
    }

    public void Stop()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    void Bounds()
    {
        transform.position = new Vector2(transform.position.x,
            Mathf.Clamp(transform.position.y, -upBound, upBound));
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        float adjust = 5 * direction;
        target.rigidbody.velocity = new Vector2(target.rigidbody.velocity.x,
            target.rigidbody.velocity.y + adjust);
    }
}
