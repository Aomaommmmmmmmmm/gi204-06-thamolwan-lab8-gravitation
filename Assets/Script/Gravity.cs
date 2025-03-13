using System;
using System.Collections.Generic;
using UnityEngine;


public class Gravity : MonoBehaviour
{
  private Rigidbody rb;

  private const float G = 0.006674f;
  public static List<Gravity> gravityObectlist;
  [SerializeField] private int orbitSpeed = 1000;
  [SerializeField] private bool planets = false ;
  
  private void FixedUpdate()
  {
    foreach (var obj in gravityObectlist)
    {
      attract(obj);
    }
  }

  void attract(Gravity other)
  {
    Rigidbody otherrb = other.rb;
    Vector3 direction = rb.position - otherrb.position;
    float distance = direction.magnitude;

    float forceMagnitude = G * (rb.mass * otherrb.mass/Mathf.Pow( distance,2));
    Vector3 gravityForce = forceMagnitude * direction.normalized;
    
    otherrb.AddForce(gravityForce);
  }

  private void Awake()
  
  {
    rb = GetComponent<Rigidbody>();
    if (gravityObectlist== null) 
     
    {
       gravityObectlist = new List<Gravity>();
    }
    gravityObectlist.Add(this);
    
    if (!planets)
    {
      rb.AddForce(Vector3.right * orbitSpeed);
    }
      
    
      
    }
   

  }

