using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class Level : MonoBehaviour
{
    private const float CAMERA_ORTO_SIZE = 50f;//ortosajz kamere
    private const float PIPE_WIDTH = 10.4f;//sirina stuba
    private const float PIPE_HEAD_HEIGHT = 3.75f;//visina glave pajpa
    private const float PIPE_MOVE_SPEED = 30f;//brzina kretanja stubova
    private const float PIPE_DESTROY_X_POS = -100f;//gde treba da se uniste stubovi tj kada napuste scenu
    private const float PIPE_SPAWN_X_POS = 100f;//gde se stvaraju
    private const float BIRD_X_POSITION = 0f;
    private int PipesPassedBird;
    private List<Pipe> pipes;//niz stvorenih pajpova
    private float PipeSpawnTimer;//za vreme kad se stvaraju pajpovi
    private float PipeSpawnTimerMax;//na koliko da se stvaraju
    private float gapSize;//velicina izmedju donjeg i gornjeg stuba
    private int pipesspawn;//broj stuboa
    private static Level Instance;//da bism mogli da pristupimo u drugim skriptama
    private State state;
    public static Level GetInstance()
    {
        return Instance;//vraca nam tu isntancu
    }
    public enum Difficulty{
    Easy,
    Medium,
    Hard,
    Impossible
    }
    public enum State
    {
        Playing,BirdIsDead,WaitingToStart
    }
    private void Awake()//ovo se izvrsava jendom u kodu i to pre nego sto je startoavala igrica
    {
        state = State.WaitingToStart;
        Instance = this;//postavlja se samo jednom ta instanca
        PipeSpawnTimerMax = 1f;//na koliko da se generisu stubovi
        pipes = new List<Pipe>();
        gapSize = 50f;//inicjalna velicina razmak
    }
    private void Start()//slicno kao awake samo sto se poziva kada se prvi put update vrsi,update se vrsi svaki put
        //kad se ucita frame
            
    {
        //CreatePipe(40f, 0f,true);
        //CreatePipe(40f, 0f, false);
        //CreateGapPipe(50f, 20f, 20f);
        Bird.GetInstance().OnDied += Bird_OnDied1;
        Bird.GetInstance().OnStartedPlaying += Bird_OnStartedPlaying;

        //ovde dodamo jos jedan event koji se triguerju kad se trigeruje ondied u bird
    }
    private void Bird_OnStartedPlaying(object sender, EventArgs e)
    {
        state = State.Playing;
    }
    private void Bird_OnDied1(object sender, EventArgs e)
    {
        //CMDebug.TextPopupMouse("Died");
        state = State.BirdIsDead;
       

    }

    public int GetPipeSpawn()//ovaj nam vraca broj napravljenih pajpova
    {
        return pipesspawn;
    }
    public int GetPassedPipes()//ovaj nam vraca broj napravljenih pajpova
    {
        return PipesPassedBird;
    }
    private void SetDifficulty(Difficulty d)
    {
        switch(d)
        {
            case Difficulty.Easy:
                gapSize = 50f;//menja se u zavisnosti od tezine
                PipeSpawnTimerMax = 1.2f;
                break;
            case Difficulty.Medium:
                gapSize = 40f;
                PipeSpawnTimerMax = 1.1f;
                break;
            case Difficulty.Hard:
                gapSize = 33f;
                PipeSpawnTimerMax = 1f;
                break;
            case Difficulty.Impossible:
                gapSize = 24f;
                PipeSpawnTimerMax = 0.9f; 
                break;
                
        }
    }
    private Difficulty GetDifficulty()
    {//u zavisnosti koliko je generisano stubova menja se tezina
        if (pipesspawn  >=30) return Difficulty.Impossible;
        if (pipesspawn >=20) return Difficulty.Hard;
        if (pipesspawn >= 10) return Difficulty.Medium;
        return Difficulty.Easy;

    }
    private void Update()//na svaki frejm
    {
        if (state == State.Playing)
        {
            HandlePipeMovement();
            HandlePipeSpawnig();
        }
    }
    private void HandlePipeSpawnig(){// vo je za kreiranje stubova dole igore
        PipeSpawnTimer -= Time.deltaTime;
        if(PipeSpawnTimer<0)
        {
            PipeSpawnTimer += PipeSpawnTimerMax;
            float heightlimit = 10f;
            float totalheight = CAMERA_ORTO_SIZE * 2f;
            float maxheight = totalheight - gapSize / 2 - heightlimit;
            float minHeight = gapSize * .5f+ heightlimit;
            float height = UnityEngine.Random.Range(minHeight, maxheight);
            CreateGapPipe(height, gapSize, PIPE_SPAWN_X_POS);

        }
    }
    private void HandlePipeMovement()//za pomeranje i unsiaavanje
    {for (int i = 0; i < pipes.Count; i++)
        {
            Pipe t = pipes[i];
            bool IsTheRightOfBird = t.getXPos() > BIRD_X_POSITION;//ako je desn od pajpa onda pomeramo pajp
            t.Move();
            if (IsTheRightOfBird && t.getXPos() <=BIRD_X_POSITION && t. IsBotton())
            {
                //pipe je prosao pticu
                PipesPassedBird++;
            }
            if (t.getXPos() < PIPE_DESTROY_X_POS)
            //destrot paipe{
            {
                t.DestroySelf();
                pipes.Remove(t);
                i--;
            }
        }

    }
    private void CreateGapPipe(float gapY, float gapSize, float xPosition)
    {//kreria se na ove koordinate
        CreatePipe(gapY - gapSize * .5f, xPosition, true);
        CreatePipe(CAMERA_ORTO_SIZE * 2f - gapY - gapSize * .5f, xPosition, false);
        pipesspawn++;//i povecava se broj nacranih
        SetDifficulty(GetDifficulty());
    }
    private void CreatePipe(float height, float XPosition, bool CreateButton)
    {

        Transform PipeHead = Instantiate(GameAssets.GetInstanceOf().pfPipeHead);
        float pipeHeadYpositon;
        if (CreateButton)
        {
            pipeHeadYpositon = -CAMERA_ORTO_SIZE + height - PIPE_HEAD_HEIGHT * .5f;
        }
        else
            pipeHeadYpositon = +CAMERA_ORTO_SIZE - height + PIPE_HEAD_HEIGHT * .5f;
        PipeHead.position = new Vector3(XPosition, pipeHeadYpositon);
        
        //seting body
        Transform PipeBody = Instantiate(GameAssets.GetInstanceOf().pfPipeBody);
        float pipeBodyYPosition;
        if (CreateButton)
        {
            pipeBodyYPosition = -CAMERA_ORTO_SIZE;
        }
        else
        {
            pipeBodyYPosition = +CAMERA_ORTO_SIZE;
            PipeBody.localScale = new Vector3(1, -1, 1);//jer nam je botton onaj directon   
        }
        PipeBody.position = new Vector3(XPosition, pipeBodyYPosition);

        //postavljanje kolajdera za stubove
        SpriteRenderer spriteBodypipeBody = PipeBody.GetComponent<SpriteRenderer>();
        spriteBodypipeBody.size = new Vector2(PIPE_WIDTH, height);
        BoxCollider2D pipebodyboxCollider2D = PipeBody.GetComponent<BoxCollider2D>();
        pipebodyboxCollider2D.size = new Vector2(PIPE_WIDTH, height);
        pipebodyboxCollider2D.offset = new Vector2(0f, height * .5f);

        Pipe p = new Pipe(PipeBody, PipeHead, CreateButton);
        pipes.Add(p);
    }
    public class Pipe//zbog lakseg rada sa pajpovima kalasa
    {
        private Transform BodyTransform;
        private Transform HeadTransform;
        private bool CreateButton;
        public Pipe(Transform BodyTransform, Transform HeadTransform, bool CreateButton)
        {
            this.BodyTransform = BodyTransform;
            this.HeadTransform = HeadTransform;
            this.CreateButton =CreateButton;
        }
        public bool IsBotton()
        {
            return CreateButton;
        }
        public void Move()
        {
            HeadTransform.position += new Vector3(-1, 0, 0) * PIPE_MOVE_SPEED * Time.deltaTime;
            BodyTransform.position += new Vector3(-1, 0, 0) * PIPE_MOVE_SPEED * Time.deltaTime;
            //pomeramo ga,idu ulevo zato je -1 x koordinataa
        }
        public float getXPos()
        {
            return this.HeadTransform.position.x;   
        }
        public void DestroySelf()
        {
            Destroy(BodyTransform.gameObject);
            Destroy(HeadTransform.gameObject);
        }
    }
}

