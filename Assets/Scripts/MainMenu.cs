using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private RectTransform mainMenu;
    [SerializeField] private RectTransform levelsMenu;
    [SerializeField] private RectTransform optionsMenu;
    private float speed = 0.3f;

    [SerializeField] private Sprite unlockedDoors;
    [SerializeField] private Sprite lockedDoors;
    private List<GameObject> doors = new List<GameObject>();
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Animator transition;
    [SerializeField] private GameObject levelLoader;
    private void Start()
    {
        mainMenu.DOAnchorPos(Vector2.zero, speed).SetUpdate(true);
        optionsMenu.DOAnchorPos(new Vector2(-800, 0), speed).SetUpdate(true);
        levelsMenu.DOAnchorPos(new Vector2(-800, 0), speed).SetUpdate(true);

        foreach (Transform child in levelsMenu)
        {
            if (child.CompareTag("Level"))
            {
                doors.Add(child.gameObject);
            }
        }
        for (int i = 0; i < doors.Count; i++)
        {
            doors[i].GetComponent<Image>().sprite = lockedDoors;
            doors[i].GetComponent<Button>().interactable = false;
            doors[i].transform.GetChild(0).GetComponent<TMP_Text>().color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 0f);
        }

        for (int i=0; i<playerData.levelUnlocked; i++)
        {
            doors[i].GetComponent<Image>().sprite = unlockedDoors;
            doors[i].GetComponent<Button>().interactable = true;
            doors[i].transform.GetChild(0).GetComponent<TMP_Text>().color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1f);
        }
    }
    public void Play()
    {
        mainMenu.DOAnchorPos(new Vector2(800, 0), speed).SetUpdate(true);
        optionsMenu.DOAnchorPos(new Vector2(-800, 0), speed).SetUpdate(true);
        levelsMenu.DOAnchorPos(new Vector2(0, 0), speed).SetUpdate(true);
    }
    public void Options()
    {
        mainMenu.DOAnchorPos(new Vector2(800, 0), speed).SetUpdate(true);
        optionsMenu.DOAnchorPos(new Vector2(0, 0), speed).SetUpdate(true);
        levelsMenu.DOAnchorPos(new Vector2(-800, 0), speed).SetUpdate(true);
    }
    public void Main()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), speed).SetUpdate(true);
        optionsMenu.DOAnchorPos(new Vector2(-800, 0), speed).SetUpdate(true);
        levelsMenu.DOAnchorPos(new Vector2(-800, 0), speed).SetUpdate(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ChooseLevel(int levelIndex)
    {
        PlayerPrefs.SetInt("LevelNumber", levelIndex);
        StartCoroutine("LoadLevel");
    }
    private IEnumerator LoadLevel()
    {
        levelLoader.SetActive(true);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(1);
    }
}
