using UnityEngine;
using System.Collections;

public class PureMagicScript : MonoBehaviour {

	[Header("Du skylder mig en øl ;)")]
	public MeshRenderer OriginalMeshRenderer;
	public MeshRenderer ThisMeshRenderer;

	//private variables
	Color [] pix;
	MeshFilter meshFilter; 

	Texture2D test;
	Texture2D newTexture;

	bool PIXON = false;
	bool caseOn = false;
	int casenum = 0;




	void Start () {
		//Just initialising a variable if it has not been assigned in the inspector
		if (ThisMeshRenderer == null) {
			ThisMeshRenderer = GetComponent<MeshRenderer> ();
		}

		//We want to copy the damn mesh that is in the meshfilter of the original vuforia piece-a-crap-plane
		StartCoroutine ("GetMeshFilter");
	}
	
	// Update is called once per frame
	void Update () {
		if(meshFilter != null){ //only run the code once we've actually found and added the meshfilter (The coroutine takes care of that!)

			PIXON = true;


//			if (Input.GetMouseButtonUp(0)) {
//				casenum++;
//
//				if (casenum > 3) {
//					casenum = 1;
//				}
//			}
//
//
//			switch (casenum) {
//
//			case 1:
//				if (!caseOn) {
//					gameObject.SetActive (true);
//					print (gameObject.activeSelf);
//					caseOn = true;
//					print ("CaseOn: " + caseOn);
//				}
//				print ("Case 1");
//				break;
//
//			case 2:
//				//changePix ();
//				print ("Case 2");
//				break;
//
//			case 3:
//				if (caseOn) {
//					gameObject.SetActive (false);
//					print (gameObject.activeSelf);
//					caseOn = false;
//					print ("CaseOn: " + caseOn);
//				}
//				print ("Case 3");
//				break;
//
//			default:
//				break;
//			}
		}

		if (PIXON) {
			changePix ();
		}
		ThisMeshRenderer.material.mainTexture = newTexture;
		GetComponent<Renderer> ().material.mainTexture = newTexture;
	}
		
	//This is a coroutine that fetches the MeshFilter component of the orig. Vuforia plane thingy
	IEnumerator GetMeshFilter(){ 
		//We want to run this particular piece of code until we finally get to assign the meshFilter variable a MeshFilter component!
		while(meshFilter == null){
			//If the orig. Vuforia plane has gotten its MeshFilter 
			//(which is spawned programagically, which is also why we need this function in the first place)
			if(OriginalMeshRenderer.gameObject.GetComponent<MeshFilter>() != null){
				//Then we add a new MeshFilter component to this object ...
				meshFilter = gameObject.AddComponent<MeshFilter>();
				// ... and copy the mesh from the orig. Vuforia (i hate writing Vuforia by now) plane,
				// thus making the 'meshFilter' variable no longer be 'null' and thus the changePix method will run. Hooray. Magic.
				meshFilter.mesh = OriginalMeshRenderer.gameObject.GetComponent<MeshFilter> ().mesh;
			}

			// 'yield return null' basically means we will return nothing for now and run the code again next frame.
			// The reason we do it like this, is because the function must return an IEnumerator, which is some fancy schmancy C# / .NET stuff you prolly shouldn't worry about yet
			yield return null; 
		}
	}

	void changePix() {
		test = (Texture2D)OriginalMeshRenderer.material.mainTexture;
		pix = test.GetPixels ();

		float Wr = 1/3f;
		float Wg = 1/3f;
		float Wb = 1/3f;
		float I;

		for (int y = 0; y < test.height; y++) {
			for (int x = 0; x < test.width; x++) {
				I = Wr * pix [y * test.width + x].r + Wg * pix [y * test.width + x].g + Wb * pix [y * test.width + x].b;

//				pix [y * test.width + x].r = I;
//				pix [y * test.width + x].g = I;
//				pix [y * test.width + x].b = I;
			}
		}
		newTexture = new Texture2D (test.width, test.height);
		newTexture.SetPixels (pix);
		newTexture.Apply ();
	}
}
