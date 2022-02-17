using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryTextBehaviour : MonoBehaviour
{
    GameObject text_top_;
    GameObject text_bot_;
    float time_;
    float start_time_;
    bool uc_;

    private void Awake()
    {
        InitUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitUI();
        time_ = Time.time;
        start_time_ = Time.time;
        uc_ = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time - time_ >= 0.2)
        {
            if (uc_)
            {
                text_bot_.GetComponent<Text>().text = text_bot_.GetComponent<Text>().text.ToLower();
                text_top_.GetComponent<Text>().text = text_top_.GetComponent<Text>().text.ToLower();
                uc_ = false;
            }
            else
            {
                text_bot_.GetComponent<Text>().text = text_bot_.GetComponent<Text>().text.ToUpper();
                text_top_.GetComponent<Text>().text = text_top_.GetComponent<Text>().text.ToUpper();
                uc_ = true;
            }
            time_ = Time.time;
        }

        if (Time.time - start_time_ >= 20)
            Application.Quit();
    }

    void InitUI()
    {
        text_top_ = gameObject.GetComponent<RectTransform>().GetChild(0).gameObject;
        text_bot_ = gameObject.GetComponent<RectTransform>().GetChild(1).gameObject;
    }
}
