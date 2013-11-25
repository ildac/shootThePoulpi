using UnityEngine;
using System.Collections;

/// <summary>
/// Menu Script, the screen script
/// </summary>
public class MenuScript : MonoBehaviour {

	private GUISkin skin;

	void Start () {
		// Load the skin for the button
		skin = Resources.Load ("GUISkin") as GUISkin;
	}

	void OnGUI () {
		const int buttonWidth = 120;
		const int buttonHeight = 100;

		GUI.skin = skin;

		// Draw a button to start a game
		if (
			GUI.Button (
				// Center in X 2/3 of the height of Y
				new Rect (
					Screen.width / 2 - (buttonWidth /2 ),
					(2 * Screen.height / 3) - (buttonHeight / 2),
					buttonWidth,
					buttonHeight
				), 
				"Start!"
			)
		) 
		{
			// Keeps the background music
			DontDestroyOnLoad(GameObject.Find("Music"));
			// On click load the first level
			// Stage1 is the name of the first scene we created
			Application.LoadLevel("Stage1");

		}
	}
}
