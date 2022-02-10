using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBehaviour : MonoBehaviour
{
    GameObject mainMenu_;
    GameObject inGameUI_;
    GameObject gameOver_;

    void Awake() {
        InitUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowUI(int index) {
        if (!mainMenu_ || !inGameUI_ || !gameOver_)
            InitUI();
        mainMenu_.SetActive(false);
        inGameUI_.SetActive(false);
        gameOver_.SetActive(false);
        switch (index) {
            case 0:
                mainMenu_.SetActive(true);
                break;
            case 1:
                inGameUI_.SetActive(true);
                break;
            case 2:
                gameOver_.SetActive(true);
                break;
        }
    }

    public void InitUI() {
        mainMenu_ = gameObject.GetComponent<RectTransform>().GetChild(0).gameObject;
        inGameUI_ = gameObject.GetComponent<RectTransform>().GetChild(1).gameObject;
        gameOver_ = gameObject.GetComponent<RectTransform>().GetChild(2).gameObject;
    }
}
