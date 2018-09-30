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
    private GameObject leftSide;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        leftSide = GameObject.Find("Player");
    }

    void Update()
    {
        if (player2)
            PMovement();
        else if (!player2)
            AIMovement();

        if (gameManager.startedFromP1 || gameManager.startedFromAI)
            player2 = false;
        else if (!gameManager.startedFromP1 && !gameManager.startedFromAI)
            player2 = true;

        if (gameManager.startedFromAI)
        {

            leftSide.GetComponent<PlayerMovement>().enabled = false;
            leftSide.GetComponent<Player>().enabled = false;
            leftSide.GetComponent<EnemyMovement>().enabled = true;
            leftSide.GetComponent<Enemy>().enabled = true;
        }

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
