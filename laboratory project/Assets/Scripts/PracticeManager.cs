using UnityEngine;

public class PracticeManager : MonoBehaviour
{
    int score = 8;
    int hp = 5;
    bool isGameOver = false;

    void Start()
    {
        Debug.Log("연습 시작");

        Damage();
        AddScore();
        Damage();
        AddScore();
        Damage();
        AddScore();

        Heal();
    }

    void AddScore()
    {
        if (isGameOver == true)
        {
            Debug.Log("게임오버 상태라 점수를 올릴 수 없음");
            return;
        }

        score++;
        Debug.Log("점수 증가");
        PrintStatus();

        if (score >= 5)
        {
            Debug.Log("클리어 가능");
        }
    }

    void Damage()
    {
        if (isGameOver == true)
        {
            Debug.Log("이미 게임오버 상태입니다.");
            return;
        }

        hp -= 2;
        Debug.Log("체력 감소");
        PrintStatus();

        if (hp <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("게임 오버");
    }

    void ResetGame()
    {
        score = 0;
        hp = 3;
        isGameOver = false;

        Debug.Log("게임 초기화");
        PrintStatus();
    }

    void PrintStatus()
    {
        Debug.Log("점수: " + score + " / 체력: " + hp + " / 게임오버: " + isGameOver);
    }

    void Heal()
    {
        if (isGameOver == true)
        {
            Debug.Log("게임오버 상태라 체력을 회복할 수 없음");
            return;
        }

        hp++;
        Debug.Log("체력 회복");
        PrintStatus();
    }
}