using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customizer : MonoBehaviour {

	public Button signDone;
	public InputField nombre;
	public InputField apellido;
	public Dropdown sexo;

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

	public int sizeIndex;
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

	public void SetAvatarSex(){		
		if (sexo.value == 1) {
			foreach (GameObject go in chicas)
				go.SetActive (false);
			SetAvatarSize (chicos, sizeIndex);
		} else if (sexo.value == 2) {
			foreach (GameObject go in chicos)
				go.SetActive (false);
			SetAvatarSize (chicas, sizeIndex);
		}
		female = sexo.value == 1 ? false : true;

		SetSizeScreen ();
	}

	public void SetSizeScreen(){
		SelectItem (0);
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

}
