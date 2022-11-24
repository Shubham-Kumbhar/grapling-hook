using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapling : MonoBehaviour
{
    [SerializeField] private LineRenderer Rope;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform Graplinghook, handPosition, player, graplingHookEndPoint;
    [SerializeField] private LayerMask graplinglayer;
    [SerializeField] private float maxgraplingdistance,graplingHookSpeed = 0f,playerElasticDist=0.5f;
    [SerializeField] private Vector3 graplingPlayeOffset;
    bool isgrapling, isShooting;
    private Vector3 hookpoint;
    private void Start()
    {
        isgrapling = false;
        isShooting = false;
        Rope.enabled = false;
    }
    private void LateUpdate()
    {
        if (Rope.enabled)
        {
            Rope.SetPosition(0, handPosition.position);
            Rope.SetPosition(1, graplingHookEndPoint.position);
            
        }
    }
    private void Update()
    {
        if (Graplinghook.parent == handPosition)
        {
            Graplinghook.localPosition = Vector3.Lerp(Graplinghook.localPosition,new Vector3 (0f, 0f, 1f), 100f);
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            shoothook();
        }
        if (isgrapling)
        {
            grapling_();
        }
        
    }

    private void shoothook()
    {
        if (isShooting || isgrapling) return;


        isShooting = true;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit, maxgraplingdistance,graplinglayer))
        {
            hookpoint = hit.point;
            isgrapling = true;
            Graplinghook.parent = null;
            Graplinghook.LookAt(hookpoint);
            Rope.enabled = true;
        }


        isShooting = false;

    }
    private void grapling_()
    {
        Graplinghook.position = Vector3.Lerp(Graplinghook.position, hookpoint, graplingHookSpeed * Time.deltaTime);
        if (Vector3.Distance(Graplinghook.position, hookpoint) < 0.1f)
        {
            controller.enabled = false;
            player.position = Vector3.Lerp(player.position, hookpoint, graplingHookSpeed * Time.deltaTime);
            if (Vector3.Distance(player.position, hookpoint) < playerElasticDist)
            {
                controller.enabled = true;
                print("character controiller is enabled");
                Graplinghook.SetParent(handPosition);
                isgrapling = false;
                Rope.enabled = false;
            }


        }
    }
}
