using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public int score_;
    public bool game_running_;

    private List<GameObject> columns_;
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
        score_ = 0;
        foreach (Transform child in transform) {
            if (child.tag == "Column") {
                columns_.Add(child.gameObject);
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

        StopColumns();
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
}
