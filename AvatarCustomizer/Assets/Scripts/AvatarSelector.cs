using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarSelector : MonoBehaviour {

	public GameObject show;
	public Dropdown dropdown;
	AvatarLoader loader;
	ImportAvatarJsons jsons;

	// Use this for initialization
	void Start () {
		show.SetActive (false);
		loader = GetComponent<AvatarLoader> ();
		jsons = GetComponent<ImportAvatarJsons> ();
	}

	public void OnAvatarChange(){
		if (dropdown.value == 0) {
			show.SetActive (false);
		} else {
			loader.LoadAvatarData (jsons.fileNames [dropdown.value - 1]);
			show.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
