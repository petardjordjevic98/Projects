using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class MainMenuWindow : MonoBehaviour
{
    private void Awake()
    {
      Button_UI btn=  transform.Find("PlayBtn").GetComponent<Button_UI>();
        btn.hoverBehaviour_Color_Exit = Color.blue;
        btn.ClickFunc = () =>
        {
            Loader.Load(Loader.Scene.GameScene); 

        };
    }
}
