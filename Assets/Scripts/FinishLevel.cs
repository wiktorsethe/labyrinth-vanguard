using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private LevelMenu lvlMenu;
    private void Start()
    {
        lvlMenu = GameObject.FindObjectOfType(typeof(LevelMenu)) as LevelMenu;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        lvlMenu.Win();
    }
}
