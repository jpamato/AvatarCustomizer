using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SimpleJSON;

public class ImportAvatarJsons : MonoBehaviour {

	public Dropdown dropdown;

	public string PATH = "/Resources/AvatarJsons";

	public List<string> fileNames;
	public List<Dropdown.OptionData> names;

	void Start () {

		fileNames = new List<string>();
		names = new List<Dropdown.OptionData>();

		names.Add (new Dropdown.OptionData("Seleccionar Avatar"));
		
		#if UNITY_EDITOR
		DirectoryInfo dir = new DirectoryInfo(Application.dataPath+PATH);
		#elif UNITY_STANDALONE_WIN
		DirectoryInfo dir = new DirectoryInfo(Directory.GetParent(Application.dataPath).FullName+PATH);
		#elif UNITY_STANDALONE_OSX
		DirectoryInfo dir = new DirectoryInfo(Directory.GetParent(Directory.GetParent(Application.dataPath).FullName).FullName+PATH);
		#endif

		FileInfo[] info = dir.GetFiles("*.json");
		foreach (FileInfo f in info) {
			StartCoroutine(Import(f.FullName));
		}
		//foreach (string file in System.IO.Directory.GetFiles(Application.dataPath+PATH)){}

		dropdown.options = names;
	}

	IEnumerator Import(string file){

		/*string filePath = "Dialogs/" + file.Replace (".json", "");
		TextAsset text = Resources.Load<TextAsset> (filePath);*/

		WWW www = new WWW("file://" + file);
		yield return www;
		string text = www.text;

		//Debug.Log (text);
		var N = JSON.Parse (text);

		fileNames.Add (N ["nombre"] + "_" + N ["id"]);
		string nom = N ["nombre"];
		names.Add (new Dropdown.OptionData(nom.Replace("_"," ")));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
