using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class GameOverWindow : MonoBehaviour
{
    // Start is called before the first frame update
    private Text scoreText;
    private static GameOverWindow
        g;
    public static GameOverWindow GetIn()
    {
        return g;
    }
    private void Awake()
    {//pribavili smo scoreText
        g = this;
        scoreText = transform.Find("Score").GetComponent<Text>();//sada pravimo za klik na baton
        //ucitacemo scenu onu
        Button_UI btn = transform.Find("RetryBtn").GetComponent<Button_UI>();
        btn.ClickFunc = () =>
        {
           

           Loader.Load(Loader.Scene.GameScene);
        };

        btn.SetHoverBehaviourType(Button_UI.HoverBehaviour.Change_Color);
        btn.hoverBehaviour_Color_Exit = Color.blue;
        

        Hide();//prvo je sakrijena

    }
    private void Start()
    {
        Bird.GetInstance().OnDied += Bird_OnDied;
         Show();
    }//prijavljujemo se na dogadjaj da bismo ovo mogli da radimo kada
    //umre ptica
  private void Bird_OnDied(object sender, System.EventArgs e)
    {
        scoreText.text = Level.GetInstance().GetPassedPipes().ToString();//uzimamo broj koje je prosao
        Show();//prikazuje se kada umre ptica
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
}
