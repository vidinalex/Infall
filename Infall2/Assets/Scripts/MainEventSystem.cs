using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainEventSystem : MonoBehaviour
{
    [Header("Score")]
    public int score = 0;
    public Text GUIScore;
    public GameObject GMScore;
    [Header("Game obj")]
    public GameObject Player;
    public GameObject PlayerSkin;
    public GameObject PlayerCollider;
    [Header("AnimsUI")]
    public GameObject UI1;
    public GameObject UI2;
    public GameObject Plate1;
    public GameObject Plate2;
    public GameObject Snow;
    public GameObject Pause;
    public GameObject End;
    public GameObject Last;
    public GameObject Record;
    public GameObject Resume;
    [Header("Strings")]
    public string Left = "Left";
    public string Right = "Right";
    [Header("Start things")]
    public GameObject pressToStart;
    [Header("Spawn prefs")]
    public float CurretntSpawn = -3f;
    public float NextSpawn = -3f;
    public float SpawnRate = 31f;
    public GameObject[] GS1;
    public GameObject[] GS2;
    public GameObject[] GS3;

    Movment m;

    private void Awake()
    {
        Player.GetComponent<Movment>().enabled = false;
        PlayerSkin.GetComponent<SmoothFollow>().enabled = false;
        PlayerSkin.GetComponent<Bondaries>().enabled = false;
        PlayerCollider.GetComponent<Colliderfollow>().enabled = false;

        Plate1.SetActive(false);
        Plate2.SetActive(false);

        GMScore.SetActive(false);

        Last.GetComponent<Text>().text = PlayerPrefs.GetInt("Last", 0).ToString();
        Record.GetComponent<Text>().text = PlayerPrefs.GetInt("Record", 0).ToString();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump")) Activate();
        if(PlayerSkin)
        if((NextSpawn + SpawnRate) > PlayerSkin.transform.position.y)
        {
            NextSpawn -= SpawnRate;
            SpawnLevl();
        }
    }

    public void UpdateScore()
    {
        GUIScore.text = score.ToString();
        GMScore.GetComponent<Animator>().SetTrigger("Increase");
    }

    private void SpawnLevl()
    {
        GameObject temp = GS1[Random.Range(0, GS1.Length)];
        Instantiate(temp, new Vector3(0f,NextSpawn),temp.transform.rotation);
    }

    private void Start()
    {
        m = GameObject.FindGameObjectWithTag("Player").GetComponent<Movment>();
    }
    public void ButtonEventDown(string name)
    {
        if (name.Equals(Left)) m.Left(true);
        else m.Right(true);
        Debug.Log(name + " is down");
    }

    public void ButtonEventUp(string name)
    {
        if (name.Equals(Left)) m.Left(false);
        else m.Right(false);
        Debug.Log(name + " is up");
    }

    public void StartGame()
    {
        m.enabled = true;
        Debug.Log(m);

        pressToStart.SetActive(false);
    }

    public void Activate()
    {
        GMScore.SetActive(true);
        Plate1.SetActive(true);
        Plate2.SetActive(true);
        Pause.SetActive(true);

        Debug.Log("GameStarted");
        UI1.GetComponent<Animator>().SetBool("Start", true);
        UI2.GetComponent<Animator>().SetBool("Start", true);
        Snow.GetComponent<Animator>().SetBool("Start", true);
        Player.GetComponent<Movment>().enabled = true;
        PlayerSkin.GetComponent<SmoothFollow>().enabled = true;
        PlayerCollider.GetComponent<Colliderfollow>().enabled = true;
    }

    public void PauseF()
    {
        Time.timeScale = 0;
        Pause.SetActive(false);
        Resume.SetActive(true);
    }

    public void ResumeF()
    {
        Time.timeScale = 1;
        Resume.SetActive(false);
        Pause.SetActive(true);
    }

    public void Die()
    {
        End.SetActive(true);
        Invoke("DieAnim", 1.5f);
    }

    void DieAnim()
    {
        End.GetComponent<Animator>().SetBool("End", true);
        Invoke("Restart", 1.1f);
    }

    void Restart()
    {
        PlayerPrefs.SetInt("Last", score);
        if(PlayerPrefs.GetInt("Record",0)<score) PlayerPrefs.SetInt("Record", score);
        SceneManager.LoadScene(0);
    }
}
