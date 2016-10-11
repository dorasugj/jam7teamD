using UnityEngine;
using System.Collections;

public class DrawParticle : MonoBehaviour {

	ParticleSystem ps;
	bool isActive = true;
	// Use this for initialization
	void Start () {

		ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {

		if(isActive) {
			//マウスについていく
			Vector3 movePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			movePos.z = 0;
			transform.position = movePos;
		}
		else {
			if(!ps.isPlaying) {
				Destroy(gameObject);
			}
		}
	}

	public void Stop() {

		isActive = false;
		ps.Stop();
	}
}
