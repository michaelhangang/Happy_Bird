using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour {
    public float speed = 200f;
    public AudioClip musicstop;
    public AudioClip musicClip;
    public AudioSource musicSource;
    public AudioSource musicdie;
    private bool isDead =false;
    private Rigidbody2D rb2d;
    private Animator anim;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        musicSource.clip = musicClip;
        musicdie.clip = musicstop;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isDead == false)
        {
            
            if (Input.GetMouseButtonDown(0)||Input.GetKeyDown("space"))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0,speed));
                anim.SetTrigger("flag");
            }


        }
	}

     void OnCollisionEnter2D()
    {
        isDead = true;
        musicSource.Play();
        musicdie.Stop();
        GameController.instance.BirdDie();
        anim.SetTrigger("die");
    }
}
