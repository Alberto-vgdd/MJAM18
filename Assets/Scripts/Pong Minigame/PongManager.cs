using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongManager : MonoBehaviour
{
    public GameObject ballPlayer2;
    public GameObject palaPlayer1;

    public float speedP1;
    public float speedP2;

    // Update is called once per frame
    void Update()
    {

        //MOVIMIENTO PALA PLAYER 1
        palaPlayer1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, InputManager.GetVerticalAxis(Player.One) * speedP1);

        //MOVIMIENTO PELOTA PLAYER 2
        ballPlayer2.GetComponent<Rigidbody2D>().velocity = new Vector2(InputManager.GetHorizontalAxis(Player.Two) * speedP2, InputManager.GetVerticalAxis(Player.Two) * speedP2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            //SE LLAMA A TRANSICIÓN
        }
    }
}
