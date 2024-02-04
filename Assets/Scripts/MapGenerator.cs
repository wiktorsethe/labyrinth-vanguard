using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private List<Transform> mapPartsList;
    [SerializeField] private Transform mapPart_Start;

    private Vector3 lastNewPosition;
    private Vector3 lastEndPosition;
    [SerializeField] float player_distance_spawn_level_part = 20f;

    private void Awake()
    {
        lastNewPosition = mapPart_Start.Find("NewPosition").position;
    }
    private void Start()
    {
        SpawnLevelPart();
    }
    private void Update()
    {
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, lastNewPosition) < player_distance_spawn_level_part)
        {
            SpawnLevelPart();
        }
    }
    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = mapPartsList[Random.Range(0, mapPartsList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastNewPosition);
        lastNewPosition = lastLevelPartTransform.Find("NewPosition").position;
        DestroyLevelPart();
    }
    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
    private void DestroyLevelPart()
    {
        lastEndPosition = GameObject.Find("EndPosition").transform.position;
        if(lastEndPosition.y < (GameObject.FindGameObjectWithTag("Player").transform.position.y - 30f))
        {
            Destroy(GameObject.Find("EndPosition").transform.parent.gameObject);
        }
    }
}
