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
    private Coroutine minigameLoad;


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
        
        // Hide the main menu
        MenuManager.HideMainMenu();

        // Load the next minigame.
        minigameLoad = StartCoroutine(LoadMinigame());
    }

    IEnumerator LoadMinigame()
    {
        // Load the next minigame.
        //currentMinigameIndex = GetRandomIndex();
        //currentMinigame = Instantiate(minigames[currentMinigameIndex]);

        // Wait for a second, and display the current objectives.
        yield return new WaitForSeconds(1f);
        MenuManager.DisplayMessage();

        // Wait for another two second, and fade the game in.
        yield return new WaitForSeconds(2f);
        MenuManager.FadeIn();

        // Wait for half a second and start the minigame.
        yield return new WaitForSeconds(0.5f);
        //currentMinigame.StartGame


        
        yield return null;
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
