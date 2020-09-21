using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using System;

public class Bird : MonoBehaviour
{
    private const float JUMP_AMOUNT = 100f;
    private Rigidbody2D birdrigidbody;
    private static Bird ins;
    public static Bird GetInstance()
    {
        return ins;
    }
    //dodamo event kada ptica umre
    public event EventHandler OnDied;
    public event EventHandler OnStartedPlaying;

    private State state;
    public enum State
    {
        WaitngToStart,
        Playing,Dead

    }
    private void Awake()
        
    {

        birdrigidbody = GetComponent<Rigidbody2D>();
        birdrigidbody.bodyType = RigidbodyType2D.Static;

        state = State.WaitngToStart;
        ins = this;


    }
    private void Update()
    {
        switch(state)
        {
            default:
            case State.Dead:
                OnDied(this, EventArgs.Empty);

                break;
        case State.Playing:
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    Jump();//ako kliknemo space ili levi dugmic na misu
                }
                transform.eulerAngles = new Vector3(0, 0, birdrigidbody.velocity.y * .2f);
                break;

         case State.WaitngToStart:
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    state = State.Playing;
                    birdrigidbody.bodyType = RigidbodyType2D.Dynamic;
                    Jump();//ako kliknemo space ili levi dugmic na misu
                    if (OnStartedPlaying != null) OnStartedPlaying(this, EventArgs.Empty);


                }
                

                break;
            
        }
        
        
    }
    private void Jump()
    {
        birdrigidbody.velocity = Vector2.up * JUMP_AMOUNT;//imamo rigidbody na pticu i preko ovog velocity menjamo
        //joj "brzinu" navise Vector2.up za jump_amout
        SoundManager.PlaySound();
    }

    private void OnTriggerEnter2D (Collider2D collider)//svaki put kada jedan collider dotakne drugi javi se ovo
        //ovo se trigeruje
    {

        birdrigidbody.bodyType = RigidbodyType2D.Static;
        state = State.Dead;
        if (OnDied!=null) OnDied(this, EventArgs.Empty);//ovde se pali event kada umre
        GameOverWindow.GetIn().Show();

    }
}
