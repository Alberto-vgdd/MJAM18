using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    [Header("Player who wins if the time runs out.")]
    public Player defaultWinner;

    [Header("Strings to be displayed.")]
    public string[] hintMessages;
    public string[] winMessages;


    protected bool minigameEnabled;
    protected float duration;
    protected float timer;

    public abstract void StartMinigame();
    public abstract void FinishMinigame(Player winner);
}

public abstract class Minigame<T> : Minigame where T : Minigame<T>
{
    public override void StartMinigame()
    {
        duration = GameManager.MinigameDuration;
        timer = 0;
        minigameEnabled = true;
    }

    public override void FinishMinigame(Player winner)
    {
        minigameEnabled = false;
        GameManager.FinishMinigame(winner);
        Destroy(gameObject,2f);
    }

    public virtual void Update()
    {
        if (minigameEnabled)
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                FinishMinigame(defaultWinner);
            }
        }
    }
}
