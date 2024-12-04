using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    public static int itemCount = 0; // Make itemCount static to track it globally
    private MaxItemManager maxItemManager;
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the MaxItemManager component
        maxItemManager = FindObjectOfType<MaxItemManager>();

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from the mouse position
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Item"))
            {
                // Play collect sound
                if (audioSource != null)
                {
                    audioSource.Play();
                }

                // Increase item count
                itemCount++;

                // Destroy the clicked item
                Destroy(hit.collider.gameObject);

                // Check if item count reached the maximum set in MaxItemManager
                if (itemCount >= maxItemManager.maxItems)
                {
                    GoToNextScene();
                }
            }
        }
    }

    void GoToNextScene()
    {
        SceneManager.LoadScene(maxItemManager.nextSceneName);
    }
}