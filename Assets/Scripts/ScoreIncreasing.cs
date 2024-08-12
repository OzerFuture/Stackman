using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreIncreasing : MonoBehaviour
{
    private TMP_Text _score;

    public GameObject scores;

    public float scorecount;

    void Start()
    {
        InvokeRepeating(nameof(IncreaseScore), 0.5f, 0.5f);
    }

    public void IncreaseScore()
    {
        scorecount++;
        _score = scores.GetComponent<TMP_Text>();
        _score.text = scorecount.ToString();
    }

}
