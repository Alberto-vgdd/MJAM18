using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : Minigame<Egg>
{
    public Rigidbody ballPlayer1;
    public Transform badejaPlayer2;
    public float speedBall;
    public float speedBandeja;
    public float death = -4.5f;

    // Start is called before the first frame update
    public override void Update()
    {
        base.Update();

        if (minigameEnabled)
        {
            if (ballPlayer1.position.y <= death)
            {
                FinishMinigame(Player.Two);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (minigameEnabled)
        {
           //MOVIMIENTO PELOTA PLAYER 1
            ballPlayer1.velocity = new Vector3(InputManager.GetHorizontalAxis(Player.One) * speedBall, ballPlayer1.velocity.y, 0f);

            //MOVIMIENTO BANDEJA PLAYER 2
            badejaPlayer2.rotation *= Quaternion.Euler(0, 0, -InputManager.GetHorizontalAxis(Player.Two) * speedBandeja * Time.fixedDeltaTime);
        
            ballPlayer1.AddForce(Physics.gravity*2f,ForceMode.Acceleration);
        }
       
    }

}
