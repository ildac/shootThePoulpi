using UnityEngine;
using System.Collections;

/// <summary>
/// Menu Script, the screen script
/// </summary>
public class MenuScript : MonoBehaviour {

	void OnGUI () {
		const int buttonWidth = 84;
		const int buttonHeight = 60;
	
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
