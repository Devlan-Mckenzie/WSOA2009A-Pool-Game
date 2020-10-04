using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
   public GameObject CueBall;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = CueBall.transform.position;
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
        }

        if (collision.gameObject.tag == "NormalBall")
        {
            Destroy(collision.gameObject);
        }
    }
}
