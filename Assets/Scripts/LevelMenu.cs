using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;
using System.Collections;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject jumpPadPrefab;
    [SerializeField] private GameObject flipPadPrefab;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private TMP_Text timerWinText;
    [SerializeField] private TMP_Text timerDeathText;
    [SerializeField] private PlayerData playerData;
    private DateTime startTime;
    private DateTime endTime;
    private DateTime pauseStartTime;
    private TimeSpan pauseTime;
    private ItemCollector itemCollector;
    [SerializeField] private Animator transition;
    [SerializeField] private GameObject levelLoader;
    [SerializeField] private AudioSource winSound;
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource deathSound;
    private void Start()
    {
        itemCollector = GameObject.FindObjectOfType(typeof(ItemCollector)) as ItemCollector;

        pauseMenu.GetComponent<CanvasGroup>().alpha = 0f;
        pauseMenu.GetComponent<CanvasGroup>().interactable = false;
        pauseMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        winMenu.GetComponent<CanvasGroup>().alpha = 0f;
        winMenu.GetComponent<CanvasGroup>().interactable = false;
        winMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        deathMenu.GetComponent<CanvasGroup>().alpha = 0f;
        deathMenu.GetComponent<CanvasGroup>().interactable = false;
        deathMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;

        startTime = DateTime.Now;
    }
    public void SpawnPlatform()
    {
        buttonSound.Play();
        Instantiate(platformPrefab, new Vector2(0f, 0f), Quaternion.identity);
    }
    public void SpawnJumpPad()
    {
        buttonSound.Play();
        Instantiate(jumpPadPrefab, new Vector2(0f, 0f), Quaternion.identity);
    }
    public void SpawnFlipPad()
    {
        buttonSound.Play();
        Instantiate(flipPadPrefab, new Vector2(0f, 0f), Quaternion.identity);
    }
    public void Win()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Stop();
        winSound.Play();
        if (playerData.levelUnlocked == PlayerPrefs.GetInt("LevelNumber")) playerData.levelUnlocked = PlayerPrefs.GetInt("LevelNumber");
        endTime = DateTime.Now;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetTrigger("Win");
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementController>().enabled = false;
        winMenu.GetComponent<CanvasGroup>().DOFade(1f, 1f).SetUpdate(UpdateType.Normal, true).OnComplete(CollectedGems);
        winMenu.GetComponent<CanvasGroup>().interactable = true;
        winMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        TimeSpan allTime = endTime - startTime - pauseTime;
        timerWinText.text = String.Format("Time: {0:D2}:{1:D2}", allTime.Minutes, allTime.Seconds);
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
        buttonSound.Play();
        pauseStartTime = DateTime.Now;
        Time.timeScale = 0f;
        pauseMenu.GetComponent<CanvasGroup>().DOFade(1f, 1f).SetUpdate(UpdateType.Normal, true);
        pauseMenu.GetComponent<CanvasGroup>().interactable = true;
        pauseMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void Resume()
    {
        buttonSound.Play();
        pauseTime += DateTime.Now - pauseStartTime;
        Time.timeScale = 1f;
        pauseMenu.GetComponent<CanvasGroup>().DOFade(0f, 1f).SetUpdate(UpdateType.Normal, true);
        pauseMenu.GetComponent<CanvasGroup>().interactable = false;
        pauseMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void Restart()
    {
        buttonSound.Play();
        Time.timeScale = 1f;
        StartCoroutine("LoadLevel");
    }
    public void Quit()
    {
        buttonSound.Play();
        Time.timeScale = 1f;
        StartCoroutine("LoadMenu");
    }
    public void Next()
    {
        buttonSound.Play();
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("LevelNumber", PlayerPrefs.GetInt("LevelNumber") + 1);
        StartCoroutine("LoadLevel");
    }
    public void Death()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Stop();
        deathSound.Play();
        endTime = DateTime.Now;
        deathMenu.GetComponent<CanvasGroup>().DOFade(1f, 1f).SetUpdate(UpdateType.Normal, true);
        deathMenu.GetComponent<CanvasGroup>().interactable = true;
        deathMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        TimeSpan allTime = endTime - startTime - pauseTime;
        timerDeathText.text = String.Format("Time: {0:D2}:{1:D2}", allTime.Minutes, allTime.Seconds);
    }
    private IEnumerator LoadMenu()
    {
        levelLoader.SetActive(true);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
    private IEnumerator LoadLevel()
    {
        levelLoader.SetActive(true);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
