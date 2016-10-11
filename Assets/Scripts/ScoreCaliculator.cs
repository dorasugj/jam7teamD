using UnityEngine;
using System.Collections.Generic;

class CheckPointInfo {
	public CheckPointInfo(Vector2 p) {
		position = p;
		nearstLength = float.MaxValue;
	}
	
	public float LengthTo(Vector2 p) {
		return (position - p).sqrMagnitude;
	}	
	
	public int Score() {
		return (int)(2000/(nearstLength*1000+9.951f));
	}
	
	public void UpdateLength(float len) {
		if (nearstLength > len) nearstLength = len;
	}
	
	private Vector2 position;
	private float nearstLength;
}

public class ScoreCaliculator : MonoBehaviour {
	private int score;
	public GameObject checkPointsSrc;
	CheckPointInfo[] checkPoints;
	
	void Start () {
		// build checkPoints
		var tf = checkPointsSrc.transform;
		List<CheckPointInfo> points = new List<CheckPointInfo>();
		for(int i=0, num=tf.childCount; i<num; ++i) {
			Transform g = tf.GetChild(i);
			points.Add(new CheckPointInfo(g.position));
		}
		checkPoints = points.ToArray();
		Debug.Log(checkPoints.Length);
	}
	
	public void DrawPoint(Vector2 p) {
		// search nearst point
		/*
		CheckPointInfo nearestPoint = null;
		float nearestLength = float.MaxValue;
		foreach(var cp in checkPoints) {
			float len = cp.LengthTo(p);
			if (nearestLength > len) {
				nearestPoint = cp;
				nearestLength = len;
			}
		}
		//
		nearestPoint.UpdateLength(nearestLength);
		*/
		foreach (var cp in checkPoints) {
			float len = cp.LengthTo(p);
			cp.UpdateLength(len);
		}
	}
	
	public int GetScore() {
		int totalScore = 0;
		foreach(var cp in checkPoints) {
			totalScore += cp.Score();
		}
		#if false
		{
			string logMessage = "";
			foreach(var cp in checkPoints) {
				int score = cp.Score();
				logMessage += score + " ";
			}
			Debug.Log(logMessage);
		}
		#endif
		return totalScore;
	}
}
