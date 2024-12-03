using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToAnotherScene : MonoBehaviour
{
    // Name of the scene to load
    [SerializeField] private string sceneName = "BathroomScene";

    // AudioSource component for playing the sound
    [SerializeField] private AudioSource clickSound;

    void Update()
    {
        // Check for left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Check if the ray hit this GameObject
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Debug.Log("Switch clicked");
                if (clickSound != null)
                {
                    clickSound.PlayOneShot(clickSound.clip);
                }
                SceneManager.LoadScene(sceneName);
            }

        }
    }
}
