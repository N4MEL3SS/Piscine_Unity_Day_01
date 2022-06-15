using UnityEngine;

public class Teleporte : MonoBehaviour {
	
	public Transform destination;

	private void OnTriggerEnter2D(Collider2D other) 
	{
		other.transform.position = destination.position;
	}
}
