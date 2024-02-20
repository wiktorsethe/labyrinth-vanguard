using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;
public class LevelMenu : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject jumpPadPrefab;
    [SerializeField] private GameObject flipPadPrefab;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private PlayerData playerData;
    private DateTime startTime;
    private DateTime endTime;
    private DateTime pauseStartTime;
    private TimeSpan pauseTime;
    private ItemCollector itemCollector;
    private void Start()
    {
        itemCollector = GameObject.FindObjectOfType(typeof(ItemCollector)) as ItemCollector;

        pauseMenu.GetComponent<CanvasGroup>().alpha = 0f;
        pauseMenu.GetComponent<CanvasGroup>().interactable = false;
        winMenu.GetComponent<CanvasGroup>().alpha = 0f;
        winMenu.GetComponent<CanvasGroup>().interactable = false;

        startTime = DateTime.Now;
    }
    public void SpawnPlatform()
    {
        Instantiate(platformPrefab, new Vector2(0f, 0f), Quaternion.identity);
    }
    public void SpawnJumpPad()
    {
        Instantiate(jumpPadPrefab, new Vector2(0f, 0f), Quaternion.identity);
    }
    public void SpawnFlipPad()
    {
        Instantiate(flipPadPrefab, new Vector2(0f, 0f), Quaternion.identity);
    }
    public void Win()
    {
        if (playerData.levelUnlocked == PlayerPrefs.GetInt("LevelNumber")) playerData.levelUnlocked = PlayerPrefs.GetInt("LevelNumber");
        endTime = DateTime.Now;
        Time.timeScale = 0f;
        winMenu.GetComponent<CanvasGroup>().DOFade(1f, 1f).SetUpdate(UpdateType.Normal, true).OnComplete(CollectedGems);
        winMenu.GetComponent<CanvasGroup>().interactable = true;
        TimeSpan allTime = endTime - startTime - pauseTime;
        timerText.text = String.Format("Time: {0:D2}:{1:D2}", allTime.Minutes, allTime.Seconds);
    }
    private void CollectedGems()
    {
        Image[] stars = winMenu.transform.Find("Panel").transform.Find("StarsPanel").GetComponentsInChildren<Image>();
        for (int i = 0; i < itemCollector.collectedGems; i++)
        {
            stars[i].DOColor(new Color(1f, 1f, 1f, 1f), 1f).SetUpdate(UpdateType.Normal, true);
        }
    }
    public void Pause()
    {
        pauseStartTime = DateTime.Now;
        Time.timeScale = 0f;
        pauseMenu.GetComponent<CanvasGroup>().DOFade(1f, 1f).SetUpdate(UpdateType.Normal, true);
        pauseMenu.GetComponent<CanvasGroup>().interactable = true;
    }
    public void Resume()
    {
        pauseTime += DateTime.Now - pauseStartTime;
        Time.timeScale = 1f;
        pauseMenu.GetComponent<CanvasGroup>().DOFade(0f, 1f).SetUpdate(UpdateType.Normal, true);
        pauseMenu.GetComponent<CanvasGroup>().interactable = false;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Next()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("LevelNumber", PlayerPrefs.GetInt("LevelNumber") + 1);
        SceneManager.LoadScene(1);
    }
}
