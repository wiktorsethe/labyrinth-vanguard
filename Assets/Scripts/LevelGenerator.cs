using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private List<Transform> LevelsList;
    private void Start()
    {
        Instantiate(LevelsList[PlayerPrefs.GetInt("LevelNumber")-1], transform.position, Quaternion.identity);
    }
}
