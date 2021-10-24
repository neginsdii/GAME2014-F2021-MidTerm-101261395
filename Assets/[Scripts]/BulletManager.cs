/*
 * Full Name        : Negin Saeidi
 * Student ID       : 101261395
 * Date Modified    : October 20, 2021
 * File             : BulletManager.cs
 * Description      : This is the Bullet manager script - Controls the bullet in the game
 * Version          : V02
 * Revision History : Added header and comments
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public BulletFactory bulletFactory;
    public int MaxBullets;

    private Queue<GameObject> m_bulletPool;


    // Start is called before the first frame update
    void Start()
    {
        _BuildBulletPool();
    }
    /// <summary>
    /// The buildBulletPool Function
    /// creating a queue for bullets
    /// Adding bullets to the queue
    /// </summary>
    private void _BuildBulletPool()
    {
        // create empty Queue structure
        m_bulletPool = new Queue<GameObject>();

        for (int count = 0; count < MaxBullets; count++)
        {
            var tempBullet = bulletFactory.createBullet();
            m_bulletPool.Enqueue(tempBullet);
        }
    }
    /// <summary>
    /// Get an inactive bullet from the queue
    /// Activates the bullet and set the position of the bullet to the given position 
    /// </summary>
    /// <param name="position">The spawnPosition of the bullet passed in PlayerController class </param>
    /// <returns>the bullet</returns>
    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = m_bulletPool.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }
    /// <summary>
    /// Checks if there is a bullet in the queue
    /// </summary>
    /// <returns> true if the queue has bullets </returns>
    public bool HasBullets()
    {
        return m_bulletPool.Count > 0;
    }
    /// <summary>
    /// Adds the bullet to the queue
    /// </summary>
    /// <param name="returnedBullet"> The bullet that is inactive</param>

    public void ReturnBullet(GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        m_bulletPool.Enqueue(returnedBullet);
    }
}
