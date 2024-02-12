using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public static Action onLevelCompleted;

    [SerializeField] private GameObject screen;
    [SerializeField] private GameObject aim;
    [SerializeField] private GameObject hpBar;
    [SerializeField] private Image score;
    [SerializeField] private List<Sprite> scoreSprites;
    [SerializeField] private Item scoreItem;
    [SerializeField] private AudioSource bgAudioSource;

    private const string SCENE_0 = "SampleScene";
    private const string SCENE_1 = "FinalRoomScene";

    private bool isLoading;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadBasicScene()
    {
        LoadScene(SCENE_0);
    }

    public void CompleteLevel()
    {
        aim.SetActive(false);
        hpBar.SetActive(false);

        screen.SetActive(true);

        if (InventoryManager.Instance.ContainsItem(scoreItem))
        {
            score.sprite = scoreSprites[0];
        }
        else
        {
            score.sprite = scoreSprites[1];
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        onLevelCompleted.Invoke();
    }

    private void OnEnable()
    {
        PlayerController.onPlayerDied += LoadBasicScene;
        KeyCardScript.OnFinalDoorActivated += LoadFinalRoomScene;
    }

    private void LoadFinalRoomScene()
    {
        LoadScene(SCENE_1);
        StartCoroutine(BgSoundFade());
    }

    private void LoadScene(string sceneName)
    {
        if (isLoading)
        {
            return;
        }

        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    private IEnumerator BgSoundFade()
    {
        float fadeDuration = 1f;
        float startVolume = bgAudioSource.volume;
        while (bgAudioSource.volume > 0f)
        {
            bgAudioSource.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        bgAudioSource.Stop();
        bgAudioSource.volume = startVolume;
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        isLoading = true;
        bool waitFading = true;
        Fader.Instance.FadeIn(() =>  waitFading = false);

        while (waitFading)
        {
            yield return null;
        }

        var async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        while (async.progress < 0.9f)
        {
            yield return null;
        }

        async.allowSceneActivation = true;

        waitFading = true;
        Fader.Instance.FadeOut(() => waitFading = false);

        while (waitFading)
        {
            yield return null;
        }

        isLoading = false;
    }
}
