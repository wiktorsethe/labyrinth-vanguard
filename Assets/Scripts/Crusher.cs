using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Crusher : MonoBehaviour
{
    [SerializeField] private float upSpeed;
    [SerializeField] private float downSpeed;
    [SerializeField] private Transform up;
    [SerializeField] private Transform down;
    [SerializeField] private GameObject obj;
    private bool isChoping = false;
    private void Start()
    {
        MoveDown();
    }
    private void MoveDown()
    {
        float duration = Vector2.Distance(up.position, down.position) / downSpeed;
        obj.transform.DOMove(down.position, duration)
        .SetEase(Ease.InSine)
        .OnComplete(OnCompleteCallback);
    }
    private void MoveUp()
    {
        float duration = Vector2.Distance(up.position, down.position) / upSpeed;
        obj.transform.DOMove(up.position, duration)
        .SetEase(Ease.Linear)
        .OnComplete(OnCompleteCallback);
    }
    private void OnCompleteCallback()
    {
        StartCoroutine("ChangeStatus");
    }
    private IEnumerator ChangeStatus()
    {
        yield return new WaitForSeconds(2);
        if (isChoping)
        {
            MoveUp();
            isChoping = false;
        }
        else
        {
            MoveDown();
            isChoping = true;
        }
    }
}
