using System;
using System.Collections;
using System.Collections.Generic;
using Unisave;
using Unisave.Entities;
using Unisave.Facades;
using UnityEngine;

/*
 * This entity represents a player of your game. To learn how to add
 * player registration and authentication, check out the documentation:
 * https://unisave.cloud/docs/authentication
 *
 * If you don't need to register players, remove this class.
 */

public class PlayerEntity : Entity
{
    public string playerToken;
    public DateTime lastLoginAt = DateTime.UtcNow;
    public DateTime lastSeenAt;
    [Fillable] public int startingHealth;
    [Fillable] public int currentHealth;
    [Fillable] public string equippedOrbType;
    [Fillable] public int equippedOrbIndex;
    [Fillable] public int savedSceneIndex;
    [Fillable] public List<string> startingAvailableOrbs = new List<string>();
    [Fillable] public string startingEquippedOrbType;
}
