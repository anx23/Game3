using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour {
	public static BoardManager Instance{ set; get;}
	[SerializeField]
	private bool[,] allowedMove{ set; get; }
	[SerializeField]
	public Chessman[,] Chessmans{ set; get; }
	[SerializeField]
	private Chessman selectedChessman;

	private const float TILE_SIZE = 1.0f;
	private const float TILE_OFFSET = 0.5f;
	[SerializeField]
	private int selectionx=-1;
	[SerializeField]
	private int selectiony=-1;
	// Use this for initialization
	public List<GameObject> chessmanPrefabs;
public List<GameObject> activeChessman = new List<GameObject> ();

	public List<Chessman> EnemyChessmans = new List<Chessman> ();

	public bool isWhiteTurn;

	public bool isFirst;
	public int turncount=1;
	ChessAI ai;
//UI
	Text turnText;
	[SerializeField]
	GameObject resultPanel;
	Text resultText;
	public Text selectText;

	IEnumerator Toss(){

		yield return new WaitForSeconds (1.0f);
		int rand = Random.Range (0, 1);
		if (rand == 0) {
			isFirst = true;
		} else {
			isFirst = false;
		}

	}

	void Start () {

		turnText = GameObject.Find ("Turn").GetComponent<Text> ();
		resultPanel = GameObject.Find ("ResultPanel");
		resultText = GameObject.Find ("ResultText").GetComponent<Text> ();
		resultPanel.SetActive (false);
		selectText =  GameObject.Find ("SelectName").GetComponent<Text>();


		turncount = 1;
		ai = GetComponent<ChessAI> ();
		isWhiteTurn = true;
		Instance = this;
		SpawnAllChessman ();

		//Debug.Log (EnemyChessmans.Length);

	}
	
	// Update is called once per frame
	void Update () {
		DrawChessboard ();
		UpdateSelection ();
		if (isWhiteTurn) {
			
			if (Input.GetMouseButtonDown (0)) {
				if (selectionx >= 0 && selectiony >= 0) {

					if (selectedChessman == null) {
						SelectChessman (selectionx, selectiony);
					} else {
						MoveChessman (selectionx, selectiony);
					}
				}
			}

		}
	}

	//駒選択
	public void SelectChessman(int x,int y){
		if (Chessmans [x, y] == null)
			return;
		if (Chessmans [x, y].isWhite!=isWhiteTurn)
			return;
		
		//allowedMove = Chessmans [x, y].PossibleMove ();
		selectText.text=	Chessmans [x, y].gameObject.GetComponent<ChessLife>().hp.ToString();
		selectedChessman = Chessmans[x, y];
		allowedMove = Chessmans [x, y].PossibleMove ();
		BoardHighlight.Instance.HighlightAllowedMoves (allowedMove);
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				Debug.Log (allowedMove[i,j]);
			}
		}

	}
	//駒移動
	public void MoveChessman(int x,int y){
		

		if(allowedMove[x,y]){



			Chessman c;
			c = Chessmans [x, y];
			if (c != null&&c.isWhite!=isWhiteTurn) {
				if (c.GetType () == typeof(King))
						EndGame ("勝ち");
				//ai.
				EnemyChessmans.Remove(c);
				activeChessman.Remove (c.gameObject);
				Destroy (c.gameObject);
			}
			Debug.Log("move");
			Chessmans [selectedChessman.CurrentX, selectedChessman.CurrentY] = null;
			selectedChessman.transform.position = GetTileCenter (x,y);
			selectedChessman.Setposition (x, y);
			Chessmans [x, y] = selectedChessman;
			isWhiteTurn = !isWhiteTurn;
		}
		//selectedChessman = null;
		BoardHighlight.Instance.Hidehighlits();
		selectedChessman = null;
		turnText.text = "ENEMY";
	}

	//選択場所
	private void UpdateSelection(){

		if (!Camera.main)
			return;
		
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100.0f,LayerMask.GetMask("ChessPlane"))) {
		//	Debug.Log (hit.point);
			selectionx = (int)hit.point.x;
			selectiony = (int)hit.point.z;
		} else {
			selectionx = -1;
			selectiony = -1;

		}

	}

	private void SpawnChessman(int index,int x,int y){
		
		GameObject go = Instantiate (chessmanPrefabs[index],GetTileCenter(x,y),Quaternion.identity)as GameObject;
		go.transform.SetParent (transform);
		go.transform.Rotate(new Vector3(0f,180f,0f)); 

		Chessmans [x, y] = go.GetComponent<Chessman> ();

		Chessmans [x, y].Setposition (x,y);

		if (!Chessmans [x, y].isWhite) {
			EnemyChessmans.Add (Chessmans[x,y]);;

		}

		activeChessman.Add (go);
	}



	//初期駒配置
	private void SpawnAllChessman(){

		activeChessman = new List<GameObject> ();
		Chessmans = new Chessman[8, 8];
		//king
		SpawnChessman(0,3,0);
		//Queen
		SpawnChessman(1,4,0);

		//Rooks
		SpawnChessman(2,0,0);
		SpawnChessman(2,7,0);
		//Bishops
		SpawnChessman(3,2,0);
		SpawnChessman(3,5,0);

		//Knights
		SpawnChessman(4,1,0);
		SpawnChessman(4,6,0);

	
		//pawns
		for (int i = 0; i < 8; i++)
			SpawnChessman (5,i,1);



		////////////black

		//king
		SpawnChessman(6,3,7);
		//Queen
		SpawnChessman(7,4,7);

		//Rooks
		SpawnChessman(8,0,7);
		SpawnChessman(8,7,7);
		//Bishops
		SpawnChessman(9,2,7);
		SpawnChessman(9,5,7);

		//Knights
		SpawnChessman(10,1,7);
		SpawnChessman(10,6,7);


		//pawns
		for (int i = 0; i < 8; i++)
			SpawnChessman (11,i,6);
		

	}







	private Vector3 GetTileCenter(int x,int z){
		Vector3 origin = Vector3.zero;
		origin.x += (TILE_SIZE * x) + TILE_OFFSET;
		origin.z += (TILE_SIZE * z) + TILE_OFFSET;
		return origin;

	}


	//ボード描画　ギズモ
	private void DrawChessboard(){

		Vector3 widthLine = Vector3.right * 8;
		Vector3 heightLine = Vector3.forward * 8;

		for(int i=0;i<=8;i++){
			Vector3 start = Vector3.forward * i;
			Debug.DrawLine (start,start+widthLine);
			for(int j=0;j<=8;j++){
				start = Vector3.right * j;
				Debug.DrawLine (start,start+heightLine);

			}


		}
		/*
		if (selectionx >= 0 && selectiony >= 0) {

			Debug.DrawLine (Vector3.forward*selectiony+Vector3.right*selectionx,
				Vector3.forward*(selectiony+1)+Vector3.right*(selectionx+1));

			Debug.DrawLine (Vector3.forward*(selectiony+1)+Vector3.right*selectionx,
				Vector3.forward*selectiony+Vector3.right*(selectionx+1));

		}
		*/
	}


	public void EndGame(string resultinfo){

		Debug.Log ("Finish");
		resultPanel.SetActive (true);
		resultText.text = resultinfo;
	}

}
