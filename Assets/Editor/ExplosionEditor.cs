using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (Explosion))]
public class ExplosionEditor : Editor
{
    private void OnSceneGUI()
    {
        Explosion explosion = (Explosion)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(explosion.Position, Vector3.up, Vector3.forward, 360, explosion.MaximumExplosionRadius);
        //Handles.SphereHandleCap(0, explosion.Position, explosion.Roation * Quaternion.LookRotation(Vector3.up), explosion.CurrentExplosionRadius * 2, EventType.Repaint);

        Handles.color = Color.red;
        foreach (Transform visibleTarget in explosion.OpenTargets)
        {
            Handles.DrawLine(explosion.Position, visibleTarget.position);
        }
    }
}
