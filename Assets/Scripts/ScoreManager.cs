using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] private TMP_Text textScore;
	[SerializeField] private TMP_Text textHighscore;

	[SerializeField] private int highscore;

	//public PlayerData playerData;
	//public SaveManager save;
	void Start()
	{
		//save = GameObject.FindObjectOfType(typeof(SaveManager)) as SaveManager;
		textScore.text = "Score: 0";

		//highscore = GameDataMenager.GetHighscore(levelIndex);
	}
	private void Update()
	{
		textHighscore.text = "Highscore: " + highscore.ToString();
	}

	public void UpdateScore(int score)
	{
		textScore.text = "Score: " + (score / 3) * 10;

		PlayerPrefs.SetInt("score", (score / 3) * 10);

		if (((score / 3) * 10) > highscore)
		{
			highscore = ((score / 3) * 10);
			//GameDataMenager.SetHighscore(highscore, levelIndex);
			//playerData.highscores[levelIndex] = highscore;
			//save.LocalSaveGame();
		}
	}
}
