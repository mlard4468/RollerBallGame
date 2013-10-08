using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{	
	
	public float speed;
	private int count = 0;
	public GUIText CountText;
	public GUIText WinText;
	
	void Start()
	{
		//count = 0;
		
		SetCountText();
		WinText.text = "";
	}
	
	void FixedUpdate()
	{
		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");
		
		rigidbody.AddForce(new Vector3(moveHorizontal,0.0f,moveVertical)* speed * Time.deltaTime);
	}
	
	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.tag=="Pickup")
		{
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
		}
		//Destroy(other.gameObject);
	}
	
	void SetCountText()
	{
		CountText.text = "Count: "+count.ToString();
		if (count>=11)
			WinText.text = "You are a weiner";
	}
	
}
