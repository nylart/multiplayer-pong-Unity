using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private ScoreManager scoreManager;

    private Rigidbody2D myBody;

    private int scores;
    public float speedValue = 4.5f;

    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        myBody = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
        myBody.AddForce(new Vector2(-speedValue * 50, 0));
    }

    void Update()
    {
        Bounds();
    }

    void Bounds()
    {
        if (transform.position.x > 7.7f)
        {
            scores = 1;
            StartCoroutine(StartOverAgain());
            scoreManager.AddScoreToPlayer1();
        }
        else if (transform.position.x < -7.7f)
        {
            scores = 0;
            StartCoroutine(StartOverAgain());
            scoreManager.AddScoreToEnemy();
        }
    }

    void NewStart()
    {
        if (scores == 1)
        {
            myBody.AddForce(new Vector2(speedValue * 50, 0));
        }
        else if (scores == 0)
        {
            myBody.AddForce(new Vector2(-speedValue * 50, 0));
        }
    }

    void GoBack()
    {
        transform.position = Vector2.zero;
        myBody.velocity = Vector2.zero;
    }

    IEnumerator StartOverAgain()
    {
        GoBack();
        yield return new WaitForSeconds(1.5f);
        NewStart();
    }

}
