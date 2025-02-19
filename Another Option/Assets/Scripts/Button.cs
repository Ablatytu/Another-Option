using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Vector2 scale;
    private Vector2 startScale;
    private Vector2 currectscale;

    private void Start()
    {
        startScale = transform.localScale;
        currectscale = startScale;
    }
    private void Update()
    {
        transform.localScale = Vector2.MoveTowards(transform.localScale, currectscale, 2 * Time.deltaTime);
    }
    public void Enter()
    {
        currectscale = scale;
    }
    public void Exit()
    {
        currectscale = startScale;
    }
}
