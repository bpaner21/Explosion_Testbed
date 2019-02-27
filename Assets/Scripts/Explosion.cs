using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Tooltip("The current radius of the explosion")]
    [SerializeField]
    private float currentExplosionRadius = 0.0f;

    [Tooltip("The maximum radius of the explosion")]
    [SerializeField]
    private float maximumExplosionRadius = 0.5f;
    
    [Tooltip("The rate that the explosion grows over time")]
    [SerializeField]
    [Range(0.000f, 0.050f)]
    private float explosionRateOfGrowth = 0.0f;

    [Tooltip("The object that determines the origin of the explosion")]
    [SerializeField]
    private GameObject origin;

    // The position of the origin object in global world space
    private Vector3 originPosition;

    // Bool checking if explosion is occuring
    private bool isExploding = false;

    // The scalar that affects the radius of the explosion
    private float explosionScalar = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.origin = this.gameObject;
        originPosition = origin.transform.position;
        currentExplosionRadius = 0.0f;
        explosionScalar = 0.0f;
        maximumExplosionRadius = AbsoluteValue(maximumExplosionRadius);
        isExploding = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isExploding && currentExplosionRadius <= maximumExplosionRadius)
        {
            explosionScalar += explosionRateOfGrowth;
            Debug.Log("Exploding");
        }
        else
        {
            explosionScalar = 0.0f;
            Debug.Log("Reseting");
        }

        Detonate();
        Debug.Log("Current Explosion Radius: " + currentExplosionRadius);
    }

    private void Detonate()
    {
        currentExplosionRadius = maximumExplosionRadius * explosionScalar;
    }

    private float AbsoluteValue(float value)
    {
        if (value < 0)
        {
            value *= -1.0f;
        }

        return value;
    }
    
    // Getters/ Setters
    public float CurrentExplosionRadius
    {
        get { return this.currentExplosionRadius; }
    }

    public float MaximumExplosionRadius
    {
        get { return this.maximumExplosionRadius; }
    }

    public Vector3 Position
    {
        get { return this.transform.position; }
    }

    public Quaternion Roation
    {
        get { return this.transform.rotation; }
    }

    // Gizmos
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(originPosition, currentExplosionRadius);
    }
}
