using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool startedFromP1;

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

    private Button player1Btn, player2Btn, rightUp, rightDown;

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

        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (!rightDown)
                rightDown = GameObject.Find("RightDown").GetComponent<Button>();

            if (!rightUp)
                rightUp = GameObject.Find("RightUp").GetComponent<Button>();


            if (startedFromP1)
            {
                rightDown.gameObject.SetActive(false);
                rightUp.gameObject.SetActive(false);
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

}
    
