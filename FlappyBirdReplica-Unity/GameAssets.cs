using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets instance;
    public static GameAssets GetInstanceOf()
    {
        return instance;
    }
    private void Awake ()
    {
        Debug.Log("p");
        instance = this;   
    }
    public Sprite pipeHeadSprite;
    public Transform pfPipeBody;
    public Transform pfPipeHead;
    public AudioClip birdJump;
}
