using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float secondsLeft;
	public Text countText;
	public Text resultText;
	public Text timerText;

	private Rigidbody rb;
	private int count;

	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		resultText.text = "";
	}  

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void Update ()
	{
		secondsLeft -= Time.deltaTime;

		timerText.text = "Time Left: " + secondsLeft.ToString ()
			+ " Seconds";
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12)
		{
			resultText.text = "You Win!";
		}
	}
}
