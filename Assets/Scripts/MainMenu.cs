using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private RectTransform mainMenu;
    [SerializeField] private RectTransform levelsMenu;
    [SerializeField] private RectTransform optionsMenu;
    private float speed = 0.3f;
    private void Start()
    {
        mainMenu.DOAnchorPos(Vector2.zero, speed).SetUpdate(true);
        optionsMenu.DOAnchorPos(new Vector2(-500, 0), speed).SetUpdate(true);
        levelsMenu.DOAnchorPos(new Vector2(-500, 0), speed).SetUpdate(true);
    }
    public void Play()
    {
        mainMenu.DOAnchorPos(new Vector2(500, 0), speed).SetUpdate(true);
        optionsMenu.DOAnchorPos(new Vector2(-500, 0), speed).SetUpdate(true);
        levelsMenu.DOAnchorPos(new Vector2(0, 0), speed).SetUpdate(true);
    }
    public void Options()
    {
        mainMenu.DOAnchorPos(new Vector2(500, 0), speed).SetUpdate(true);
        optionsMenu.DOAnchorPos(new Vector2(0, 0), speed).SetUpdate(true);
        levelsMenu.DOAnchorPos(new Vector2(-500, 0), speed).SetUpdate(true);
    }
    public void Main()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), speed).SetUpdate(true);
        optionsMenu.DOAnchorPos(new Vector2(-500, 0), speed).SetUpdate(true);
        levelsMenu.DOAnchorPos(new Vector2(-500, 0), speed).SetUpdate(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void EnterLevel(int number)
    {
        SceneManager.LoadScene(number);
    }
}
