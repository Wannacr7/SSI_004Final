using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Trayectory : MonoBehaviour
{
    public static Trayectory instance;
    [SerializeField] private GameObject proyectil;
    private LineRenderer dirVector;
    private Vector2 head, origin;

    public Action On_Get_Bullet;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        dirVector = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirVector();
        if (Input.GetMouseButtonDown(0))
        {
            On_Get_Bullet?.Invoke();
            InstanciateProyectil();
        }
    }
    private void UpdateDirVector()
    {
        head = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        dirVector.SetPosition(0, origin);
        dirVector.SetPosition(1, head);
    }
    private void InstanciateProyectil()
    {
        GameObject temp = Instantiate(proyectil);
        temp.transform.position = origin;
        temp.transform.rotation = Quaternion.identity;
        temp.GetComponent<BulletVelocity>().velocity = CalculeteDirVector();
    }
    public Vector2 CalculeteDirVector()
    {
        head = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        origin = this.transform.position;
        return head - origin;
    }
}
