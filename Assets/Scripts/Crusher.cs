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
    private bool chop;

    private void Start()
    {
        MoveDown();
    }
    private void MoveDown()
    {
        float duration = Vector2.Distance(up.position, down.position) / downSpeed;
        obj.transform.DOMove(down.position, duration)
        .SetEase(Ease.InSine)
        .OnComplete(MoveUp);
    }
    private void MoveUp()
    {
        float duration = Vector2.Distance(up.position, down.position) / upSpeed;
        obj.transform.DOMove(up.position, duration)
        .SetEase(Ease.Linear)
        .OnComplete(MoveDown);
    }
}
