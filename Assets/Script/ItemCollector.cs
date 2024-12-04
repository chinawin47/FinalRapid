using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    public int itemCount = 0; // Tracks the collected items
    private MaxItemManager maxItemManager;

    void Start()
    {
        // Get the MaxItemManager component
        maxItemManager = FindObjectOfType<MaxItemManager>();
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
