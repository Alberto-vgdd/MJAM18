using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Singleton
    private static InputManager instance;

    // Constants to handle inputs from both players
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string Action = "Action";
    private const string Back = "Back";
    private const string Menu = "Menu";

    public enum Player 
    {
        One,
        Two,
        Count
    }

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

    // Inputs for the movement axes.
    public static float GetHorizontalAxis(Player player)
    {
        return Input.GetAxis(Horizontal+(int)player);
    }
    public static float GetVerticalAxis(Player player)
    {
        return Input.GetAxis(Vertical+(int)player);
    }

    // Inputs for the action button.
    public static bool GetActionDown(Player player)
    {
        return Input.GetButtonDown(Action+(int)player);
    }
    public static bool GetActionUp(Player player)
    {
        return Input.GetButtonUp(Action+(int)player);
    }
    public static bool GetAction(Player player)
    {
        return Input.GetButton(Action+(int)player);
    }

    // Inputs for the back button.
    public static bool GetBackDown(Player player)
    {
        return Input.GetButtonDown(Back+(int)player);
    }
    public static bool GetBackUp(Player player)
    {
        return Input.GetButtonUp(Back+(int)player);
    }
    public static bool GetBack(Player player)
    {
        return Input.GetButton(Back+(int)player);
    }

    // Inputs for the menu button.
    public static bool GetMenuDown(Player player)
    {
        return Input.GetButtonDown(Menu+(int)player);
    }
    public static bool GetMenuUp(Player player)
    {
        return Input.GetButtonUp(Menu+(int)player);
    }
    public static bool GetMenuBack(Player player)
    {
        return Input.GetButton(Menu+(int)player);
    }
}
