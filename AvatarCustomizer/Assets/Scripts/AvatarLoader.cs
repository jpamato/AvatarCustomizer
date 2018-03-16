using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.IO;

public class AvatarLoader : MonoBehaviour {

	public List<GameObject> chicos;
	public List<GameObject> chicas;

	public bool female;
	public int sizeIndex;
	public int peinadoIndex;
	public int ropa_arribaIndex;
	public int ropa_abajoIndex;
	public int calzadoIndex;
	public int accesorioIndex;
	public int maquillajeIndex;
	public int barbaIndex;
	public int tatuajeIndex;

	public AvatarCustomizer aCustom;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}



	List<GameObject> SetAvatarSex(){		
		if (female) {
			foreach (GameObject go in chicos)
				go.SetActive (false);
			SetAvatarSize (chicas, sizeIndex);
			return chicas;
		} else{
			foreach (GameObject go in chicas)
				go.SetActive (false);
			SetAvatarSize (chicos, sizeIndex);
			return chicos;
		}
	}

	void SetAvatarSize(List<GameObject> list, int index){
		for(int i=0;i<list.Count;i++){
			if (index == i) {
				list [i].SetActive (true);
				aCustom = list [i].GetComponent<AvatarCustomizer> ();
			} else {
				list [i].SetActive (false);
			}
		}
	}

	void SizeChange(){
		if (female) {
			if (sizeIndex < 0)
				sizeIndex = chicas.Count - 1;
			else if (sizeIndex > chicas.Count - 1)
				sizeIndex = 0;

			SetAvatarSize (chicas, sizeIndex);
		} else {
			if (sizeIndex < 0)
				sizeIndex = chicos.Count - 1;
			else if (sizeIndex > chicos.Count - 1)
				sizeIndex = 0;

			SetAvatarSize (chicos, sizeIndex);
		}
	}

	void SaveAvatarData(string name){
		string id = System.DateTime.Now.ToString ("yyyy-MM-dd_HH-mm-ss");
		string sexo = female ? "F" : "M";
		string json = "{\n";
		json += "\"nombre\":\""+name+"\",\n";
		json += "\"id\":\""+id+"\",\n";
		json += "\"sexo\":\""+sexo+"\",\n";
		json += "\"sizeIndex\":\""+sizeIndex+"\",\n";
		json += "\"peinadoIndex\":\""+peinadoIndex+"\",\n";
		json += "\"ropa_arribaIndex\":\""+ropa_arribaIndex+"\",\n";
		json += "\"ropa_abajoIndex\":\""+ropa_abajoIndex+"\",\n";
		json += "\"calzadoIndex\":\""+calzadoIndex+"\",\n";
		json += "\"accesorioIndex\":\""+accesorioIndex+"\",\n";
		json += "\"maquillajeIndex\":\""+maquillajeIndex+"\",\n";
		json += "\"barbaIndex\":\""+maquillajeIndex+"\",\n";
		json += "\"tatuajeIndex\":\""+tatuajeIndex+"\"\n}";

		using (FileStream fs = new FileStream("Assets/Resources/AvatarJsons/"+name+"_"+id+".json", FileMode.Create)){
			using (StreamWriter writer = new StreamWriter(fs)){
				writer.Write(json);
			}
		}
		#if UNITY_EDITOR
		UnityEditor.AssetDatabase.Refresh ();
		#endif

		//PlayerPrefs.SetString ("AvatarData",json);
	}

	public void LoadAvatarData(string file){

		string filePath = "AvatarJsons/" + file.Replace(".json", "");
		TextAsset json = Resources.Load<TextAsset>(filePath);

		//Debug.Log (json.text);
		/*var N = JSON.Parse(text.text);*/

		//string json = PlayerPrefs.GetString ("AvatarData");
		if (!json.text.Equals ("")) {
			var N = JSON.Parse (json.text);
			female = N ["sexo"]=="F"?true:false;
			sizeIndex = N ["sizeIndex"].AsInt;
			peinadoIndex = N ["peinadoIndex"].AsInt;
			ropa_arribaIndex = N ["ropa_arribaIndex"].AsInt;
			ropa_abajoIndex = N ["ropa_abajoIndex"].AsInt;
			calzadoIndex = N ["calzadoIndex"].AsInt;
			accesorioIndex = N ["accesorioIndex"].AsInt;
			maquillajeIndex = N ["maquillajeIndex"].AsInt;
			barbaIndex = N ["barbaIndex"].AsInt;
			tatuajeIndex = N ["tatuajeIndex"].AsInt;

			List<GameObject> list = SetAvatarSex ();
			SetAvatarSize (list, sizeIndex);
			aCustom.SetPeinado (peinadoIndex);
			aCustom.SetRopaArriba (ropa_arribaIndex);
			aCustom.SetRopaAbajo(ropa_abajoIndex);
			aCustom.SetCalzado(calzadoIndex);
			aCustom.SetAccesorio(accesorioIndex);
			aCustom.SetMaquillaje(maquillajeIndex);
			aCustom.SetBarba(barbaIndex);
			aCustom.SetTatuaje(tatuajeIndex);

		}
	}

}
