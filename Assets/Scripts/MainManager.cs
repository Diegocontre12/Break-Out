using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text nameText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
        if (MainManagerx.Instance != null)
        {
            
            MainManagerx.Instance.LoadNameHig();
            MainManagerx.Instance.LoadCurrentName();
            MainManagerx.Instance.LoadHightScore();
            string playerName = MainManagerx.Instance.playerNameHig;
            int hscore = MainManagerx.Instance.HigPlayerScore;
            nameText.text = "Best Score " + playerName + ": " + hscore;
            Debug.Log("mayor puntaje " + hscore);

        }
        
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (m_Points> MainManagerx.Instance.HigPlayerScore)
        {
            nameText.text = "Best Score " + MainManagerx.Instance.playerName + ": " + m_Points;
        }
        else
        {
            nameText.text = "Best Score " + MainManagerx.Instance.playerNameHig + ": " + MainManagerx.Instance.HigPlayerScore;
        }
       

        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
               
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        if (m_Points > MainManagerx.Instance.HigPlayerScore)
        {
            Debug.Log("currentPoints" + m_Points);
            MainManagerx.Instance.SaveHigScore(m_Points);
            MainManagerx.Instance.SaveNameHig(MainManagerx.Instance.playerName);
        }
        m_GameOver = true;
        GameOverText.SetActive(true);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
