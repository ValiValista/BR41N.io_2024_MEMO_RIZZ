using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenChangeHandler : MonoBehaviour
{
    // Store input text and toggle status
    private string inputText = "";
    private bool isColorChangeEnabled = false;

    // Level variable from another function
    private int level;

    // Reference to the ColorChanger component
    private ColorChanger colorChanger;

    // Start is called before the first frame update
    void Start()
    {
        // Find the ColorChanger script attached to the object
        colorChanger = GetComponent<ColorChanger>();
    }

    // Function that gets text input from another function
    public void ReceiveTextInput(string textInput)
    {
        inputText = textInput;

        // Check for scene change trigger (for example, if input is "changeScene")
        if (inputText == "changeScene")
        {
            ChangeScene("NextScene");  // Call the scene change method 
        }
    }

    // Function that gets a toggle input from another function
    public void ReceiveToggleInput(bool toggleInput, int receivedLevel)
    {
        isColorChangeEnabled = toggleInput;
        level = receivedLevel;  // Update the level variable

        // Send toggle and level to the ColorChanger script
        if (colorChanger != null)
        {
            colorChanger.UpdateColorState(isColorChangeEnabled, level);
        }
    }

    // Function to change the scene
    void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
