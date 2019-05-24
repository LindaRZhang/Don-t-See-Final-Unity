/**
 * Created as part of Unity Breakout Tutorial https://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/creating-a-breakout-game
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GM instance = null;

    public AudioSource nineteen;
    public AudioSource eighteen;
    public AudioSource seventeen;
    public AudioSource sixteen;
    public AudioSource fifteen;
    public AudioSource fourteen;
    public AudioSource thirteen;
    public AudioSource twelve;
    public AudioSource eleven;
    public AudioSource ten;
    public AudioSource nine;
    public AudioSource eight;
    public AudioSource seven;
    public AudioSource six;
    public AudioSource five;
    public AudioSource four;
    public AudioSource three;
    public AudioSource two;
    public AudioSource one;
    public AudioSource yay;

    public AudioSource twoLife;
    public AudioSource oneLife;

    private GameObject clonePaddle;

	// Use this for initialization
	void Start () 
	{
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

		SetUp ();
	}
	
	// Update is called once per frame
	void Update () 
	{
        
    }

	public void SetUp()
	{
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate (bricksPrefab, transform.position, Quaternion.identity);
	}

	public void CheckGameOver()
	{
		if (bricks < 1) {
			youWon.SetActive (true);
			Time.timeScale = 0.25f;
			Invoke ("Reset", resetDelay);
		}
		if (lives < 1) {
			gameOver.SetActive (true);
			Time.timeScale = 0.25f;
			Invoke ("Reset", resetDelay);
		}

        if (bricks == 19)
        {
            nineteen.Play();
        }
        if (bricks == 18)
        {
            nineteen.Stop();
            eighteen.Play();
        }
        if (bricks == 17)
        {
            eighteen.Stop();
            seventeen.Play();
        }
        if (bricks == 16)
        {
            seventeen.Stop();
            sixteen.Play();
        }
        if (bricks == 15)
        {
            sixteen.Stop();
            fifteen.Play();
        }
        if (bricks == 14)
        {
            fifteen.Stop();
            fourteen.Play();
        }
        if (bricks == 13)
        {
            fourteen.Stop();
            thirteen.Play();
        }
        if (bricks == 12)
        {
            thirteen.Stop();
            twelve.Play();
        }
        if (bricks == 11)
        {
            twelve.Stop();
            eleven.Play();
        }
        if (bricks == 10)
        {
            eleven.Stop();
            ten.Play();
        }
        if (bricks == 9)
        {
            ten.Stop();
            nine.Play();
        }
        if (bricks == 8)
        {
            nine.Stop();
            eight.Play();
        }
        if (bricks == 7)
        {
            eight.Stop();
            seven.Play();
        }
        if (bricks == 6)
        {
            seven.Stop();
            six.Play();
        }
        if (bricks == 5)
        {
            six.Stop();
            five.Play();
        }
        if (bricks == 4)
        {
            five.Stop();
            four.Play();
        }
        if (bricks == 3)
        {
            four.Stop();
            three.Play();
        }
        if (bricks == 2)
        {
            three.Stop();
            two.Play();
        }
        if (bricks == 1)
        {
            two.Stop();
            one.Play();
        }

    }

	void Reset()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void LoseLife()
	{
		lives--;
        if (lives == 2)
        {
            twoLife.Play();
        }
        if (lives == 1)
        {
            oneLife.Play();
        }
        livesText.text = "Lives: " + lives;
		Instantiate (deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy (clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
        Invoke("CheckGameOver", 3f);
        
	}

	void SetupPaddle()
	{
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
	}

	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver ();
	}
}
