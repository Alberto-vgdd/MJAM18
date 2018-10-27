using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Singleton
    private static MenuManager instance;

    // Transitions constants
    private const string fadeIn = "Fade In";
    private const string fadeOut = "Fade Out";
    private const string displayWinner = "Display Winner";
    private const string displayMessage = "Display Message";

    // Main Menu constants
    private const string showMainMenu = "Show Main Menu";
    private const string hideMainMenu = "Hide Main Menu";
    
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
        instance.animator.SetTrigger(fadeIn);
    }

    // Messages
    public static void DisplayMessage()
    {
        instance.animator.SetTrigger(displayMessage);
    }

}
