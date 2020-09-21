using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class Loader 
{
    public enum Scene
    {
        GameScene,
        Loading,
    }
    public static Scene TargetScene;
   public static void Load(Scene scene)//ovo u gameoer windwo
    {
        //  SceneManager.LoadScene(Scene.Loading.ToString());
        //mora jedan update izmedju ova dva da bi se refreshovalo
        TargetScene = Scene.GameScene;
        SceneManager.LoadScene(TargetScene.ToString());

    }
    public static void LoadTargetScene()
    {//ovo se poziva na update
        Debug.Log(TargetScene.ToString());
       
        

    }
    private void Update()
    {
        SceneManager.LoadScene(TargetScene.ToString());

    }
    
}
