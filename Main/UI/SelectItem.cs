using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInteractionHandler : MonoBehaviour
{
    // Store input text and toggle status
    private string inputText = "";
    private bool isColorChangeEnabled = false;

    // Level variable from another function
    private int level;

    // Reference to the Renderer to change object color
    private Renderer objectRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Renderer component attached to the object
        objectRenderer = GetComponent<Renderer>();
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

        // Call the method to handle color change based on toggle and level
        HandleColorChange();
    }

    // Function to change the scene
    void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Function to handle color change based on the level when toggle is enabled
    void HandleColorChange()
    {
        if (isColorChangeEnabled)
        {
            // Change the color based on the level
            switch (level)
            {
                case 1:
                    objectRenderer.material.color = Color.red;
                    break;
                case 2:
                    objectRenderer.material.color = Color.green;
                    break;
                case 3:
                    objectRenderer.material.color = Color.blue;
                    break;
                default:
                    objectRenderer.material.color = Color.white;
                    break;
            }
        }
        else
        {
            // Reset color to default if color change is disabled
            objectRenderer.material.color = Color.white;
        }
    }
}
