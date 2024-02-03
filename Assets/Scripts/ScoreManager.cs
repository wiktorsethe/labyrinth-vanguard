using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] private TMP_Text textScore;
	[SerializeField] private TMP_Text textHighscore;

	private int highscore;
	private int score = 0;
	[SerializeField] private PlayerData playerData;
	//public SaveManager save;
	void Start()
	{
		//save = GameObject.FindObjectOfType(typeof(SaveManager)) as SaveManager;
		textScore.text = "Score: 0";

		highscore = playerData.highscore;
	}
	private void Update()
	{
		//textHighscore.text = "Highscore: " + highscore.ToString();
	}

	public void UpdateScore(int value)
	{
		if (score < value)
        {
			textScore.text = "Score: " + (value / 3) * 10;
			score = value;
			if (((value / 3) * 10) > highscore)
			{
				highscore = ((value / 3) * 10);
				playerData.highscore = highscore;
				//save.LocalSaveGame();
			}
		}
	}
}
