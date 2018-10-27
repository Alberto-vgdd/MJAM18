using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Player 
{
    One = 0,
    Two = 1,
    Count = 2
}

public class GameManager : MonoBehaviour
{
    // Singleton.
    private static GameManager instance;

    // Constants
    private const float initialMinigameDuration = 10f;

    // Prefabs of the different minigames.
    public Minigame[] minigames;


    // Game Logic variables.
    private int[] scores;
    private Minigame currentMinigame;
    private float minigameDuration;
    private List<int> playedMinigames;
    private int currentMinigameIndex;


    void Awake()
    {
        // Create the singleton object.
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Initialize the variables.
        scores = new int[(int)Player.Count];
        playedMinigames = new List<int>();
    }

    // The beginning of the game.
    void StartGame()
    {
        // Reset the value of the variables
        for (int i = 0; i < scores.Length; i++) { scores[i] = 0;}
        minigameDuration = initialMinigameDuration;
        playedMinigames.Clear();
        

        // UI Animation here.
        if (currentMinigame != null) { Destroy(currentMinigame.gameObject);}
        currentMinigameIndex = GetRandomIndex();
        currentMinigame = Instantiate(minigames[currentMinigameIndex]);
    }

    // This auxiliary function provides a random int pointing to one the unplayed minigames
    int GetRandomIndex()
    {
        int index = -1;
        if (playedMinigames.Count < minigames.Length)
        {
            bool indexAvailable = false;
            while (!indexAvailable)
            {
                index = Random.Range(0,minigames.Length);
                indexAvailable = true;

                foreach (int playedMinigame in playedMinigames)
                {
                    if (playedMinigame.Equals(index))
                    {
                        indexAvailable = false;
                    }
                }
            }
            playedMinigames.Add(index);
        }
        return index;
    }

    public static float MinigameDuration { get => instance.minigameDuration; }

    public static void StartPressed(){ instance.StartGame(); }
}
