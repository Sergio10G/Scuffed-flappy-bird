using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public int score_;
    public bool game_running_;

    private List<GameObject> columns_;
    private List<GameObject> bgs_;
    private GameObject bird_;

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

    public void ResetPositions() {
        bird_.transform.SetPositionAndRotation(new Vector3(0, 5, 0), new Quaternion());
        foreach (GameObject column in columns_) {
            ColumnBehaviour column_script = column.GetComponent<ColumnBehaviour>();
            float start_z = column_script.start_z_;
            column.transform.SetPositionAndRotation(new Vector3(0, 1, start_z), new Quaternion());
            column_script.RandomizeY();
        }
    }
}
