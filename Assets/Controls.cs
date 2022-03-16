using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            timer += 1f;
            foreach(GridTile tile in GameObject.FindObjectsOfType<GridTile>())
            {
                if (tile.next[0] == null) tile.Carry(1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            timer += 1f;
            foreach (GridTile tile in GameObject.FindObjectsOfType<GridTile>())
            {
                if (tile.next[1] == null) tile.Carry(0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            timer += 1f;
            foreach (GridTile tile in GameObject.FindObjectsOfType<GridTile>())
            {
                if (tile.next[2] == null) tile.Carry(3);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            timer += 1f;
            foreach (GridTile tile in GameObject.FindObjectsOfType<GridTile>())
            {
                if (tile.next[3] == null) tile.Carry(2);
            }
        }
    }
}
