using UnityEngine;
using UnityEngine.UI;

public class BackToSavedPositionUI : MonoBehaviour
{
    [SerializeField] private Button backButton; // Reference to the UI button
    [SerializeField] private Transform player; // Reference to the player object

    private void Start()
    {
        // Ensure the button is assigned and add a listener to it
        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
        }
    }

    private void OnBackButtonClicked()
    {
        // Check if a saved position exists
        if (SavePlayerPosition.savedPosition != Vector3.zero)
        {
            // Move the player to the saved position
            player.position = SavePlayerPosition.savedPosition;
            Debug.Log("Player moved back to the saved position: " + SavePlayerPosition.savedPosition);
        }
        else
        {
            Debug.Log("No saved position to return to.");
        }
    }

    private void OnDestroy()
    {
        // Remove the listener when the object is destroyed to avoid memory leaks
        if (backButton != null)
        {
            backButton.onClick.RemoveListener(OnBackButtonClicked);
        }
    }
}
