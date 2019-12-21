using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameScript : MonoBehaviour
{

    private Sprite sprite;
    private Canvas canvas;

    Text scoreText;
    // Use this for initialization
    void Start()
    {
        canvas = GetComponent<Canvas>();
        GameObject ScoreTextObject = CreateText("得点");
        scoreText = ScoreTextObject.GetComponent<Text>();

        RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
        Debug.Log(canvasRectTransform.sizeDelta);
        RectTransform scoreTextRectTransform = scoreText.GetComponent<RectTransform>();
        scoreTextRectTransform.sizeDelta = new Vector2(300, 300);
        scoreTextRectTransform.localPosition = new Vector3(
            -canvasRectTransform.sizeDelta.x/2 + 152,
            canvasRectTransform.sizeDelta.y/2 - 152,
            0
        );
        Debug.Log(scoreTextRectTransform.position);
    }

    private int score = 100;
    // Update is called once per frame
    void Update()
    {
        score += 10;
        scoreText.text = "得点:" + score;
    }

    private GameObject CreateText(string text)
    {
        GameObject ScoreTextObject = new GameObject("ScoreText");
        ScoreTextObject.AddComponent<Text>();
        ScoreTextObject.transform.parent = canvas.transform;
        Text scoreText = ScoreTextObject.GetComponent<Text>();
        scoreText.text = text;
        scoreText.fontSize = 70;
        ScoreTextObject.transform.localScale = Vector3.one;
        Font font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        scoreText.font = font;
        scoreText.fontSize = 70;
        scoreText.color = Color.black;
        return ScoreTextObject;
    }
}