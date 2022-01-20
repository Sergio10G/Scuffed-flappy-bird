using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehaviour : MonoBehaviour
{
    public int score_;
    public bool game_running_;

    private List<GameObject> columns_;
    private List<GameObject> bgs_;
    private GameObject bird_;
    private Text score_ui_;

    public enum GameState { 
        MENU,
        PLAYING,
        GAME_OVER
    }

    public GameState game_state_;

    private void Awake()
    {
        columns_ = new List<GameObject>();
        bgs_ = new List<GameObject>();
        score_ = 0;
        foreach (Transform child in transform) {
            if (child.tag == "Column") {
                columns_.Add(child.gameObject);
            }
            else if (child.tag == "Background") {
                bgs_.Add(child.gameObject);
            }
            else if (child.tag == "Bird") {
                bird_ = child.gameObject;
            }
        }

        score_ui_ = GameObject.Find("Score").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterHit() {
        game_state_ = GameState.GAME_OVER;
        bird_.SetActive(false);
        StopColumns();
        StopBgs();
        score_ = 0;
        RefreshScoreUI();

        RestartGame();
    }

    public void RestartGame() {
        game_state_ = GameState.PLAYING;
        bird_.SetActive(true);
        ResetPositions();
        StartColumns();
        StartBgs();
    }

    void StopColumns() {
        if (columns_.Count == 0) {
            return;
        }

        foreach (GameObject column in columns_) {
            ColumnBehaviour col_script = column.GetComponent<ColumnBehaviour>();
            col_script.speed_ = 0.0f;
        }
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

    void StopBgs() {
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

    public void ResetPositions() {
        bird_.transform.SetPositionAndRotation(new Vector3(0, 5, 0), new Quaternion());
        foreach (GameObject column in columns_) {
            ColumnBehaviour column_script = column.GetComponent<ColumnBehaviour>();
            float start_z = column_script.start_z_;
            column.transform.SetPositionAndRotation(new Vector3(0, 1, start_z - 10), new Quaternion());
            column_script.RandomizeY();
        }
        foreach (GameObject bg in bgs_) {
            BackgroundBehaviour bg_script = bg.GetComponent<BackgroundBehaviour>();
            bg_script.ResetPosition();
        }
    }

    public void IncrementScore() {
        score_++;
    }

    public void RefreshScoreUI() {
        score_ui_.text = score_ + "";
    }
}
