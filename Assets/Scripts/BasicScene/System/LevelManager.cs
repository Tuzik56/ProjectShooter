using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : BaseSceneManager
{
    public static LevelManager Instance;
    public static Action onLevelCompleted;

    [SerializeField] private GameObject screen;
    [SerializeField] private GameObject aim;
    [SerializeField] private GameObject hpBar;
    [SerializeField] private Image score;
    [SerializeField] private List<Sprite> scoreSprites;
    [SerializeField] private Item scoreItem;

    private void Awake()
    {
        Instance = this;
    }

    override
    public void OnSceneStarted()
    {

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        PlayerController.onPlayerDied += RestartLevel;
        KeyCardScript.OnFinalDoorActivated += LoadFinalRoomScene;
    }

    private void LoadFinalRoomScene()
    {
        SceneManager.LoadScene("FinalRoomScene");
    }
}
