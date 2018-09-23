using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float speed = 0.15f;

    private bool moveUp, moveDown;

    int direction = 0;
    float previousPositionY;

    void Update()
    {
        if (moveUp)
            MoveUp();
        if (moveDown)
            MoveDown();

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

    public void SetMoveUp(bool moveUp)
    {
        this.moveUp = moveUp;
        this.moveDown = !moveUp;
    }

    public void StopMoving()
    {
        moveUp = moveDown = false;
    }

    void MoveDown()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - speed);
    }

    void MoveUp()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed);
    }


    void OnCollisionEnter2D(Collision2D target)
    {
        float adjust = 5 * direction;
        target.rigidbody.velocity = new Vector2(target.rigidbody.velocity.x,
            target.rigidbody.velocity.y + adjust);
    }


}
