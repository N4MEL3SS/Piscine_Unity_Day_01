using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

	public playerScript_ex01 player;
	public bool checkTrigger = false;
	
    public float closeDistance = 5.0f;
    
	private void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag(player.tag) && !checkTrigger) {
			bool compare = other.bounds.Contains(player.transform.position);
			if(compare){
				checkTrigger = true;
				player.checkedBoxAligned = true;
			}
        }
	}

	private void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag(player.tag)) {
			checkTrigger = false;
			player.checkedBoxAligned = false;
		}
	}
}
