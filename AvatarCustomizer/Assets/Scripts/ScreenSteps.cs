using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSteps : MonoBehaviour {

	public List<GameObject> screens;

	public int screenIndex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetScreen(int index){
		screenIndex = index;
		for(int i=0;i<screens.Count;i++){
			if (index == i) {
				screens [i].SetActive (true);
			} else {
				if(screens [i]!=null)
					screens [i].SetActive (false);
			}
		}
	}
}
