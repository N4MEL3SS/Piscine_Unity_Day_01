using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	public GameObject platform;
	public float moveSpeed;

	public Transform currentPoint;
	public Transform[] points;

	public int pointSelection;
	public float speed = 10f;
	
	private Vector3 initPos;
	
	void Start () {
		currentPoint = points[pointSelection];
	}
	
	void Update () {

		platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
		if(platform.transform.position == currentPoint.position) {
			pointSelection++;
			if(pointSelection == points.Length)
			{
				pointSelection = 0;
			}
			currentPoint = points[pointSelection];
		}
	}

	private void OnCollisionEnter2D (Collision2D other) {
		other.transform.parent = this.transform;
	}
	
	private void OnCollisionExit2D (Collision2D other) {
		other.transform.parent = null;
	}
}
