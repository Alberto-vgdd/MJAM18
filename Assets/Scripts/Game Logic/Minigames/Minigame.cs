using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    public abstract void MinigameStart();
    public abstract void MinigamePause();
    public abstract void MinigameResume();
    public abstract void MinigameStop();

}

public abstract class Minigame<T> : Minigame where T : Minigame<T>
{
    public static T Instance { get; private set; }

    public virtual void Awake()
    {
        Instance = (T)this;
    }
}
