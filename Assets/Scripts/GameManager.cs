using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isPlay;

    [Header("Score Attribute")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    public int totalScore;

    [Header("Switch Bool Condition")]
    public bool guitarPlucked;
    public bool redPushed;
    public bool bluePushed;
    public bool greenPushed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"{totalScore}";

        if (!isPlay)
            gameOverPanel.SetActive(true);
    }
}
