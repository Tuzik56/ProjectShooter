using UnityEngine;

public abstract class BaseSceneManager : MonoBehaviour
{
    void Start()
    {
        OnSceneStarted();
    }

    public abstract void OnSceneStarted();
}
