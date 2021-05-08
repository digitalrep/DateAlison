using UnityEngine;

public class Balloon
{
    private GameObject balloon;
    private Color color;
    private float x;
    private float y;
    private string text;

    public Balloon(GameObject balloon, Color color, float x, float y, string text)
    {
        this.balloon = balloon;
        this.color = color;
        this.x = x;
        this.y = y;
        this.text = text;
    }

    public GameObject get_balloon()
    {
        return this.balloon;
    }

    public string get_text()
    {
        return this.text;
    }
}
