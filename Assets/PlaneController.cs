using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {
	public float speed = 5.0f;
	private bool right, left;
	private bool tumble, backflip;
	private Transform trans;
	// Use this for initialization
	void Start () {
		trans = GetComponent<Transform>();
		Debug.Log ("plane pilot script added to: " + gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveCamTo = transform.position - transform.forward * 10.0f + Vector3.up * 10.0f;
		float bias = 0.96f;
		Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1.0f-bias);
		Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f);
		transform.position += transform.forward * Time.deltaTime * speed;// * speed;
		speed -= transform.forward.y * Time.deltaTime * 50.0f;
		if (speed < 35.0f) {
			speed = 35.0f;
		}
		//transform.rotation = new Quaternion (0, 0, 0, 0);
		float horVal = -Input.GetAxis ("Horizontal");
		Debug.Log (Input.GetAxis ("Horizontal"));
		if ((transform.eulerAngles.z >= 0 && transform.eulerAngles.z < 30) || (transform.eulerAngles.z < 360 && transform.eulerAngles.z > 330)) {

			right = true;
			left = true;
			transform.Rotate (0.0f, 0.0f, horVal);
		} else {
			if (transform.eulerAngles.z > 30 && transform.eulerAngles.z < 50) {
				left = false;

			} else {
				right = false;
			} 

			if (horVal > 0 && right == false) {
				transform.Rotate (0.0f, 0.0f, horVal);
			}
			if (horVal < 0 && left == false) {
				transform.Rotate (0.0f, 0.0f, horVal);
			}
	
		}

		float virtVal = Input.GetAxis ("Vertical");
		Debug.Log (Input.GetAxis ("Vertical"));
		if ((transform.eulerAngles.x >= 0 && transform.eulerAngles.x < 30) || (transform.eulerAngles.x < 360 && transform.eulerAngles.x > 330)) {
			tumble = true;
			backflip = true;
			transform.Rotate (virtVal, 0.0f, 0.0f);
		} else {
			if (transform.eulerAngles.x > 30 && transform.eulerAngles.x < 50) {
				tumble = false;
				
			} else {
				backflip = false;
			} 
			
			if (virtVal > 0 && backflip == false) {
				transform.Rotate (virtVal, 0.0f, 0.0f);
			}
			if (virtVal < 0 && tumble == false) {
				transform.Rotate (virtVal, 0.0f, 0.0f);
			}
			
		}

//		if ((transform.eulerAngles.x >= 0 && transform.eulerAngles.x < 30) || (transform.eulerAngles.x < 360 && transform.eulerAngles.x > 330)) {
//			transform.Rotate (Input.GetAxis ("Vertical"), 0.0f, 0.0f);
//		} else {
//
//			if (transform.eulerAngles.x > 30 && transform.eulerAngles.x < 50) {
//				transform.Rotate (-0.03f, 0.0f, 0.0f);
//			} else {
//				transform.Rotate (0.03f, 0.0f, 0.0f);
//			}
//		}



		//Debug.Log (transform.eulerAngles.z);
	}
}
