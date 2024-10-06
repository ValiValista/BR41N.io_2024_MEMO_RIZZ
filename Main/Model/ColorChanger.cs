using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    // Reference to the Renderer to change object color
    private Renderer objectRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Renderer component attached to the object
        objectRenderer = GetComponent<Renderer>();
    }

    // Function to update the color state based on toggle and level
    public void UpdateColorState(bool isColorChangeEnabled, int level)
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
