using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneLogic : MonoBehaviour
{
    private int health = 100;
    private GameEngine engine;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        engine = FindObjectOfType<GameEngine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hitPlane()
    {
        health -= 20;

        Color color = sprite.color;
        color.a *= 0.8f;
        sprite.color = color;

        if (health <= 0)
        {
            Debug.Log("Destroyed Plane!");
            Destroy(gameObject);
            engine.PlaneDestroyed();
        }
    }
}
