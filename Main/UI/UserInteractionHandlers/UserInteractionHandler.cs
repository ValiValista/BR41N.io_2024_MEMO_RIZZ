using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInteractionHandler : MonoBehaviour
{
    // Store input text and toggle status
    private string inputText = "";

    // References to the ScreenChangeHandler and CombatHandler
    private ScreenChangeHandler screenChangeHandler;
    private CombatHandler combatHandler;

    // Start is called before the first frame update
    void Start()
    {
        // Find the handlers in the scene
        screenChangeHandler = FindObjectOfType<ScreenChangeHandler>();
        combatHandler = FindObjectOfType<CombatHandler>();
    }

    // Function that gets text input from another function
    public void ReceiveTextInput(string textInput)
    {
        inputText = textInput;

        // Check if the input matches "red", "green", "blue", or "yellow"
        if (inputText == "red" || inputText == "green" || inputText == "blue" || inputText == "yellow")
        {
            // Send input to ScreenChangeHandler
            if (screenChangeHandler != null)
            {
                screenChangeHandler.HandleScreenChange(inputText);
            }
            else
            {
                Debug.LogWarning("ScreenChangeHandler not found.");
            }
        }
        // Check if the input matches other colors (for example, "purple", "orange", "cyan", "magenta")
        else if (inputText == "purple" || inputText == "orange" || inputText == "cyan" || inputText == "magenta")
        {
            // Send input to CombatHandler
            if (combatHandler != null)
            {
                combatHandler.HandleCombatInput(inputText);
            }
            else
            {
                Debug.LogWarning("CombatHandler not found.");
            }
        }
        else
        {
            Debug.LogWarning("Unknown input: " + inputText);
        }
    }
}
