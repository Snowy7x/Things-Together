using System;
using System.Collections.Generic;
using UnityEngine;

public enum HeartStatus
{
    Full,
    Half,
    Empty
}

[Serializable]public struct Heart
{
    public HeartStatus state;
}

public class Health : MonoBehaviour
{
    public List<Heart> hearts;

    public int GetRemainingHearts()
    {
        int healthPerHeart = PlayerHealth.maxHealth / hearts.Count;
        int remainingHearts = PlayerHealth.currentHealth / healthPerHeart;
        
        return remainingHearts;
    }

    public void DrawHearts()
    {
        int remainingHearts = GetRemainingHearts();
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < remainingHearts)
            {
                hearts[i].SetHeartImage(HeartStatus.Full);
            }
            if (i == remainingHearts)
            {
                if (PlayerHealth.currentHealth % (PlayerHealth.maxHealth / hearts.Count) == 0)
                {
                    heart.SetHeartImage(HeartStatus.Empty);
                }
                else
                {
                    heart.SetHeartImage(HeartStatus.Half);
                }
            }
            else
            {
                heart.SetHeartImage(HeartStatus.Empty);
            }
        }
    }
}