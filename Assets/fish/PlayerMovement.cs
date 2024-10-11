using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;

    public float scalesize = 0.25f;

    public Camera MainCamera;

    public SpriteRenderer SpriteR;

    public Sprite CF;
    public Sprite AF;
    public Sprite BT;
    public Sprite BF;
    public Sprite Eel;
    public Sprite Shark;

    public ScoreScript Scores;

    public bool B_BF;
    public bool B_CF;
    public bool B_AF;
    public bool B_BT;
    public bool B_Eel;
    public bool B_Shark;
    public bool BigShark;

    public float health = 1f;

    public Slider HealthBar;

    public bool HealthCooldown;

    public AudioSource Hurt;
    public AudioSource Eat;

    public TextMeshProUGUI ScoresText;

    // Update is called once per frame
    void Update()
    {
        ScoresText.text = Scores.Score.ToString();
        if(health > 1)
        {
            health = 1;
            HealthBar.value = health;
        }
        if(health < 0)
        {
            SceneManager.LoadScene("Lose");

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position += transform.right * -moveSpeed * Time.deltaTime;
            transform.localScale = new Vector3(scalesize, scalesize, scalesize);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position += transform.right * moveSpeed * Time.deltaTime;
            transform.localScale = new Vector3(-scalesize, scalesize, scalesize);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position += transform.up * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position += transform.up * -moveSpeed * Time.deltaTime;
        }

        if (Scores.Score > 5)
        {
            B_CF = false;
            B_BT = true;
            SpriteR.sprite = BT;
            scalesize = 0.35f;
            MainCamera.orthographicSize = 6;
        }

        if (Scores.Score > 25)
        {
            B_AF = true;
            B_BT = false;
            SpriteR.sprite = AF;
            scalesize = 0.5f;
            MainCamera.orthographicSize = 7;
        }

        if (Scores.Score > 50)
        {
            B_AF = false;
            B_BF = true;
            SpriteR.sprite = BF;
            scalesize = 0.6f;
            MainCamera.orthographicSize = 8;
        }

        if (Scores.Score > 200)
        {
            B_Eel = true;
            B_BF = false;
            SpriteR.sprite = Eel;
            scalesize = 0.7f;
            MainCamera.orthographicSize = 9;
        }

        if (Scores.Score > 500)
        {
            B_Eel = false;
            B_Shark = true;
            SpriteR.sprite = Shark;
            scalesize = 1;
            MainCamera.orthographicSize = 10;

        }

        if (Scores.Score > 750)
        {
            SpriteR.sprite = Shark;
            scalesize = 2;
            MainCamera.orthographicSize = 15;
            BigShark = true;
            B_Shark = false;
        }

        if (Scores.Score > 1250)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "CF")
        {
            if(B_CF && !HealthCooldown)
            {
                health = health - 0.05f;
                HealthBar.value = health;
                StartCoroutine(HurtCooldown());
                Hurt.Play();
            }

            if (!B_CF)
            {
                Scores.Score = Scores.Score + 2f;
                Destroy(other.gameObject);
                Eat.Play();
            }
        }

        if (other.tag == "BT")
        {
            if (B_BT || B_CF && !HealthCooldown)
            {
                health = health - 0.05f;
                HealthBar.value = health;
                StartCoroutine(HurtCooldown());
                Hurt.Play();
            }

            if (!B_BT && !B_CF)
            {
                Scores.Score = Scores.Score + 4f;
                Destroy(other.gameObject);
                Eat.Play();
            }
        }

        if (other.tag == "AF")
        {
            if (B_AF || B_BT || B_CF && !HealthCooldown)
            {
                health = health - 0.05f;
                HealthBar.value = health;
                StartCoroutine(HurtCooldown());
                Hurt.Play();
            }

            if (!B_AF && !B_BT && !B_CF)
            {
                Scores.Score = Scores.Score + 8f;
                Destroy(other.gameObject);
                Eat.Play();
            }
        }

        if (other.tag == "BF")
        {
            if (B_BF || B_AF || B_BT || B_CF && !HealthCooldown)
            {
                health = health - 0.05f;
                HealthBar.value = health;
                StartCoroutine(HurtCooldown());
                Hurt.Play();

            }

            if (!B_BF && !B_AF && !B_BT && !B_CF)
            {
                Scores.Score = Scores.Score + 16f;
                Destroy(other.gameObject);
                Eat.Play();
            }
        }

        if (other.tag == "EEL")
        {
            if (B_Eel || B_BF || B_AF || B_BT || B_CF && !HealthCooldown)
            {
                health = health - 0.05f;
                HealthBar.value = health;
                StartCoroutine(HurtCooldown());
                Hurt.Play();
            }

            if (!B_Eel && !B_BF && !B_AF && !B_BT && !B_CF)
            {
                Scores.Score = Scores.Score + 30f;
                Destroy(other.gameObject);
                Eat.Play();
            }
        }


        if (other.tag == "S")
        {
            if (B_Shark || B_Eel || B_BF || B_AF || B_BT || B_CF && !HealthCooldown)
            {
                health = health - 0.05f;
                HealthBar.value = health;
                StartCoroutine(HurtCooldown());
                Hurt.Play();
            }

            if (BigShark)
            {
                Scores.Score = Scores.Score + 50f;
                Destroy(other.gameObject);
                Eat.Play();
            }
        }

        if (other.tag == "Food")
        {
            Scores.Score = Scores.Score + 0.5f;
            Destroy(other.gameObject);
            Eat.Play();
        }

        if (other.tag == "HealthBubble")
        {
            health = health + 0.5f;
            HealthBar.value = health;
            Destroy(other.gameObject);
            Eat.Play();
        }
    }


    IEnumerator HurtCooldown()
    {
        HealthCooldown = true;
        yield return new WaitForSecondsRealtime(2f);
        HealthCooldown = false;
    }
}
