using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	const int RANK_ITEMS_NUM = 10;
	int hiscore;
	int score;

	public Text scoreText;
	public Text hiscoreText;

	void Start() {
		score = PlayerPrefs.GetInt("score");
		hiscore = PlayerPrefs.GetInt("hiscore");

		if (hiscore < score) {
			hiscore = score;
			PlayerPrefs.SetInt("hiscore", hiscore);
		}

		scoreText.text = score.ToString();
		hiscoreText.text = hiscore.ToString();
	}
	
	public void Replay() {
		SceneManager.LoadScene("Scenes/Main");
	}
}
