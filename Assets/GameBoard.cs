using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBoard : MonoBehaviour
{

    public enum GameState { start, team1, team2, win }

    public GameState gameState = GameState.start;
    public TermPicker termPicker;
    public Timer timer1, timer2;
    public Button start;
    public Button skip;
    public Button rules;
    public Button next;
    public Canvas main;
    public Text win, teamCount1, teamCount2;
    public int[] points = { 0, 0 };
    public int teamNext = 2;
    public bool canSkip = true;
    // Use this for initialization
    void Start()
    {
        start.gameObject.SetActive(true);
        main.gameObject.SetActive(true);
        termPicker.ChangeTerm(true);
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.team1:
                teamNext = 2;
                timer1.transform.parent.GetComponent<Image>().color = new Color(.12f, .32f, .12f);
                timer2.transform.parent.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                if (timer1.Increment())
                {
                    gameState = GameState.start;
                    AddPoint(2);
                    teamNext = 2;
                }
                break;
            case GameState.team2:
                teamNext = 1;
                timer2.transform.parent.GetComponent<Image>().color = new Color(.12f, .32f, .12f);
                timer1.transform.parent.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                if (timer2.Increment())
                {
                    gameState = GameState.start;
                    AddPoint(1);
                    teamNext = 1;
                }
                break;
            case GameState.win:
                if (!win.isActiveAndEnabled)
                {
                    if (points[0] > points[1])
                        Win(1);
                    else if (points[1] > points[0])
                        Win(2);
                    else
                        Win(3);
                }
                break;
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("gameScene", LoadSceneMode.Single);
    }

    public void StartTerm()
    {
        start.gameObject.SetActive(false);
        rules.gameObject.SetActive(false);
        next.gameObject.SetActive(true);
        ShowSkip(true);
        termPicker.gameObject.SetActive(true);
        if (teamNext == 1)
        {
            gameState = GameState.team1;
        }
        else
        {
            gameState = GameState.team2;
        }
    }

    void Win(int team)
    {
        main.gameObject.SetActive(false);
        win.transform.parent.gameObject.SetActive(true);
        switch (team)
        {
            case 1:
                win.text = "Team 1 wins!";
                break;
            case 2:
                win.text = "Team 2 wins!";
                break;
            case 3:
                win.text = "Boooo! It's a tie!";
                break;
        }
    }

    public void SwitchTerm()
    {
        if (termPicker.isDone())
        {
            AddPoint(teamNext);
            return;
        }

        if (teamNext == 1)
        {
            gameState = GameState.team1;
        }
        else
        {
            gameState = GameState.team2;
        }
        ShowSkip(true);
        termPicker.ChangeTerm(false);
    }

    void ShowSkip(bool show)
    {
        skip.gameObject.SetActive(show);
    }

    public void Skip()
    {
        termPicker.ChangeTerm(false);
        ShowSkip(false);
    }

    void AddPoint(int team)
    {
        points[team - 1]++;
        if (termPicker.isDone())
        {
            gameState = GameState.win;
            return;
        }

        teamCount1.text = points[0].ToString();
        teamCount2.text = points[1].ToString();

        gameState = GameState.start;

        if (termPicker.ChangeTerm(true))
            gameState = GameState.win;

        start.gameObject.SetActive(true);
        next.gameObject.SetActive(false);
        ShowSkip(false);
        timer1.Restart();
        timer2.Restart();
    }
}
