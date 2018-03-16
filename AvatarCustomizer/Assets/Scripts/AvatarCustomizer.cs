using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarCustomizer : MonoBehaviour {

	public string calzadoPattern = "calzado_";
	public string ropaAbajoPattern = "ropa_abajo_";
	public string ropaArribaPattern = "ropa_arriba_";
	public string accesorioPattern;
	public string tatuajePattern;
	public string maquillajePattern;
	public string barbaPattern = "barba_";
	public string peinadoPattern = "peinado_";

	public List<GameObject> calzado;
	public List<GameObject> ropaAbajo;
	public List<GameObject> ropaArriba;
	public List<GameObject> accesorio;
	public List<GameObject> tatuaje;
	public List<GameObject> maquillaje;
	public List<GameObject> barba;
	public List<GameObject> peinado;


	// Use this for initialization
	void Start () {
		FillLists ();

		SetItemOption (calzado, 0);
		SetItemOption (ropaAbajo, 0);
		SetItemOption (ropaArriba, 0);
		SetItemOption (accesorio, 0);
		SetItemOption (maquillaje, 0);
		SetItemOption (barba, 0);
		SetItemOption (peinado, 0);

	}

	void FillLists(){
		for (int i = 0; i < transform.childCount; i++) {
			GameObject go = transform.GetChild (i).gameObject;
			if (!SetItem2List (go, calzado, calzadoPattern)) {
				if (!SetItem2List (go, ropaAbajo, ropaAbajoPattern)) {
					if (!SetItem2List (go, ropaArriba, ropaArribaPattern)) {
						if (!SetItem2List (go, accesorio, accesorioPattern)) {
							if (!SetItem2List (go, maquillaje, maquillajePattern)) {
								if (!SetItem2List (go, barba, barbaPattern)) {
									if (!SetItem2List (go, peinado, peinadoPattern)) {
									}
								}
							}
						}
					}
				}
			}

		}
	}

	bool SetItem2List(GameObject go, List<GameObject> list, string patt){
		if (patt != "") {
			if (go.transform.name.StartsWith (patt)) {
				list.Add (go);
				return true;
			} else {
				return false;
			}
		} else {
			return false;
		}
	}

	void SetItemOption(List<GameObject> list, int index){
		for(int i=0;i<list.Count;i++){
			if (index == i) {
				list [i].SetActive (true);
			} else {
				list [i].SetActive (false);
			}
		}
	}

	public void SetPeinado(int i){
		SetItemOption (peinado, i);
	}

	public void SetRopaArriba(int i){
		SetItemOption (ropaArriba, i);
	}

	public void SetRopaAbajo(int i){
		SetItemOption (ropaAbajo, i);
	}

	public void SetCalzado(int i){
		SetItemOption (calzado, i);
	}

	public void SetAccesorio(int i){
		SetItemOption (accesorio, i);
	}

	public void SetMaquillaje(int i){
		SetItemOption (maquillaje, i);
	}

	public void SetBarba(int i){
		SetItemOption (barba, i);
	}

	public void SetTatuaje(int i){
		SetItemOption (tatuaje, i);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
