using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool startedFromP1;
    public bool startedFromAI;

    void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private Button player1Btn, player2Btn, AIbtn, rightUp, rightDown, leftUp, leftDown;

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (!player1Btn)
            {
                player1Btn = GameObject.Find("1Player").GetComponent<Button>();
                player1Btn.onClick.AddListener(VSAI);
            }

            if (!player2Btn)
            {
                player2Btn = GameObject.Find("2Player").GetComponent<Button>();
                player2Btn.onClick.AddListener(VSPlayer2);
            }

            if (!AIbtn)
            {
                AIbtn = GameObject.Find("AIvAI").GetComponent<Button>();
                AIbtn.onClick.AddListener(AI);
            }

        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (!rightDown)
                rightDown = GameObject.Find("RightDown").GetComponent<Button>();

            if (!rightUp)
                rightUp = GameObject.Find("RightUp").GetComponent<Button>();

            if (!leftDown)
                leftDown = GameObject.Find("LeftDown").GetComponent<Button>();

            if (!leftUp)
                leftUp = GameObject.Find("LeftUp").GetComponent<Button>();

            if (startedFromP1)
            {
                rightDown.gameObject.SetActive(false);
                rightUp.gameObject.SetActive(false);
            }
            else if (startedFromAI)
            {
                rightDown.gameObject.SetActive(false);
                rightUp.gameObject.SetActive(false);
                leftDown.gameObject.SetActive(false);
                leftUp.gameObject.SetActive(false);
            }
            else
            {
                rightDown.gameObject.SetActive(true);
                rightUp.gameObject.SetActive(true);
            }
        }
    }

    // load game for 1 player
    void VSAI()
    {
        startedFromP1 = true;
        SceneManager.LoadScene("Gameplay");
    }

    // load game for 2 player
    void VSPlayer2()
    {
        startedFromP1 = false;
        SceneManager.LoadScene("Gameplay");
    }

    void AI()
    {
        startedFromP1 = false;
        startedFromAI = true;
        SceneManager.LoadScene("Gameplay");
    }

}
    
