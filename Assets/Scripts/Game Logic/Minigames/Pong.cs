using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong : Minigame<Pong>
{
    public Rigidbody2D ballPlayer2;
    public Rigidbody2D palaPlayer1;
    
    public float speedP1;
    public float speedP2;

    public float xPosition = -118.7f;


    void FixedUpdate()
    {
        if (minigameEnabled)
        {
            //MOVIMIENTO PALA PLAYER 1
            palaPlayer1.velocity = new Vector2(0, InputManager.GetVerticalAxis(Player.One) * speedP1);

            //MOVIMIENTO PELOTA PLAYER 2
            ballPlayer2.velocity = new Vector2(InputManager.GetHorizontalAxis(Player.Two) * speedP2, InputManager.GetVerticalAxis(Player.Two) * speedP2);
        
            if (ballPlayer2.position.x < xPosition)
            {
                FinishMinigame(Player.Two);
            }
        }
        
    }

    
}
