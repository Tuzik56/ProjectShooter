using UnityEngine;

public class FinalSceneManager : MonoBehaviour
{
    private void Start()
    {
        ShowCursor();
    }

    private void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
