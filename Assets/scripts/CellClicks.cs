using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class CellClicks : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    public Material Flag;
    public Material Bomb;
    public Material Ground;
    public Material GroundDark;
    
    float time = 300;

    private bool act = false;
    
    void Start()
    {
        act = false;
        time = 300;
    }
    // Update is called once per frame
    void Update()
    {

        if (act==true)
        {
            time -= Time.deltaTime;

            if (time == 0) ;
            {
                SceneManager.LoadScene("Scenes/New Scene");
                //cambias a la escena de gameover

            }

        }
       
        
        if (Input.GetMouseButtonDown(0)){
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (!hit.transform.CompareTag("Flag")&&!hit.transform.CompareTag("BombFlag"))
                {
                    if (hit.transform.CompareTag("Bomb"))
                    {
                        hit.transform.GetComponent<Renderer>().material = Bomb;
                        act = true;
                    }
                    else
                    {
                        hit.transform.tag = "GroundDark";
                        hit.transform.GetComponent<Renderer>().material = GroundDark;
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1)){
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.transform.tag)
                {
                    case "Bomb":
                        hit.transform.tag = "BombFlag";
                        hit.transform.GetComponent<Renderer>().material = Flag;
                        break;
                    case "BombFlag":
                        hit.transform.tag = "Bomb";
                        hit.transform.GetComponent<Renderer>().material = Ground;
                        break;
                    case "Flag":
                        hit.transform.tag = "Ground";
                        hit.transform.GetComponent<Renderer>().material = Ground;
                        break;
                    case "Untagged":
                        hit.transform.tag = "Flag";
                        hit.transform.GetComponent<Renderer>().material = Flag;
                        break;
                    case "Ground":
                        hit.transform.tag = "Flag";
                        hit.transform.GetComponent<Renderer>().material = Flag;
                        break;
                }
            }
        }
    }
}
