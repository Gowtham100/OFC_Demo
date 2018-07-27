using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solarminigame : MonoBehaviour {

    public GameObject miniGame;
    public GameObject player;
    public GameObject sparkles;
    public GameObject text;
    float rotSpeed = 50f;
    float yPos;
    bool wonGame = false; 

	// Use this for initialization
	void Start () {
        miniGame.SetActive(false);
        sparkles.SetActive(false);
        text.SetActive(false);
	}

    void Update()
    {
        yPos = this.transform.eulerAngles.y;

        if (yPos > 250 && yPos < 290 && !wonGame)
        {
            StartCoroutine(winGame());
            Debug.Log("wonGame");
            wonGame = true;
        }
    }
	
	// Update is called once per frame
	void OnMouseDrag () {
        float xRot = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;

        this.transform.Rotate(Vector3.up, -xRot);
        Debug.Log("rotating");
		
	}

    public void ShowMinigame()
    {
        miniGame.SetActive(true);

        StartCoroutine(StartGame()); 
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(4f);

        player.SetActive(false);
    }

    


    private IEnumerator winGame()
    {
        sparkles.SetActive(true);
        text.SetActive(true);
        

        yield return new WaitForSeconds(1f);

        miniGame.SetActive(false);
        player.SetActive(true);
    }
}
