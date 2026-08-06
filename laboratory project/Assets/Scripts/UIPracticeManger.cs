using UnityEngine;
using TMPro;
using System.Collections;

public class UIPracticeManger : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text hpText;
    public TMP_Text stateText;

    int score = 0;
    int hp = 3;
    bool isGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "점수: " + score;
        hpText.text = "체력: " + hp;
        stateText.text = "상태: 준비완료";
    }

    public void AddScore()
    {
        score++;
        stateText.text = "상태: 점수 증가";
        StartCoroutine(TextRoutin());
    }

    IEnumerator TextRoutin()
    {
        scoreText.text = "점수: " + score;
        yield return new WaitForSeconds(1f);
        UpdateUI();
    }

    public void Damage()
    {
        if (isGameOver == true)
        {
            stateText.text = "상태: 게임오버";
            return;
        }

        hp--;
        stateText.text = "상태: 데미지";

        if (hp <= 0)
        {
            isGameOver = true;
            stateText.text = "상태: 게임오버";
        }
        StartCoroutine(TextRoutin());
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
