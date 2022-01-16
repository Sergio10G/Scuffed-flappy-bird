using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerBehaviour : MonoBehaviour
{
    private GameBehaviour game_script_;

    private void Awake()
    {
        GameObject game = GameObject.Find("Game");
        game_script_ = game.GetComponent<GameBehaviour>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bird") {
            game_script_.score_ += 1;
            Debug.Log("Score: " + game_script_.score_);
        }
    }
}
