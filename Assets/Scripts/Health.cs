using System.Collections.Generic;
using UnityEngine;
using static Health;

public class Health : MonoBehaviour
{
    public enum Attacktype
    {
        standing,
        crouching,
        air
    }
    private Dictionary<Attacktype, Collider2D> attacks; 
    // enum to easily reference the Attacktype, dictionary to attach specific hitboxes to their Attacktype
    private void Awake()
    {
        hitboxes = new Dictionary<AttackType, Collider2D>
        {
            { Attacktype.standing, transform.Find("") }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
