using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Master : MonoBehaviour {

	public Text tex_Time;
	public SpriteRenderer compImg;
	public GameObject resultParticle;

	DrawLine drawline;

	float time = 10;
	bool isGame = false;


	// Use this for initialization
	void Start () {

		drawline = GetComponent<DrawLine>();
	}
	
	// Update is called once per frame
	void Update () {

		if(isGame) {

			time -= Time.deltaTime;

			if(time < 0) {//ゲームオーバー?
				time = 0;
				GameOver();
			}
		}

		//Draw
		tex_Time.text = "" + Mathf.CeilToInt(time);

	}

	//
	// ゲームスタートする。
	//
	public void GameStart() {

		Debug.Log("Start");
		isGame = true;
	}

	//
	// ゲームオーバーする。
	//
	public void GameOver() {

		Debug.Log("End");
		isGame = false;

		drawline.SetActive(false);

		StartCoroutine(GameOverAnim());
		StartCoroutine(LineColorSet());
	}

	IEnumerator GameOverAnim() {

		Instantiate(resultParticle, Vector3.zero, Quaternion.identity);

		yield return StartCoroutine(FadeIO.FadeOut(compImg, 4, 0.5f));

		yield return new WaitForSeconds(2);

		//>リザルト呼び出し(スコア取得後)
		PlayerPrefs.SetInt("score", GetComponent<ScoreCaliculator>().GetScore());
		UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/ScoreScene2");
	}

	//
	// ゲームオーバー時に線の色を変える
	//
	IEnumerator LineColorSet() {

		float switchTime = 2;
		float t = 1;
		
		GameObject[] points = GameObject.FindGameObjectsWithTag("Point");

		while(t > 0) {

			t -= Time.deltaTime / switchTime;

			Color col = new Color(1 - t, 0, 0);
			for(int i = 0;i < points.Length;i++) {

				points[i].GetComponent<Renderer>().material.color = col;
			}

			yield return null;
		}
	}

	//
	// 残り時間取得
	//
	public float GetTime() {

		return time;
	}

}
