
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void enableCursor()
    {
        Cursor.visible = true;
    }
}
