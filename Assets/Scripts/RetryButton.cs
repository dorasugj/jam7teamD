using UnityEngine;
using System.Collections;

public class RetryButton : MonoBehaviour {
	public ScoreManager scoreManager;

	public void OnClick()
	{
		Debug.Log ("RetryButton.OnClick");
		scoreManager.Replay();
	}
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
