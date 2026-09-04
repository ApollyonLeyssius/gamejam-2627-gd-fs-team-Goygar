using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    private InputSystem_Actions InputActions;
    private PlayerMovement movement;
    public static Action punchAttackstarted;
    public static Action attackDone;
    public enum AttackType
    {
        standing,
        crouching,
        air
    }
    private enum AttackButton
    {
        punch,
        kick
    }
    private InputAction punch;
    private InputAction kick;
    private InputAction crouch;

    private bool isCrouching;

    private Dictionary<AttackType, Collider2D> punchAttacks;
    // enum to easily reference the AttackType, dictionary to attach specific hitboxes to their AttackType
    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        InputActions = new InputSystem_Actions();
        punchAttacks = new Dictionary<AttackType, Collider2D>
        {
            { AttackType.standing, transform.Find("StandingPunch").GetComponent<Collider2D>() }, //the names have to VERY SPECIFICALLY be this or it doesn't work !!!!!!!!!
            { AttackType.crouching, transform.Find("CrouchingPunch").GetComponent<Collider2D>() },
            { AttackType.air, transform.Find("AirPunch").GetComponent<Collider2D>() }
        }; //assigning punchAttacks
        punch = InputActions.Player.Punch;
        kick = InputActions.Player.Kick;
        crouch = InputActions.Player.Crouch;
        StartCoroutine(Test());
    }

    
    void Update()
    {
        if (punch.WasPressedThisFrame())
        {
            DetectState(AttackButton.punch);
        }
        if (kick.WasPressedThisFrame())
        {
            DetectState(AttackButton.kick);
        }
    }
    private void DetectState(AttackButton button)
    {
        if (!movement._isGrounded())
        {
            InitiateAttack(AttackType.air, button);
        }
        else if (crouch.IsPressed())
        {
            InitiateAttack(AttackType.crouching, button);
        }
        else
        {
            InitiateAttack(AttackType.standing, button);
        }
    } //all the checks to see which specific attack should be triggered. irrelevant outside of this script
    private void InitiateAttack(AttackType type, AttackButton button)
    {
        punchAttacks.TryGetValue(type, out var attack);
        StartCoroutine(ExecuteAttack(attack));

    } //mb for the redundancy, i can't find a way to cleanly do this in one function. currently instantiating the attack to send it to a coroutine to execute it over time.
      //!! please use the actions provided above to disable movement inputs during the attack !!
    private IEnumerator ExecuteAttack(Collider2D attack)
    {
        punchAttackstarted?.Invoke(); 
        FrameData framedata = attack.gameObject.GetComponent<FrameData>();
        yield return new WaitForSeconds(framedata._startupFrames/60f);
        framedata.ColliderActivation();
        yield return new WaitForSeconds(framedata._activeFrames/60f);
        framedata.ColliderActivation();
        yield return new WaitForSeconds(framedata._endlagFrames/60f);
        attackDone?.Invoke();
        yield break; //assumes 60 fps no matter what
    }
    private IEnumerator Test()
    {
        yield return new WaitForSeconds(1);
        InitiateAttack(AttackType.standing, AttackButton.punch);
        yield break;
    }
}
