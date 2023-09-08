using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInjuredBehavior : MonoBehaviour
{
    [SerializeField] private Material[] materials = new Material[2];
    private Renderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<Renderer>();
    }

    public void Injured()
    {
        meshRenderer.material = materials[1];
        Invoke("EndInjured", 0.1f);
    }

    public void EndInjured()
    {
        meshRenderer.material = materials[0];
    }
}
