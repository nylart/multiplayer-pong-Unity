using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private bool moveUp, moveDown;
    private float Pspeed = .15f;

    void Update()
    {
        if (moveUp)
            MoveUp();
        if (moveDown)
            MoveDown();
    }

    public void SetMovement(bool move)
    {
        this.moveUp = move;
        this.moveDown = !move;
    }

    public void StopMovement()
    {
        moveDown = moveUp = false;
    }

    void MoveUp()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + Pspeed);
    }

    void MoveDown()
    {
        transform.position = new Vector2(transform.position.x,
            transform.position.y - Pspeed);
    }
}
