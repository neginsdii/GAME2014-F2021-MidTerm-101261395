/*
 * Full Name        : Negin Saeidi
 * Student ID       : 101261395
 * Date Modified    : October 20, 2021
 * File             : EnemyController.cs
 * Description      : This is the Bullet controller script - It controls the motion of the Enemy
 * Version          : V02
 * Revision History : Changed variable names, checkbound function to check with vertical bounds, move function to move verticaly - Added comments to the code
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float VerticalSpeed;
    public float verticalBoundary;
    public float direction;
    /// <summary>
    /// the Update function
    /// calls the move and checkbound functions
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }
    /// <summary>
    /// The move function
    /// changes the postion of the enemy 
    /// </summary>
    private void _Move()
    {
        transform.position += new Vector3(0.0f, VerticalSpeed * direction * Time.deltaTime, 0.0f);
    }
    /// <summary>
    /// The chechBounds function
    /// prevents the enemy going out of the screen
    /// </summary>
    private void _CheckBounds()
    {
        // check right boundary
        if (transform.position.y >= verticalBoundary)
        {
            direction = -1.0f;
        }

        // check left boundary
        if (transform.position.y <= -verticalBoundary)
        {
            direction = 1.0f;
        }
    }
}
