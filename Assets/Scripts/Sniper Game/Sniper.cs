using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public GameObject ballPlayer1;
    public GameObject sniperPlayer2;
    public float speedBall;
    public float jumpBall;
    public float speedSniper;

    private bool puedeSaltar;

    // Start is called before the first frame update
    void Start()
    {
        puedeSaltar = true;
    }

    // Update is called once per frame
    void Update()
    {
        //MOVIMIENTO PELOTA PLAYER 1
        ballPlayer1.GetComponent<Rigidbody>().velocity = new Vector3(InputManager.GetHorizontalAxis(Player.One) * speedBall, ballPlayer1.GetComponent<Rigidbody>().velocity.y, InputManager.GetVerticalAxis(Player.One) * speedBall);

        if (InputManager.GetActionDown(Player.One) && puedeSaltar) {
            ballPlayer1.GetComponent<Rigidbody>().velocity += new Vector3(0, jumpBall, 0);
            puedeSaltar = false;
        }

        else if (puedeSaltar == false && ballPlayer1.GetComponent<Rigidbody>().velocity.y == 0) { puedeSaltar = true; }

        //MOVIMIENTO SNIPER PLAYER 2
        sniperPlayer2.GetComponent<Rigidbody>().velocity = new Vector3(InputManager.GetHorizontalAxis(Player.Two) * speedSniper, InputManager.GetVerticalAxis(Player.Two) * speedSniper,0);
    }
}
