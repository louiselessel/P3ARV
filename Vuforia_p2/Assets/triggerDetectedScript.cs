using UnityEngine;
using System.Collections;

namespace Vuforia {

	public class triggerDetectedScript : MonoBehaviour {

		// used to see if there is a detection
		bool currentStatus = false;
		// used to manage the status for each frame and detect changes
		bool prevStatus = false;

		// used to manage the first call of all effects
		bool triggered = false;

		// used for getting all of the GO's that are markers
		public GameObject[] markers = new GameObject[10];

		string markerON = "";

		// find the GO's using a coroutine								CURRENTLY NOT IN USE
		private IEnumerator coroutine;

		// Different effects
		public GameObject RainEffect;
		public GameObject PaisleyBigEffect;
		public GameObject PaisleySmallEffect;
		public GameObject PaisleyFlowerEffect;
		public GameObject LightsGlitter;
		public GameObject LightsGlitterHand;
		public GameObject LightsLTL;
		public GameObject LightsLTLRot;
		public GameObject LightsSparkles;
		public GameObject DustStorm; 


		void Start () {
			print ("Start IS RUN");

			// disable all effects upon start
			disableOnStart ();


			print ("Find markers");
			print (markers.Length);

			// While loop below can be replaced by using coroutine (if that works on the phone!) with these 2 lines:
			//coroutine = findGOs ();
			//StartCoroutine (coroutine);

			while (markers.Length == 0) {

				// find all the GO's we are looking at
				markers = GameObject.FindGameObjectsWithTag ("Marker"); // make sure all the markers we are using have Tag: Marker

				foreach (GameObject marker in markers) {
					print ("Marker found at start: " + marker.name);
				}
			}
		}



		void Update () {
			
			// Listen for changes in the GO's by checking the "Default trackable event handler" script

			foreach (GameObject marker in markers) {

				// is a marker detected?
				currentStatus = marker.GetComponent<DefaultTrackableEventHandler> ().detected;

				// if there is a detection (== true) of the current marker in the foreach loop:
				if (currentStatus) { 

					if (markerON != marker.name && (marker.name != "Hand")) {						// ADD THIS IN WHEN MORE EFFECT ARE ADDED: && (marker.name != "Hand")
						// New marker has been detected												// kept out for testing purposes, but we do want to hand to run 
						resetEffect (markerON);														// simultaneously with other effects
					}														

					// Which marker is it?
					switch (marker.name) {

					case "Trigger1":
						//Run visual effect
						//Only if run first time it is detected...
						if (!triggered) {
							RainEffect.SetActive (true);
							print ("Running effect: RAIN");
							// Store the marker which is ON
							markerON = marker.name;
							print ("MarkerON: " + markerON);
						}
						triggered = true;
						break;

				   case "Trigger2":

						if (!triggered) {
							PaisleyBigEffect.SetActive (true);
							print ("Running effect: PAISLEY_BIG");
							// Store the marker which is ON
							markerON = marker.name;
							print ("MarkerON: " + markerON);
						}
						triggered = true;
						break;

					case "Trigger3":

						if (!triggered) {
							PaisleySmallEffect.SetActive (true);
							print ("Running effect: PAISLEY_SMALL");
							// Store the marker which is ON
							markerON = marker.name;
							print ("MarkerON: " + markerON);
						}
						triggered = true;
						break;

					case "Trigger4":

						if (!triggered) {
							PaisleyFlowerEffect.SetActive (true);
							print ("Running effect: PAISLEY_FLOWER");
							// Store the marker which is ON
							markerON = marker.name;
							print ("MarkerON: " + markerON);
						}
						triggered = true;
						break;

					case "Trigger5":

						if (!triggered) {
							LightsGlitter.SetActive(true);
							print ("Running effect: GLITTER");
							// Store the marker which is ON
							markerON = marker.name;
							print ("MarkerON: " + markerON);
						}
						triggered = true;
						break;

					case "Trigger6":

						if (!triggered) {
							LightsLTL.SetActive(true);
							print ("Running effect: LTL");
							// Store the marker which is ON
							markerON = marker.name;
							print ("MarkerON: " + markerON);
						}
						triggered = true;
						break;

					case "Trigger7":

						if (!triggered) {
							LightsLTLRot.SetActive(true);
							print ("Running effect: LTL_ROT");
							// Store the marker which is ON
							markerON = marker.name;
							print ("MarkerON: " + markerON);
						}
						triggered = true;
						break;

					case "Trigger8":

						if (!triggered) {
							LightsSparkles.SetActive(true);
							print ("Running effect: SPARKLES");
							// Store the marker which is ON
							markerON = marker.name;
							print ("MarkerON: " + markerON);
						}
						triggered = true;
						break;

					case "Trigger9":

						if (!triggered) {
							DustStorm.SetActive(false);
							print ("Running effect: DUST_STORM");
							// Store the marker which is ON
							markerON = marker.name;
							print ("MarkerON: " + markerON);
						}
						triggered = true;
						break;


					case "Hand":
						//Run visual effect
						LightsGlitterHand.SetActive(true);
						//Runs automatically because of Vuforia, only while detection is valid
						print ("Running effect FROM HAND");
						break;


					default:
						break;
					}
				}



			} // Foreach loop END


		}


