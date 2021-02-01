using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;
    public Text winText;
    public Text loseText;
    public bool gameOver = false;
    public bool losePlayed = false;
    public bool winGame = false;
    public float timer = 12f;
    public AudioClip winMusic;
    public AudioClip loseMusic;
    public AudioClip mainMusic;
    public AudioClip jumpSound;
    public AudioSource musicSource;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();   
        audioSource = GetComponent<AudioSource>();
	    musicSource.clip = mainMusic;
	    musicSource.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (timer <= 0)
        {
            gameOver = true;
        }
        if (Input.GetKeyDown(KeyCode.R) && gameOver)
	    {
		    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	    }
        if (Input.GetKeyDown(KeyCode.R) && winGame)
	    {
		    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	    }
        if (winGame == false && gameOver && !losePlayed)
	    {
		    loseText.text = "You lost! Press R to Restart ";
             musicSource.clip = loseMusic;
		    musicSource.Play();
            losePlayed = true;
	    }
        if (gameOver == true)
        {
            speed = 0f;
            timer = 10;
        }
        if (winGame == true)
        {
            speed = 0f;
            timer = 10;
        }
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }
     void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            timer = -10;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "win")
        {
           winGame = true;
           winText.text = "You Win Milan Curlej's Game! Press R to restart"; 
            musicSource.clip = winMusic;
		    musicSource.Play();
		    musicSource.loop = true;
        }
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
            PlaySound(jumpSound);
		    
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }
}