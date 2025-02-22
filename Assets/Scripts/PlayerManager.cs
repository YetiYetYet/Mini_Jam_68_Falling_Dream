﻿using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.InfiniteRunnerEngine;
using UnityEngine;

public class PlayerManager : PlayableCharacter
{ 
    protected override void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player collide with + " + other.gameObject.name);
        if (other.tag.Equals("Props"))
        {
            Debug.Log("I kill this player");
            LevelManager.Instance.KillCharacter(this);
        }
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {

    }
}
