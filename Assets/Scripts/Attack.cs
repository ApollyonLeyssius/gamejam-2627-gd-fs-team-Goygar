using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public enum AttackType
    {
        standing,
        crouching,
        air
    }
    private Dictionary<AttackType, Collider2D> attacks;
    // enum to easily reference the AttackType, dictionary to attach specific hitboxes to their AttackType
    private void Awake()
    {
        attacks = new Dictionary<AttackType, Collider2D>
        {
            { AttackType.standing, transform.Find("StandingPunch").GetComponent<Collider2D>() },
            { AttackType.crouching, transform.Find("CrouchingPunch").GetComponent<Collider2D>() },
            { AttackType.air, transform.Find("AirPunch").GetComponent<Collider2D>() }
        }; //assigning attacks
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
