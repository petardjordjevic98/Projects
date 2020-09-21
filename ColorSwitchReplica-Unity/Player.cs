using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float jumpingForce = 9f;
    // Start is called before the first frame update
    public Rigidbody2D rb;//ovo ce kreirati loptici i dodati samo u unity
    public  SpriteRenderer sr;//treba nam ova referenca da bismo promenili boju
    public string CurrentColor;//trenutna boja lotpice
    public bool first=false;
    public Color purple;
    public Color pink;
    public Color yellow;
    public Color cyan;
    public int  count=0;
    public Text Score;
    public  AudioClip click;
    public static Player instance;
   
    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            // PlaySound();
            SoundManager.PlaySound();
            if (first)
                
            {
                rb.velocity = Vector2.up * jumpingForce;
            }
            else
            {
                first = true;
                rb.bodyType = RigidbodyType2D.Dynamic;


            }
        }
       
    }
    private void Start()
    {
        instance = this;

        rb.bodyType = RigidbodyType2D.Static;
        SetRandom();//fja koja ce da izabere random boju za lotpicu
    }

   
    //prvo proverimo sa cim smo se sudarili preko tag-a, tj da li je to ta boja
    private void OnTriggerEnter2D(Collider2D collision)
    {//svaki put kad udarimo u collision ovo se esi
        if (collision.tag=="ColorChanger")
        {
            SetRandom();
            Destroy(collision.gameObject);
            return;
        }
        if (collision.tag != CurrentColor && collision.tag!="Star")
            SceneManager.LoadScene("Main");
            Debug.Log("GAME OVER!");
        if (collision.tag=="Star")
        {
            count++;
            Score.text = count.ToString();
            Destroy(collision.gameObject);        }
    }
    

    private void SetRandom()
    {
        int index = Random.Range(0, 3);
        switch(index)
        {
            case 0:
                CurrentColor = "Pink";
                sr.color = pink;
                break;
                 case 1:
                CurrentColor = "Cyan";
                sr.color = cyan;
                break;
            case 2:
                CurrentColor = "Purple";
                sr.color = purple;
                break;
            case 3:
                CurrentColor = "Yellow";
                sr.color = yellow;
                break;

        }
    }
}
