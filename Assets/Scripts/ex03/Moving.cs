using UnityEngine;

public class Moving : MonoBehaviour
{

	public Vector3 direct;
	
	public float velocity = 20f;
	private void OnCollisionStay2D (Collision2D other) 
	{
		other.transform.Translate(direct * velocity * Time.deltaTime);
	}

	private void OnCollisionEnter2D (Collision2D other) 
	{
		other.transform.parent.transform.Translate(direct * velocity * Time.deltaTime);
	}
}
