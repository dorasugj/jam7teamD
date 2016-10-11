using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class FadeIO {

	public static IEnumerator FadeOut(Image black, float time) {

		black.gameObject.SetActive(true);
		black.color = new Color(black.color.r, black.color.g, black.color.b, 0);
		float t = 1;

		while(t > 0) {

			t -= Time.deltaTime / time;

			black.color = new Color(black.color.r, black.color.g, black.color.b, 1 - t);

			yield return null;
		}
		black.color = new Color(black.color.r, black.color.g, black.color.b, 1);
	}

	public static IEnumerator FadeOut(Image black, float time, float ratio) {

		black.gameObject.SetActive(true);
		black.color = new Color(black.color.r, black.color.g, black.color.b, 0);
		float t = 1;

		while(t > 0) {

			t -= Time.deltaTime / time;

			black.color = new Color(black.color.r, black.color.g, black.color.b, ratio - t);

			yield return null;
		}
		black.color = new Color(black.color.r, black.color.g, black.color.b, ratio);
	}

	public static IEnumerator FadeOut(SpriteRenderer black, float time) {

		black.gameObject.SetActive(true);
		black.color = new Color(black.color.r, black.color.g, black.color.b, 0);
		float t = 1;

		while(t > 0) {

			t -= Time.deltaTime / time;

			black.color = new Color(black.color.r, black.color.g, black.color.b, 1 - t);

			yield return null;
		}
		black.color = new Color(black.color.r, black.color.g, black.color.b, 1);
	}

	public static IEnumerator FadeOut(SpriteRenderer black, float time, float ratio) {

		black.gameObject.SetActive(true);
		black.color = new Color(black.color.r, black.color.g, black.color.b, 0);
		float t = 1;

		while(t > 0) {

			t -= Time.deltaTime / time;

			black.color = new Color(black.color.r, black.color.g, black.color.b, ratio - t);

			yield return null;
		}
		black.color = new Color(black.color.r, black.color.g, black.color.b, ratio);
	}

	public static IEnumerator FadeIn(Image black, float time) {

		black.color = new Color(black.color.r, black.color.g, black.color.b, 1);
		float t = 1;

		while(t > 0) {

			t -= Time.deltaTime / time;

			black.color = new Color(black.color.r, black.color.g, black.color.b, t);

			yield return null;
		}
		black.color = new Color(black.color.r, black.color.g, black.color.b, 0);
		black.gameObject.SetActive(false);
	}

	public static IEnumerator FadeIn(SpriteRenderer black, float time) {

		black.color = new Color(black.color.r, black.color.g, black.color.b, 1);
		float t = 1;

		while(t > 0) {

			t -= Time.deltaTime / time;

			black.color = new Color(black.color.r, black.color.g, black.color.b, t);

			yield return null;
		}
		black.color = new Color(black.color.r, black.color.g, black.color.b, 0);
		black.gameObject.SetActive(false);
	}
}
