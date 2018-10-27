using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongManager : MonoBehaviour
{
    public GameObject ballPlayer2;
    public GameObject palaPlayer1;

    public float speedP1;
    public float speedP2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //MOVIMIENTO PALA PLAYER 1
        if (InputManager.GetVerticalAxis(Player.One) < 0)
        {
            palaPlayer1.transform.position -= new Vector3(0, speedP1, 0);
        }
        else if (InputManager.GetVerticalAxis(Player.One) > 0)
        {
            palaPlayer1.transform.position += new Vector3(0, speedP1, 0);
        }

        //MOVIMIENTO PELOTA PLAYER 2
        if (InputManager.GetHorizontalAxis(Player.Two) < 0)
        {
            ballPlayer2.transform.position -= new Vector3(speedP2, 0, 0);
        }

        else if (InputManager.GetHorizontalAxis(Player.Two) > 0)
        {
            ballPlayer2.transform.position += new Vector3(speedP2, 0, 0);
        }

        if (InputManager.GetVerticalAxis(Player.Two) < 0)
        {
            ballPlayer2.transform.position -= new Vector3(0, speedP2, 0);
        }

        else if (InputManager.GetVerticalAxis(Player.Two) > 0)
        {
            ballPlayer2.transform.position += new Vector3(0, speedP2, 0);
        }

    }
}
