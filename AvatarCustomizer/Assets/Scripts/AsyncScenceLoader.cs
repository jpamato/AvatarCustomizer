using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsyncScenceLoader : MonoBehaviour {

	public GameObject loading;
	public Slider loadingSlider;
	public int scene;

	AsyncOperation async;

	// Use this for initialization
	void Start () {
		StartCoroutine (LoadScene (scene));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator LoadScene(int scene){
		loading.SetActive (true);
		async = SceneManager.LoadSceneAsync (scene);
		async.allowSceneActivation = false;

		while (!async.isDone) {
			loadingSlider.value = async.progress;
			//yield return new WaitForSeconds(2);
			if (async.progress == 0.9f) {
				loadingSlider.value = 1f;
				async.allowSceneActivation = true;
			}
			yield return null;
		}
	}
}

