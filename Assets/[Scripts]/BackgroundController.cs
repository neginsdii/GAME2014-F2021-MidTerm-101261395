/*
 * Full Name        : Negin Saeidi
 * Student ID       : 101261395
 * Date Modified    : October 20, 2021
 * File             : BackgroundController.cs
 * Description      : This is the Bullet controller script - It makes the background scroll from top to bottom of the screen
 * Version          : V02
 * Revision History : Changed variable names, move function to move horizontly , added comments
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float horizontalSpeed;
    public float horizontalBoundary;
    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }
    /// <summary>
    /// Reset the position of the background object
    /// </summary>
    private void _Reset()
    {
        transform.position = new Vector3(horizontalBoundary, 0.0f);
       
    }
    /// <summary>
    /// Changes the position of the background 
    /// </summary>
    private void _Move()
    {
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
    }
    /// <summary>
    /// Resets the position of the background if it goes out of screen
    /// </summary>
    private void _CheckBounds()
    {
        // if the background is lower than the bottom of the screen then reset
        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
        }
    }
}
