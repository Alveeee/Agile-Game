using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TermPicker : MonoBehaviour
{

    List<string> terms = new List<string>() {
        "Agile",
        "Scrum",
        "Scrum-master",
        "Sprint",
        "Leader role",
        "Motivator role",
        "Product owner",
        "Stand-up",
        "Kanban",
        "Sprint Backlog",
        "Task Board",
        "User stories",
        "Agile Team",
        "Refactoring",
        "Quick Design Session",
        "Product Backlog",
        "User Personas",
        "Epic",
        "Kanban Board",
        "Persona",
        "Sprint backlog",
        "Task Board",
        "Sprint planning",
        "Planning Poker",
        "Daily Meeting",
        "Iteration Review",
        "Hard Skills",
        "Soft Skills",
        "Tasks",
        "Self-Organizing teams",
        "12 Principles of agile",
        "Four Core Values of Agile",
        "Team Members",
        "Extreme programming",
        "Crystal",
        "Lean",
        "Feature driven development",
        "Test driven development",
        "Acceptance criteria",
        "Backlog grooming",
        "Burndown/burnup chart", };
    List<string> used = new List<string>();

    public Text termText;

    public bool ChangeTerm(bool hide)
    {
        bool finished = true;
        while (finished)
        {
            if (terms.Count - used.Count <= 2)
                break;

            int rand = Random.Range(0, terms.Count);
            string term = terms[rand];
            Debug.Log(terms.Count - used.Count);
            if (!used.Contains(term))
            {
                used.Add(term);
                termText.text = term;
                termText.gameObject.SetActive(!hide);
                finished = false;
            }
        }
        return finished;
    }

    public bool isDone()
    {
        if (terms.Count - used.Count <= 2)
            return true;
        else
            return false;
    }
}
