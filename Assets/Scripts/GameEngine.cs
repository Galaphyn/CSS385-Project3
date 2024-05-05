using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
    public int maxPlanes = 10;
    private int numPlanes = 0;
    private int planeDestroyed = 0;
    private int numberEggs = 0;
    public bool mouseMode = true;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Quit Game
        if (Input.GetKey(KeyCode.Q))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        //

        //Text Editor
        text.text = "Planes Destroyed: " + planeDestroyed + " || Hero Mode: " + (mouseMode ? "Mouse" : "Keyboard") + " || Number of Eggs: " + numberEggs + " || Number of Planes: " + numPlanes; 

        //Plane Spawner
        if (numPlanes < maxPlanes)
        {
            float camHeight = Camera.main.orthographicSize;
            float camWidth = Camera.main.aspect * camHeight;

            GameObject newPlane = Instantiate(Resources.Load("Prefabs/Plane") as GameObject);   
            Vector2 spawnPosition = new Vector2(Random.Range(-camWidth, camWidth), Random.Range(-camHeight, camHeight));

            newPlane.transform.position = spawnPosition;
            numPlanes++;
        }
        //
    }
    public void PlaneDestroyed()
    {
        numPlanes--;
        planeDestroyed++;
    }

    public void NewEgg()
    {
        numberEggs++;
    }

    public void BadEgg()
    {
        numberEggs--;
    }


}
