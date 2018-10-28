using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRun : Minigame<DeathRun>
{
    public Rigidbody ballPlayer1;
    public Animator cuchillosPlayer2;
    public float speedBall;
    public float speedCuchillos;
    public KitchenPlayer player;


    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (minigameEnabled)
        {
            //MOVIMIENTO CUCHILLO PLAYER 2
            if(InputManager.GetActionDown(Player.Two)) 
            {
                cuchillosPlayer2.SetTrigger("cuchillos");
            }


            if (player.End)
            {
                FinishMinigame(Player.One);
            }
            else if (player.Death)
            {
                FinishMinigame(Player.Two);
            }
        }
    
    }
    
    void FixedUpdate()
    {
        if (minigameEnabled)
        {
            //MOVIMIENTO PELOTA PLAYER 1
            ballPlayer1.velocity = transform.right * InputManager.GetHorizontalAxis(Player.One)*speedBall + ballPlayer1.velocity.y*Vector3.up;
        }
        
    }
    
}
