using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinkingBalls : MonoBehaviour
{
    public GameObject CueBall;
    public Text score;
    int Points;
    Vector3 startPos;
    public GameManagment_Script gamemanager;
    // Start is called before the first frame update
    void Start()
    {       
        startPos = CueBall.transform.position;

        GameObject gameManagerObject = GameObject.FindWithTag("GameController");
        if (gameManagerObject != null)
        {
            gamemanager = gameManagerObject.GetComponent<GameManagment_Script>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CueBall")
        {
            CueBall.transform.position = startPos;
            CueBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
            CueBall.GetComponent<Rigidbody>().rotation = Quaternion.identity;      
            gamemanager.AddScore(-15);
        }

        if (collision.gameObject.tag == "NormalBall")
        {
            Destroy(collision.gameObject);
            gamemanager.AddScore(5);            
        }
    }
}

