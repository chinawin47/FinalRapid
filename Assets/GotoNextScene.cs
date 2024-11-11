using UnityEngine;

public class GotoNextScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneController.instance.NextLevel();
        }
    }
}
