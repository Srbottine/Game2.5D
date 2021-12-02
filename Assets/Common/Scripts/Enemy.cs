using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Common.Scripts
{
    public class Enemy : MonoBehaviour
    {

    #region Constants


    #endregion

    #region Inspector


    [Header("Relations")]
    [SerializeField]
    private Animator animator = null;

    [SerializeField]
    private Rigidbody physicsBody = null;

    [SerializeField]
    private SpriteRenderer spriteRenderer = null;

    #endregion

     #region Fields

    private Vector3 _movement;

    #endregion


    #region MonoBehaviour



    #endregion
    }

}