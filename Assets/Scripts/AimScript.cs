using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    LineRenderer line;
    public GameObject cueBall;
    
    // Start is called before the first frame update
    void Start()
    {
        line = FindObjectOfType<LineRenderer>();        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var direction = Vector3.zero;

        if (Physics.Raycast(ray,out hit))
        {
            var ballPos = new Vector3(cueBall.transform.position.x, 0.1f, cueBall.transform.position.z);
            var mousePos = new Vector3(hit.point.x, 0.1f, hit.point.z);
            line.SetPosition(0, mousePos);
            line.SetPosition(1, ballPos);
            direction = (mousePos - ballPos).normalized;
        }

        if (Input.GetMouseButtonDown(0) && line.gameObject.activeSelf)
        {
            line.gameObject.SetActive(false);
            cueBall.GetComponent<Rigidbody>().velocity = direction * 25f;
        }

        if (!line.gameObject.activeSelf && cueBall.GetComponent<Rigidbody>().velocity.magnitude < 0.3f)
        {
            line.gameObject.SetActive(true);
        }
        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }
}
