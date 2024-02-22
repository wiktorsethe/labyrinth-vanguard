using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
public class Intro : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private string text1 = "Graphics: @_gloocose";
    private string text2 = "Rest: Wiktor Szczepanik";
    [SerializeField] private Animator transition;
    [SerializeField] private GameObject levelLoader;
    private void Start()
    {
        levelLoader.SetActive(false);
        FadeInFirstText();
    }
    private void FadeInFirstText()
    {
        text.text = text1;
        text.DOFade(1f, 2f)
            .SetEase(Ease.OutQuad)
            .OnComplete(FadeOutFirstText);
    }
    private void FadeOutFirstText()
    {
        text.DOFade(0.0f, 2f)
            .SetEase(Ease.OutQuad)
            .OnComplete(FadeInSecondText);
    }
    private void FadeInSecondText()
    {
        text.text = text2;
        text.DOFade(1f, 2f)
            .SetEase(Ease.OutQuad)
            .OnComplete(FadeOutSecondText);

    }
    private void FadeOutSecondText()
    {
        text.DOFade(0.0f, 2f)
            .SetEase(Ease.OutQuad)
            .OnComplete(LoadMain);
    }
    private void LoadMain()
    {
        StartCoroutine("LoadMenu");
    }
    private IEnumerator LoadMenu()
    {
        levelLoader.SetActive(true);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
