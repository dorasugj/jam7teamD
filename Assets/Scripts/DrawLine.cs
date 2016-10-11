using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//
// マウスでなぞって線を引く
//
public class DrawLine : MonoBehaviour {

	public GameObject pointPre; //設置用プレハブ
	public GameObject particlePre; //エフェクト用プレハブ
	GameObject eff;

	public Text debTex;

	Master master;
	Camera mainCam;

	AudioSource audioSrc;
	public AudioClip drawSE;

	ScoreCaliculator scoreCal;

	float drawSEInterval = 7;
	float interval = 0;
	bool isActive = true;
	bool isDrawing = false;
	bool firstMouse = false; //最初のマウスクリック検出用

	// Use this for initialization
	void Start () {

		master = GetComponent<Master>();
		audioSrc = GetComponent<AudioSource>();
		scoreCal = GetComponent<ScoreCaliculator>();
		mainCam = Camera.main; //メインカメラ取得

		interval = drawSEInterval;
	}
	
	// Update is called once per frame
	void Update () {
		debTex.text = scoreCal.GetScore().ToString()+" 点";
		InMouse();

	}

	//
	// なぞっているときに音を鳴らす
	//
	void SoundUpdate() {

		interval += Time.deltaTime;

		if(isDrawing && interval >= drawSEInterval) {
			interval = 0;
			audioSrc.clip = drawSE;
			audioSrc.Play();
		}
	}

	//
	// マウスで入力する
	//
	public Vector2 InMouse() {

		Vector2 inPos = Vector2.zero;

		if(isActive) {

			SoundUpdate();

			if(Input.GetMouseButtonDown(0)) {
				//エフェクト生成
				eff = Instantiate(particlePre);
			}

			if(Input.GetMouseButton(0)) {

				isDrawing = true;

				if(!firstMouse) {
					//ゲーム開始
					firstMouse = true;
					master.GameStart();
				}

				inPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
				Instantiate(pointPre, inPos, Quaternion.identity);//描画

				//>呼び出し
				scoreCal.DrawPoint(inPos);
			}
			else {
				isDrawing = false;

				interval = drawSEInterval;
				audioSrc.Stop();
			}

			if(Input.GetMouseButtonUp(0)) {
				//エフェクト削除
				eff.GetComponent<DrawParticle>().Stop();
			}
		}
		return inPos;
	}

	public void SetActive(bool active) {
		isActive = active;

		//後片付け
		if(eff) {
			eff.GetComponent<DrawParticle>().Stop();
		}
		audioSrc.Stop();
	}
}
