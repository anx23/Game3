using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterUI : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {
	public Sprite characterImage;
	public string characterName;
	public Text selectText;
	Sprite selectImage;

	// Use this for initialization
	void Start () {
		selectText =  GameObject.Find ("SelectName").GetComponent<Text>();

		selectImage = GameObject.Find ("SelectImage").GetComponent<Sprite>();
		selectText.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {




	}


	public  void OnPointerEnter (PointerEventData eventData)
	{

			
		selectText.text = characterName;
	
		//selectImage = characterImage;


	}


	public  void OnPointerExit (PointerEventData eventData)
	{
		//selectText.enabled = false;
	}





}
