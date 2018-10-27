using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Singleton
    private static MenuManager instance;

    // Fade variables
    private const string fadeIn = "Fade In";
    private const string fadeOut = "Fade Out";

    // Messages variables
    private const string displayWinner = "Display Winner";
    private const string displayMessage = "Display Message";
    public Text winnerText;

    // Main Menu variables
    private const string showMainMenu = "Show Main Menu";
    private const string hideMainMenu = "Hide Main Menu";
    public Text player0Text;
    public Text player1Text;

    // Summary variables
    private const string displaySummary = "Display Summary";
    public Text score;

    
    // Components
    private Animator animator;

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


        // Get the different components
        animator = GetComponent<Animator>();
    }


    // Main menu buttons.
    public void OnStartPressed()
    {
        GameManager.StartPressed();
    }
    public void OnExitPressed()
    {
        Application.Quit();
    }

    // Main Menu 
    public static void ShowMainMenu()
    {
        instance.animator.SetTrigger(showMainMenu);
    }
    public static void HideMainMenu()
    {
        instance.animator.SetTrigger(hideMainMenu);
    }

    // Fades
    public static void FadeIn()
    {
        instance.animator.SetTrigger(fadeIn);
    }
    public static void FadeOut()
    {
        instance.animator.SetTrigger(fadeOut);
    }

    // Messages
    public static void DisplayWinner(string winnerMessage)
    {
        instance.winnerText.text = winnerMessage.ToUpper();
        instance.animator.SetTrigger(displayWinner);
    }
    public static void DisplayMessage(string[] messages)
    {
        instance.player0Text.text = messages[0].ToUpper();        
        instance.player1Text.text = messages[1].ToUpper();        
        instance.animator.SetTrigger(displayMessage);
    }

    // Summary 
    public static void DisplaySummary(int[] scores)
    {
        instance.score.text = "HEROE: " + scores[0] + "\nVILLANO: " + scores[1];
        instance.animator.SetTrigger(displaySummary);
    }

}
