using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Scrolling script, parallax scrolling script made to be assigned to a layer.
/// </summary>
public class ScrollingScript : MonoBehaviour {

	/// <summary>
	/// Scrolling speed.
	/// </summary>
	public Vector2 speed = new Vector2(10,10);

	/// <summary>
	/// Moving direction.
	/// </summary>
	public Vector2 direction = new Vector2(-1,0);

	/// <summary>
	/// Movement shoul be applied to the camera?
	/// </summary>
	public bool isLinkedToCamera = false;

	/// <summary>
	/// Background is infinite
	/// </summary>
	public bool isLooping = false;

	/// <summary>
	/// List of children with a renderer
	/// </summary>
	private List<Transform> backgroundPart;
		

	// Get all the children
	void Start () {
		// For infinite background only
		if (isLooping) {

			// Get all the children of the layer with a renderer
			backgroundPart = new List<Transform>();

			for (int i = 0; i < transform.childCount; i++) {
				Transform child = transform.GetChild(i);

				// Add only the visible children
				if (child.renderer != null) {
					backgroundPart.Add(child);
				}
			}

			// Sort by position (LINQ)
			// Need of few condition to take into account all the possible
			// scrolling conditions
			backgroundPart = backgroundPart.OrderBy(
				t => t.position.x
			).ToList();

		}
						
	}

	// Update is called once per frame
	void Update () {
		// Movement
		Vector3 movement = new Vector3(
			speed.x * direction.x,
			speed.y * direction.y,
			0);

		movement *= Time.deltaTime;
		transform.Translate (movement);

		// Move also the camera
		if (isLinkedToCamera) {
			Camera.main.transform.Translate (movement);
		}

		// Loop
		if (isLooping) {
			// Get the first object.
			// The list is ordered from left (x position) to right
			Transform firstChild = backgroundPart.FirstOrDefault();

			if (firstChild != null) {
				// Check if the child is already partly before the camera
				// We test the position first because the isVisibleFrom
				// method is a bit heavier to execute
				if (firstChild.position.x < Camera.main.transform.position.x) {
					// If the child is already on the left of the camera,
					// we test if it is completly outside and needs to be recicled
					if (firstChild.renderer.isVisibleFrom(Camera.main) == false) {
						// Get the last child position
						Transform lastChild = backgroundPart.LastOrDefault();
						Vector3 lastPosition = lastChild.transform.position;
						Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);

						// Set the position to the recicled one to be after
						// the last child. (for now only horizontal scrolling)
						firstChild.position = new Vector3(
							lastPosition.x + lastSize.x, 
							lastPosition.y, 
							lastPosition.z);

						// Set the recicled child to the last position of the background list
						backgroundPart.Remove(firstChild);
						backgroundPart.Add(firstChild);
					}
				}
			}
		}
	}
}
