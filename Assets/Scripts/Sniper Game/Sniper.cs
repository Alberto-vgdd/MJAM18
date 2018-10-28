﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Minigame<Sniper>
{
    private const float recoveryTime = 1f;

    [Header("Sniper Parameters.")]
    public Rigidbody ballPlayer1;
    public Rigidbody sniperPlayer2;
    public Transform scope;
    public float speedBall;
    public float jumpBall;
    public float speedSniper;

    private bool puedeSaltar;

    private bool shootInput;
    private bool shooting;
    private bool shootAvailable;
    private float recoveryTimer;

    public override void StartMinigame()
    {
        // Initialize the base minigame.
        base.StartMinigame();


        recoveryTimer = 0f;
        shootAvailable = true;
        shooting = false;

        puedeSaltar = true;
    }

    public override void Update()
    {
        // Take time into account.
        base.Update();


        
        if (!shootAvailable)
        {
            recoveryTimer += Time.deltaTime;
            if (recoveryTimer >= recoveryTime)
            {
                shootAvailable = true;
            }
        }

        if (InputManager.GetActionDown(Player.Two))
        {
            if (shootAvailable)
            {
                shooting = true;
                shootAvailable = false;
            }
            else
            {
                // Play shoot unavailable.
            }
        }

    }

    void FixedUpdate()
    {
        if (minigameEnabled)
        {
            //MOVIMIENTO PELOTA PLAYER 1
            ballPlayer1.velocity = new Vector3(InputManager.GetHorizontalAxis(Player.One) * speedBall, ballPlayer1.velocity.y, InputManager.GetVerticalAxis(Player.One) * speedBall);

            if (InputManager.GetActionDown(Player.One) && puedeSaltar) 
            {
                ballPlayer1.velocity += new Vector3(0, jumpBall, 0);
                puedeSaltar = false;
            }

            else if (puedeSaltar == false && ballPlayer1.velocity.y == 0) 
            { 
                puedeSaltar = true;
            }

            //MOVIMIENTO SNIPER PLAYER 2
            sniperPlayer2.velocity = new Vector3(InputManager.GetHorizontalAxis(Player.Two) * speedSniper, InputManager.GetVerticalAxis(Player.Two) * speedSniper,0);

            if (shooting)
            {
                Vector3 origin = Camera.main.transform.position;
                Vector3 direction = scope.position - origin;

                RaycastHit[] raycastHits = Physics.RaycastAll(origin,direction.normalized,1000f,LayerMask.GetMask("Balloon"));
                Debug.Log(raycastHits.Length);
                if (raycastHits.Length > 0)
                {
                    foreach(RaycastHit hit in raycastHits)
                    {
                        hit.transform.gameObject.SetActive(false);
                        // Play confeti.

                        if (hit.transform.tag.Equals("Player"))
                        {
                            FinishMinigame(Player.Two);
                        }
                    }

                    // Play ballon pop sound
                }
                else
                {
                    // Play shoot.
                }
                

                shooting = false;
                recoveryTimer = 0f;
            }
        }
    }
}
    