		private void disableOnStart () {
			print ("Disabling all effects on start");

			RainEffect.SetActive(false);
			PaisleyBigEffect.SetActive(false);
			PaisleySmallEffect.SetActive(false);
			PaisleyFlowerEffect.SetActive(false);
			LightsGlitter.SetActive(false);
			LightsGlitterHand.SetActive (false);
			LightsLTL.SetActive(false);
			LightsLTLRot.SetActive(false);
			LightsSparkles.SetActive(false);
			DustStorm.SetActive(false);

		}


		private void resetEffect(string effectToTurnOFF) {
			print ("Reset effect: " + effectToTurnOFF);
			triggered = false;

			switch (effectToTurnOFF) {

			case "Trigger1":
				RainEffect.SetActive (false);
				break;


			case "Trigger2":
				PaisleyBigEffect.SetActive (false);
				break;

			case "Trigger3":
				PaisleySmallEffect.SetActive (false);
				break;

			case "Trigger4":
				PaisleyFlowerEffect.SetActive (false);
				break;

			case "Trigger5":
				LightsGlitter.SetActive (false);
				break;

			case "Trigger6":
				LightsLTL.SetActive (false);
				break;

			case "Trigger7":
				LightsLTLRot.SetActive (false);
				break;

			case "Trigger8":
				LightsSparkles.SetActive (false);
				break;

			case "Trigger9":
				DustStorm.SetActive (false);
				break;

			default:
				break;
			}
		}


		// CURRENTLY NOT IN USE!
		private IEnumerator findGOs() {
			while (markers.Length == 0) {

				print ("running coroutine");

				// find all the GO's we are looking at
				markers = GameObject.FindGameObjectsWithTag ("Marker"); // make sure all the markers we are using have Tag: Marker

				foreach (GameObject marker in markers) {
					print ("Marker found at start: " + marker.name);
				}

				yield return null;
			}
		}
	}
}

/*

We need to make sure that some of the effects are instantiated in world space, independent of the marker. E.g. Rain and Fog. This means they cannot be a child of the ImageTarget.

Others need to be instantiated from the marker (hand effect). These can be a child of the image target.


Solution:
Make VUFeventhandlerscript send info on the name of the marker spotted when first tracking it to external script that handles the effects.

Make external script receive the name of the marker spotted  “ImageTargetNAME” and instantiate effect

Make VUFeventhandlerscript send info about tracking lost..

Make external script receive tracking lost message, but not remove the effect until new tracking received (name of marker).

The way it works:
if seen
	OnTrackingFound(); // this will activate bool detected

keep until new marker detected
	OnTrackingLost(); // this will deactivate bool detected
	But we should still wait for a new detection to be made


The effects:
By making all GO, eg. the Rain, already be in the scene, but Setactive = false, we avoid the problem of
instantiating multiple effects simultaneously. We can simply Setactive = true.
 */