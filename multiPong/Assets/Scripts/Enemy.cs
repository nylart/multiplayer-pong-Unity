using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Vector3 move = Vector3.zero;

    public float Pspeed = 0.15f, AISpeed = 4.5f;
    private float upBound = 4;

    [SerializeField]
    private bool player2;

    private GameObject ball;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (player2)
            PMovement();
        else if (!player2)
            AIMovement();

        if (gameManager.startedFromP1)
            player2 = false;
        else if (!gameManager.startedFromP1)
            player2 = true;

        Bounds();
    }

    void PMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.position = new Vector2(transform.position.x,
                transform.position.y + Pspeed);
        else if (Input.GetKey(KeyCode.DownArrow))
            transform.position = new Vector2(transform.position.x,
                transform.position.y - Pspeed);
    }

    void AIMovement()
    {
        if (!ball)
            ball = GameObject.Find("Ball");

        if (ball)
        {
            float direction = ball.transform.position.y - transform.position.y;

            if (direction > 0)
                move.y = AISpeed * Mathf.Min(direction, 1.5f);
            if (direction < 0)
                move.y = -AISpeed * Mathf.Min(-direction, 1.5f);

            transform.position += move * Time.deltaTime;
        }
    }

    void Bounds()
    {
        transform.position = new Vector2(transform.position.x,
            Mathf.Clamp(transform.position.y, -upBound, upBound));
    }
}
