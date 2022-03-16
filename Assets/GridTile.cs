using UnityEngine;

public class GridTile : MonoBehaviour
{
    // Start is called before the first frame update
    public GridTile[] next = { null, null, null, null };
    public int value = 0;
    private Material mat;
    private Color color;
    void Start()
    {
        value = 1;
        mat = gameObject.GetComponent<Renderer>().material;
        color = (value == 0) ? Color.white : Color.HSVToRGB((float)value / 20f, 1f, 1f);
        mat.SetColor("_Color", color);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Carry(int dir)
    {
        if (next[dir] == null)
        {
            UpdateColor(1 ^ dir);
        }
        else if (value == 0)
        {
            next[dir].Carry(dir);
        }
        else if (next[dir].value == 0)
        {
            next[dir].value = value;
            value = 0;
            if (next[1 ^ dir] != null)
            {
                next[1 ^ dir].Carry(dir);
            }
            else
            {
                next[dir].Carry(dir);
            }
        }
        else if (next[dir].value == value)
        {
            next[dir].value++;
            value = 0;
            if (next[1 ^ dir] != null)
            {
                next[1 ^ dir].Carry(dir);
            }
            else
            {
                next[dir].Carry(dir);
            }
        }
        else
        {
            next[dir].Carry(dir);
        }

    }
    public void MoveOnly(int dir)
    {
        if (next[dir] == null)
        {
        }
        else if (value == 0)
        {
            next[dir].Carry(dir);
        }
        else if (next[dir].value == 0)
        {
            next[dir].value = value;
            value = 0;
            if (next[1 ^ dir] != null)
            {
                next[1 ^ dir].Carry(dir);
            }
            else
            {
                next[dir].Carry(dir);
            }
        }
        else
        {
            next[dir].Carry(dir);
        }

    }

    // do this later put a merge feature function


    private void UpdateColor(int dir)
    {
        color = (value == 0) ? Color.white : Color.HSVToRGB((float) value / 20f, 1f, 1f);
        mat.SetColor("_Color", color);
        if (next[dir] == null) return;
        next[dir].UpdateColor(dir);
    }

}
