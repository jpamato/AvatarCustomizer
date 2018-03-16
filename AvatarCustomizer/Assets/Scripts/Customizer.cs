using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.IO;

public class Customizer : MonoBehaviour {

	public Button signDone;
	public InputField nombre;
	public InputField apellido;
	public Dropdown sexo;

	public Text name2Show;

	bool apellidoDone, nombreDone, sexoDone;

	public List<GameObject> chicos;
	public List<GameObject> chicas;
	bool female;

	ScreenSteps screens;

	public enum AvatarItem{
		size,
		peinado,
		ropa_arriba,
		ropa_abajo,
		calzado,
		accesorio,
		maquillaje_barba,
		tatuaje
	}

	public AvatarItem itemSelected;

	public List<Button> ItemButtons;

	int sizeIndex;
	int peinadoIndex;
	int ropa_arribaIndex;
	int ropa_abajoIndex;
	int calzadoIndex;
	int accesorioIndex;
	int maquillajeIndex;
	int barbaIndex;
	int tatuajeIndex;

	public AvatarCustomizer aCustom;

	// Use this for initialization
	void Start () {
		screens = GetComponent<ScreenSteps> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void SetApellido(string s){
		//Debug.Log ("Apellido: "+apellido.text);
		apellidoDone = apellido.text == "" ? false : true;
		SetContinue ();
	}

	public void SetNombre(string s){
		//Debug.Log ("Nombre: "+nombre.text);
		nombreDone = nombre.text == "" ? false : true;
		SetContinue ();
	}

	public void SetSexo(int i){
		//Debug.Log ("Sexo: "+sexo.value);
		sexoDone=sexo.value>0?true:false;
		SetContinue ();
	}

	void SetContinue(){
		if (nombreDone&&apellidoDone&&sexoDone) {
			signDone.interactable = true;
		} else {
			signDone.interactable = false;
		}
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

	public void SetSizeScreen(){
		female = sexo.value == 1 ? false : true;
		SetAvatarSex ();
		SelectItem (0);
		//LoadAvatarData("Carlos_Sacan");
		name2Show.text = nombre.text + " " + apellido.text;
		screens.SetScreen (2);
	}

	public void SetAccScreen(){
		SelectItem (2);
		screens.SetScreen (3);
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

	public void Back(){
		//Debug.Log ("back");
		if (itemSelected == AvatarItem.size) {
			sizeIndex--;
			SizeChange ();
		} else if (itemSelected == AvatarItem.peinado) {
			peinadoIndex--;
			peinadoIndex = GetItemNext (aCustom.peinado, peinadoIndex);
			aCustom.SetPeinado (peinadoIndex);
		} else if (itemSelected == AvatarItem.ropa_arriba) {
			ropa_arribaIndex--;
			ropa_arribaIndex = GetItemNext (aCustom.ropaArriba, ropa_arribaIndex);
			aCustom.SetRopaArriba (ropa_arribaIndex);
		} else if (itemSelected == AvatarItem.ropa_abajo) {
			ropa_abajoIndex--;
			ropa_abajoIndex = GetItemNext (aCustom.ropaAbajo, ropa_abajoIndex);
			aCustom.SetRopaAbajo(ropa_abajoIndex);
		} else if (itemSelected == AvatarItem.calzado) {
			calzadoIndex--;
			calzadoIndex = GetItemNext (aCustom.calzado, calzadoIndex);
			aCustom.SetCalzado(calzadoIndex);
		} else if (itemSelected == AvatarItem.accesorio) {
			accesorioIndex--;
			accesorioIndex = GetItemNext (aCustom.accesorio, accesorioIndex);
			aCustom.SetAccesorio(accesorioIndex);
		} else if (itemSelected == AvatarItem.maquillaje_barba) {
			if (female) {
				maquillajeIndex--;
				maquillajeIndex = GetItemNext (aCustom.maquillaje, maquillajeIndex);
				aCustom.SetMaquillaje(maquillajeIndex);
			} else {
				barbaIndex--;
				barbaIndex = GetItemNext (aCustom.barba, barbaIndex);
				aCustom.SetBarba(barbaIndex);
			}	
		}else if (itemSelected == AvatarItem.tatuaje) {
			tatuajeIndex--;
			tatuajeIndex = GetItemNext (aCustom.tatuaje, tatuajeIndex);
			aCustom.SetTatuaje(tatuajeIndex);
		}
	}

	public void Next(){
		if (itemSelected == AvatarItem.size) {
			sizeIndex++;
			SizeChange ();
		} else if (itemSelected == AvatarItem.peinado) {
			peinadoIndex++;
			peinadoIndex = GetItemNext (aCustom.peinado, peinadoIndex);
			aCustom.SetPeinado (peinadoIndex);
		} else if (itemSelected == AvatarItem.ropa_arriba) {
			ropa_arribaIndex++;
			ropa_arribaIndex = GetItemNext (aCustom.ropaArriba, ropa_arribaIndex);
			aCustom.SetRopaArriba (ropa_arribaIndex);
		} else if (itemSelected == AvatarItem.ropa_abajo) {
			ropa_abajoIndex++;
			ropa_abajoIndex = GetItemNext (aCustom.ropaAbajo, ropa_abajoIndex);
			aCustom.SetRopaAbajo(ropa_abajoIndex);
		} else if (itemSelected == AvatarItem.calzado) {
			calzadoIndex++;
			calzadoIndex = GetItemNext (aCustom.calzado, calzadoIndex);
			aCustom.SetCalzado(calzadoIndex);
		} else if (itemSelected == AvatarItem.accesorio) {
			accesorioIndex++;
			accesorioIndex = GetItemNext (aCustom.accesorio, accesorioIndex);
			aCustom.SetAccesorio(accesorioIndex);
		} else if (itemSelected == AvatarItem.maquillaje_barba) {
			if (female) {
				maquillajeIndex++;
				maquillajeIndex = GetItemNext (aCustom.maquillaje, maquillajeIndex);
				aCustom.SetMaquillaje(maquillajeIndex);
			} else {
				barbaIndex++;
				barbaIndex = GetItemNext (aCustom.barba, barbaIndex);
				aCustom.SetBarba(barbaIndex);
			}
		}else if (itemSelected == AvatarItem.tatuaje) {
			tatuajeIndex++;
			tatuajeIndex = GetItemNext (aCustom.tatuaje, tatuajeIndex);
			aCustom.SetTatuaje(tatuajeIndex);
		}
	}

	public void SelectItem(int index){
		itemSelected = (AvatarItem)index;
		for(int i=0;i<ItemButtons.Count;i++){
			if (index == i) {
				ItemButtons [i].image.color = Color.black;
				ItemButtons [i].GetComponentInChildren<Text> ().color = Color.white;
			} else {
				ItemButtons [i].image.color = Color.white;
				ItemButtons [i].GetComponentInChildren<Text> ().color = Color.black;
			}
		}
	}

	int GetItemNext(List<GameObject> list, int index){
		if (index < 0)
			index = list.Count - 1;
		else if (index > list.Count - 1)
			index = 0;

		return index;
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

	public void SaveAvatar(){
		SaveAvatarData (nombre.text + "_" + apellido.text);
		screens.SetScreen (4);
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

	public void Reset(){
		nombre.text = "";
		apellido.text = "";
		sexo.value = 0;
		screens.SetScreen (0);

		sizeIndex=0;
		peinadoIndex=0;
		ropa_arribaIndex=0;
		ropa_abajoIndex=0;
		calzadoIndex=0;
		accesorioIndex=0;
		maquillajeIndex=0;
		barbaIndex=0;
		tatuajeIndex=0;
	}

}
