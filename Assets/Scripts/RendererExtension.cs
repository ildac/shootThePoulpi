using UnityEngine;
using System.Collections;

public static class RendererExtension {
	public static bool isVisibleFrom(this Renderer renderer, Camera camera) {
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes (camera);
		return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
	}
}
