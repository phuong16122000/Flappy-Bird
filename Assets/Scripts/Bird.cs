using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float jumpForce;
    private bool levelStart;
    public GameObject gameController;
    public GameObject message;
    private int score;
    public Text scoreText;

    private void Awake()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        levelStart = false;
        rigidbody.gravityScale = 0;
        score = 0;
        scoreText.text = score.ToString();
        message.GetComponent<SpriteRenderer>().enabled = true;
    }

    void Update()
    {
        //Kiem tra xem phim Space co duoc bam khong?
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundController.instance.PlayThisSound("wing", 0.5f);
            if(levelStart == false)
            {
                levelStart = true;
                rigidbody.gravityScale = 6;
                gameController.GetComponent<PipeGenerator>().enableGenratePipe = true;
                message.GetComponent<SpriteRenderer>().enabled = false;
            }
            BirdMoveUp();
        }
    }

    private void BirdMoveUp() //Lam chim bay len 1 khoang
    {
        rigidbody.velocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundController.instance.PlayThisSound("hit", 0.5f);
        ReloadScene();
        score = 0;
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundController.instance.PlayThisSound("point", 0.5f);
        score += 1;
        scoreText.text = score.ToString();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("_gameplay");
    }
}
