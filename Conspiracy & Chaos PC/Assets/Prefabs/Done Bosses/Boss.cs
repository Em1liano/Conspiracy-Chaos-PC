using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Emilian Skoczylas
public class Boss : MonoBehaviour
{
	private Transform player;

	public bool isFlipped = false;

	//[Header("Sounds")]
	//[SerializeField] AudioSource audio;
	//public AudioClip attackSound;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		//audio = GetComponent<AudioSource>();

	}
	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		//StartCoroutine(Waiting());


		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

	//IEnumerator Waiting()
	//   {
	//	yield return new WaitForSeconds(2f);
	//	AudioSource.PlayClipAtPoint(attackSound, transform.position);
	//	Debug.Log("Sound");
	//   }
}
