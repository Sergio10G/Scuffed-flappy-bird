using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Game objects
    private List<GameObject> columns_;
    private List<GameObject> bgs_;
    private GameObject bird_;
    private CanvasBehaviour canvas_script_;

    // Components
    private Text score_ui_;
    private Text score_ui_bg_;
    private Text gameover_score_ui_;
    private Text gameover_score_ui_bg_;

    // Class attributes
    private static GameManager instance_;
    public static GameManager Instance
    {
        get { return instance_; }
    }

    private int score_;
    public int Score
    {
        get { return score_; }
        set
        {
            score_ = value;
            RefreshScoreUI();
        }
    }

    public enum GameState
    {
        MENU,
        PLAYING,
        GAME_OVER
    }

    private GameState game_state_;
    public GameState CurrentGameState
    {
        get { return game_state_; }
        set
        {
            game_state_ = value;

            switch (value)
            {
                case GameState.MENU:
                    bird_.SetActive(false);
                    StopColumns();
                    StopBgs();
                    break;
                case GameState.PLAYING:
                    Score = 0;
                    bird_.SetActive(true);
                    ResetPositions();
                    StartColumns();
                    StartBgs();
                    break;
                case GameState.GAME_OVER:
                    bird_.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    bird_.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    bird_.SetActive(false);
                    StopColumns();
                    StopBgs();
                    gameover_score_ui_.text = Score + "";
                    gameover_score_ui_bg_.text = Score + "";
                    break;
            }

            canvas_script_.ShowUI((int) value);
        }
    }

    private void Awake()
    {
        if (instance_ != null && instance_ != this)
        {
            Destroy(gameObject);
            return;
        }
        instance_ = this;
        DontDestroyOnLoad(gameObject);
        InitGameObjects();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // My Functions
    private void InitGameObjects()
    {
        columns_ = new List<GameObject>();
        bgs_ = new List<GameObject>();
        score_ = 0;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Column"))
            columns_.Add(go);
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Background"))
            bgs_.Add(go);
        bird_ = GameObject.Find("Bird");
        canvas_script_ = GameObject.Find("Canvas").GetComponent<CanvasBehaviour>();
        score_ui_ = GameObject.Find("Score").GetComponent<Text>();
        score_ui_bg_ = GameObject.Find("Score_bg").GetComponent<Text>();
        gameover_score_ui_ = GameObject.Find("GameOverScore").GetComponent<Text>();
        gameover_score_ui_bg_ = GameObject.Find("GameOverScore_bg").GetComponent<Text>();

        CurrentGameState = GameState.MENU;
    }

    private void RefreshScoreUI()
    {
        score_ui_.text = score_ + "";
        score_ui_bg_.text = score_ + "";
    }

    void StartColumns()
    {
        if (columns_.Count == 0)
        {
            return;
        }

        foreach (GameObject column in columns_)
        {
            ColumnBehaviour col_script = column.GetComponent<ColumnBehaviour>();
            col_script.speed_ = 5.0f;
        }
    }

    void StopColumns()
    {
        if (columns_.Count == 0)
        {
            return;
        }

        foreach (GameObject column in columns_)
        {
            ColumnBehaviour col_script = column.GetComponent<ColumnBehaviour>();
            col_script.speed_ = 0.0f;
        }
    }

    void StartBgs()
    {
        if (bgs_.Count == 0)
        {
            return;
        }

        foreach (GameObject bg in bgs_)
        {
            BackgroundBehaviour bg_script = bg.GetComponent<BackgroundBehaviour>();
            bg_script.speed_ = 2.5f;
        }
    }

    void StopBgs()
    {
        if (bgs_.Count == 0)
        {
            return;
        }

        foreach (GameObject bg in bgs_)
        {
            BackgroundBehaviour bg_script = bg.GetComponent<BackgroundBehaviour>();
            bg_script.speed_ = 0.0f;
        }
    }

    public void ResetPositions()
    {
        bird_.transform.SetPositionAndRotation(new Vector3(0, 5, 0), new Quaternion());
        foreach (GameObject column in columns_)
        {
            ColumnBehaviour column_script = column.GetComponent<ColumnBehaviour>();
            float start_z = column_script.start_z_;
            column.transform.SetPositionAndRotation(new Vector3(0, 1, start_z - 10), new Quaternion());
            column_script.RandomizeY();
        }
    }

    public void RegisterHit()
    {
        CurrentGameState = GameState.GAME_OVER;
    }

    public void RestartGame()
    {
        CurrentGameState = GameState.PLAYING;
    }

    public void ShowMenu()
    {
        CurrentGameState = GameState.MENU;
        ResetPositions();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}