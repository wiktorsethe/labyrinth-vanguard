using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] private LayerMask wallMask;
    [SerializeField] int dotsNumber;
    [SerializeField] GameObject dotsParent;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] float dotSpacing;
    [SerializeField] [Range(0.01f, 0.3f)] float dotMinScale;
    [SerializeField] [Range(0.3f, 1f)] float dotMaxScale;

    Transform[] dotsList;

    Vector2 pos;
    float timeStamp;
    private bool reflected = false;
    private bool resetTimeStamp = true;

    void Start()
    {
        Hide();
        PrepareDots();
    }

    void PrepareDots()
    {
        dotsList = new Transform[dotsNumber];
        dotPrefab.transform.localScale = Vector3.one * dotMaxScale;

        float scale = dotMaxScale;
        float scaleFactor = scale / dotsNumber;

        for (int i = 0; i < dotsNumber; i++)
        {
            dotsList[i] = Instantiate(dotPrefab, null).transform;
            dotsList[i].parent = dotsParent.transform;

            dotsList[i].localScale = Vector3.one * scale;
            if (scale > dotMinScale)
                scale -= scaleFactor;
        }
    }

    public void UpdateDots(Vector3 ballPos, Vector2 forceApplied)
    {
        timeStamp = dotSpacing;
        int maxreflections = 1;
        int currReflections = 0;
        float range = 2f;



        for (int i = 0; i < dotsNumber; i++)
        {
            if (resetTimeStamp)
            {
                timeStamp = dotSpacing;
                resetTimeStamp = false;
            }


            if (reflected)
            {
                pos.x = ((ballPos.x + forceApplied.x * timeStamp));
                pos.y = (float)((((ballPos.y - 1) + forceApplied.y * timeStamp)) - (Physics2D.gravity.magnitude * timeStamp * timeStamp * 0.95f) * 2);
            }
            else
            {
                pos.x = (ballPos.x + forceApplied.x * timeStamp);
                pos.y = ((ballPos.y - 1) + forceApplied.y * timeStamp) - (Physics2D.gravity.magnitude * timeStamp * timeStamp * 0.95f) / 2;
            }



            if (!Physics2D.OverlapCircle(dotsList[i].position, 0.1f, wallMask) && currReflections < maxreflections)
            {
                if (i > 10)
                {
                    range = Vector2.Distance(dotsList[i - 1].position, dotsList[i - 2].position);
                }

                RaycastHit2D hit = Physics2D.Raycast(pos, forceApplied, range, wallMask);

                if (hit.collider != null)
                {
                    Debug.DrawLine(pos, hit.point, Color.green);

                    forceApplied = Vector2.Reflect(forceApplied, hit.normal);
                    ballPos = hit.point;
                    reflected = true;
                    currReflections++;

                    resetTimeStamp = true;
                }
            }

            dotsList[i].position = pos;

            timeStamp += dotSpacing;
        }

        reflected = false;
        resetTimeStamp = true;
    }

    public void Show()
    {
        dotsParent.SetActive(true);
    }

    public void Hide()
    {
        dotsParent.SetActive(false);
    }
}

public class Reflection
{
    public Vector2 point;
    public Vector2 direction;
    public Vector2 dotFromTo;
}

