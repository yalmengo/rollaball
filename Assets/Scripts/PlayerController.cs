using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
	public GameObject winTextObject;

    private int count;
    private Rigidbody rb;
    private AudioSource audio;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        count = 0;

        SetCountText ();
        winTextObject.SetActive(false);
        StartCoroutine(sceneLoader());
    }

    void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate() {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            audio.Play();
            count++;
            SetCountText();
        }
    }

     void SetCountText()
	{
		countText.text = "Puntos: " + count.ToString();

		if (count >= 12) 
		{
            winTextObject.SetActive(true);
		}
	}

    IEnumerator sceneLoader()
    {
        Debug.Log("Waiting for Player score to be >=12 ");
        yield return new WaitUntil(() => count >= 12);
        Debug.Log("Player score is >=12. Loading next Level");
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
