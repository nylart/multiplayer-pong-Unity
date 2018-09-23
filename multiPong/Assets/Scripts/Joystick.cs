using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    private PlayerMovement player;
    private EnemyMovement enemy;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        enemy = GameObject.Find("Enemy").GetComponent<EnemyMovement>();
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (gameObject.name == "LeftUp")
        {
            player.StopMoving();
        }
        else if (gameObject.name == "LeftDown")
        {
            player.StopMoving();
        }

        if (gameObject.name == "RightUp")
        {
            enemy.StopMovement();
        }
        else if (gameObject.name == "RightDown")
        {
            enemy.StopMovement();
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "LeftUp")
        {
            player.SetMoveUp(true);
        }
        else if (gameObject.name == "LeftDown")
        {
            player.SetMoveUp(false);
        }

        if (gameObject.name == "RightUp")
        {
            enemy.SetMovement(true);
        }
        else if (gameObject.name == "RightDown")
        {
            enemy.SetMovement(false);
        }
    }

}
