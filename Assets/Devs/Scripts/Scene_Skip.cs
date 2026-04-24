using UnityEngine;
using UnityEngine.InputSystem;

public class Scene_Skip : MonoBehaviour
{

    public InputAction Nextscene;

    private void OnEnable()
    {
        Nextscene.Enable();
        Nextscene.performed += SkipScene;
    }

    public void SkipScene(InputAction.CallbackContext context)
    {
        // Load the next scene in the build index
        int nextSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
