using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FrameData : MonoBehaviour
{
    [SerializeField] private float startupFrames;
    [SerializeField] private float activeFrames;
    [SerializeField] private float endlagFrames;
    [SerializeField] private int damage;
    public float _startupFrames
    {
        get { return startupFrames; }
    }
    public float _activeFrames
    {
        get { return activeFrames; }
    }
    public float _endlagFrames
    {
        get { return endlagFrames; }
    }
    public int _damage
    {
        get { return damage; }
    }

    private Collider2D collider;

    //also disabling and enabling colliders here, because i'm not gonna make a whole script for that
    private void Awake()
    {
        collider = gameObject.GetComponent<Collider2D>();
        collider.enabled = false;
    }
    public void ColliderActivation()
    {
        if (!collider.enabled)
        {
            collider.enabled = true;
        }
        else
        {
            collider.enabled = false;
        }
    }
}
