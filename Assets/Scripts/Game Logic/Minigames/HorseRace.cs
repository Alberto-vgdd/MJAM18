using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseRace : Minigame<HorseRace>
{

    [Header("Horse Minigame Parameters.")]
    public Transform horse;
    public float velocidadHorse;
    public float amplitudHorse;

    public float numAvancePlayer1;
    public float numRetrocesoPlayer2;

    private Vector3 start;
    private Vector3 target;


    public override void StartMinigame()
    {
        // Initialize the base minigame.
        base.StartMinigame();

        start = horse.transform.position;
        target = start + Vector3.right*100f;
    }

    // Update is called once per frame
    public override void Update()
	{
        // Take the timer into account.
        base.Update();

        if (minigameEnabled)
        {
            // Horse animation.
            horse.position += new Vector3(0, Mathf.Sin(Time.time) * velocidadHorse * amplitudHorse, 0);

            if (InputManager.GetActionDown(Player.One)) 
            {
                horse.position += new Vector3(numAvancePlayer1, 0, 0);
                
                if (horse.position.x >= target.x)
                {
                    //Game completed
                    FinishMinigame(Player.One);
                }
            }

            if (InputManager.GetActionDown(Player.Two) && horse.position.x >= start.x)
            {
                horse.position -= new Vector3(numRetrocesoPlayer2, 0, 0);
            }
        }   
        
    }

    

}
