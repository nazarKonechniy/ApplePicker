using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreGT;
    public float maxSpeed = 170f;
    public float minSeconds = 0.097f;
    public float maxChance = 27f;


    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
        HighScore.lastScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.tag == "Apple")
        {
            Destroy(gameObject);
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();
            if (score > HighScore.score)
                HighScore.score = score;
            HighScore.lastScore = score;

            //if (AppleTree.speed < maxSpeed)
            //{
            //    AppleTree.speed *= 1.3f;
            //}

            //if (AppleTree.secondsBetweenAppleDrops > minSeconds)
            //    AppleTree.secondsBetweenAppleDrops *= 0.89f;

            //if (AppleTree.chanceToChangeDirections < maxChance)
            //    AppleTree.chanceToChangeDirections *= 1.09f;
        }
    }
}