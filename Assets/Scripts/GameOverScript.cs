using UnityEngine;
using System.Collections;

/// <summary>
/// Game over script, start or quit the game.
/// </summary>
public class GameOverScript : MonoBehaviour {

	void OnGUI () {
		const int buttonWidth = 120;
		const int buttonHeight = 60;

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
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
