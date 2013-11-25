using UnityEngine;
using System.Collections;

/// <summary>
/// Game over script, start or quit the game.
/// </summary>
public class GameOverScript : MonoBehaviour {

	private GUISkin skin;
	
	void Start () {
		// Load the skin for the button
		skin = Resources.Load ("GUISkin") as GUISkin;
	}

	void OnGUI () {
		const int buttonWidth = 120;
		const int buttonHeight = 100;

		GUI.skin = skin;

		if (
			GUI.Button (
				//center in X, 1/3 of the height of Y
				new Rect (
					(Screen.width / 2) - (buttonWidth / 2),
					(1 * Screen.height / 3) - (buttonHeight / 2),
					buttonWidth,
					buttonHeight
				),
				"Retry"
				)
		) 
		{
			// Reload the level
			Application.LoadLevel ("Stage1");
		}

		if (
			GUI.Button (
			//center in X, 2/3 of the height of Y
			new Rect (
			(Screen.width / 2) - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Menu"
			)
			) 
		{	
			// Destroy the music object
			Destroy(GameObject.Find("Music"));
			// Reload the level
			Application.LoadLevel ("Menu");
		}
	}

}
