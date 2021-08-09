using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   
    public int final; // finalinis score kai mirsti, arba finis
    public Transform spawnPoint; // pradine koordinate
    private Rigidbody rb;
    Animator anim;
    public bool isGrounded; // jump 
    public static GameObject player;
    public Text livesText = null;
    public static AudioSource[] sfx; 
   
    int lives = 3;


    void RestartGame()
    {
        SceneManager.LoadScene("1lygis", LoadSceneMode.Single);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        player = this.gameObject;
        sfx = GameObject.FindWithTag("gamedata").GetComponentsInChildren<AudioSource>();
     
    }
    void StopJump()
    {
        anim.SetBool("isJumping", false);
    }


    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        { lives = 3;
             final = GameData.singleton.score;
            //Debug.Log(final);
           FinalScore.FinalinisScore = final;
           
           SceneManager.LoadScene("Gameover");
           
            

        }


        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log(isGrounded);
        //}

        if (isGrounded)
        { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.velocity = Vector3.up * 8f;
            anim.SetBool("isJumping", true);
           
        }

        }
        if (Input.GetKeyDown(KeyCode.RightArrow) )
        {
            this.transform.Rotate(Vector3.up * 90);
        }
       else if (Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            this.transform.Rotate(Vector3.up * -90);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(-0.7f,0,0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Translate(0.7f, 0, 0);
        }


    }
    void FixedUpdate()
    {
        player.transform.position += player.transform.forward * 0.2f;
       
        if (player.transform.position.y < -2f)
        {
            sfx[2].Play();
            Die();
            
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
        if (other.gameObject.tag == "EndLevel")
        {

            
                sfx[0].Play();
         //   Debug.Log("Next");
            SceneManager.LoadScene("2lygis");
        }
    }
    void Die()
    {
        
        player.transform.position = spawnPoint.position;
        Quaternion target = Quaternion.Euler(0, -180, 0);
        player.transform.rotation = target;
        lives -= 1;
        livesText.text = "Lives: " + lives;
        print(lives);

    }
}
