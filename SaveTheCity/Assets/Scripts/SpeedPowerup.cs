using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SpeedPowerup : MonoBehaviour {

	public float rotationSpeed;
	public GameObject collectEffect;
	public float powerupDuration = 5;
	public float speedMultiplier = 2;
	private float Timer = 0;
	private bool PickUp = false;
	bool checkOn = true;
	bool checkOff = true;

	private float oldRunSpeed;
	private float oldWalkSpeed;
	private float newRunSpeed;
	private float newWalkSpeed;


	private void Start()
	{
		oldRunSpeed = FirstPersonController.RunSpeed;
		oldWalkSpeed = FirstPersonController.WalkSpeed;

		newRunSpeed = FirstPersonController.RunSpeed * speedMultiplier;
		newWalkSpeed = FirstPersonController.WalkSpeed * speedMultiplier;
	}

	void Update ()
	{		
		transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

		if (PickUp && powerupDuration > Timer && MyGameManager.gameState != MyGameManager.GameStates.Pause)
        {
			if (checkOn)
            {
				checkOn = false;

				ApplySpeed();
				gameObject.GetComponent<MeshRenderer>().enabled = false;
				gameObject.GetComponent<SphereCollider>().enabled = false;
			}	

			Timer += Time.deltaTime;
		}
		else if (powerupDuration < Timer && checkOff)
        {
			checkOff = false;

			RemoveSpeed();
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			PickUp = true;

			if (collectEffect)
				Instantiate(collectEffect, transform.position, Quaternion.identity);			
		}
	}

	private void ApplySpeed()
    {
		FirstPersonController.RunSpeed = newRunSpeed;
		FirstPersonController.WalkSpeed = newWalkSpeed;
    }

	private void RemoveSpeed()
    {
		FirstPersonController.RunSpeed = oldRunSpeed;
		FirstPersonController.WalkSpeed = oldWalkSpeed;
	}
}
