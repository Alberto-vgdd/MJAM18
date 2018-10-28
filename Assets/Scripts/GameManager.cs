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
    public int[] scores;
    private Minigame currentMinigame;
    private float minigameDuration;
    private List<int> playedMinigames;
    private int currentMinigameIndex;


    public AudioSource music;
    public AudioClip title;
    public AudioClip minigame;
    public AudioClip summary;
    public AudioClip[] transitions;


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

        // Play menu music
        music.clip = title;
        music.Play();
    }

    // The beginning of the game.
    void StartGame()
    {
        // Reset the value of the variables
        for (int i = 0; i < scores.Length; i++) { scores[i] = 0;}
        minigameDuration = initialMinigameDuration;
        playedMinigames.Clear();

        // Hide the main menu.
        MenuManager.HideMainMenu();
        
        // Load the next minigame.
        StartCoroutine(MinigameTransition(Player.Count));
    }

    void MinigameFinished(Player winner)
    {
        // Increse the overall score.
        scores[(int)winner]++;

        // Transition to the next minigame.
        StartCoroutine(MinigameTransition(winner));
    }

    IEnumerator MinigameTransition(Player winner)
    {
        // If there was a previous minigame loaded.
        if (!winner.Equals(Player.Count))
        {
            // Fade out the screen and wait one second.
            MenuManager.FadeOut();
            music.PlayOneShot(transitions[Random.Range(0,transitions.Length)]);
            yield return new WaitForSeconds(1f);

            // Print the player who the lat game and wait 2 seconds.
            MenuManager.DisplayWinner(currentMinigame.winMessages[(int)winner]);
            yield return new WaitForSeconds(2f);
        }
        else
        {
            // Wait 7.5 seconds to show the tutorial
            yield return new WaitForSeconds(5f);

            // Play minigame music
            music.clip = minigame;
            music.Play();
        }

        // Load the next minigame, and wait for a second.
        currentMinigameIndex = GetRandomIndex();

        // If all the levels have been played...
        if (currentMinigameIndex < 0)
        {
            // Play menu music
            music.clip = summary;
            music.Play();

            // Display the summary screen.
            MenuManager.DisplaySummary(scores);
            yield return new WaitForSeconds(8.5f);

            // Play minigame music
            music.clip = minigame;
            music.Play();

            // Load the next minigame, and wait for a second.
            currentMinigameIndex = GetRandomIndex();
        }
 

        currentMinigame = Instantiate(minigames[currentMinigameIndex],minigames[currentMinigameIndex].transform.position,minigames[currentMinigameIndex].transform.rotation);
        yield return new WaitForSeconds(1f);

        // Display the new minigame's messages and wait 2 seconds.
        MenuManager.DisplayMessage(currentMinigame.hintMessages);
        yield return new WaitForSeconds(2f);

        // Fade the game in and wait half a second.
        MenuManager.FadeIn();
        yield return new WaitForSeconds(0.5f);

        // Finally, start the level and stop the coroutine.
        currentMinigame.StartMinigame();
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
        else
        {
            playedMinigames.Clear();
        }
        return index;
    }

    public static float MinigameDuration { get => instance.minigameDuration; }

    public static void StartPressed(){ instance.StartGame(); }
    public static void FinishMinigame(Player winner){ instance.MinigameFinished(winner); }
}
