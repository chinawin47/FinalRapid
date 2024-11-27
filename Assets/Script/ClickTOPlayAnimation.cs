using UnityEngine;

public class ClickToPlayAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the object
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the player clicked on the object
        if (Input.GetMouseButtonDown(0)) // Left mouse button click (0)
        {
            // Cast a ray from the mouse position to check if it hits the object
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // If the ray hits this object
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // Play the animation at runtime using Animator.Play()
                animator.Play("Sleeping");
            }
        }
    }
}
