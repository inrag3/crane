using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    [SerializeField] int MaxHeight = 0;
    [SerializeField] int MinHeight = -5;
    [SerializeField] float LerpValue = 2f;
    private Vector3 Offset = new Vector3(0, 3, 0);
    private Transform ShipTransform;
    private bool GoingUp = false;

    void Awake()
    {
        //TODO тут что-то страшное
        Application.targetFrameRate = 30;
    }

    // Start is called before the first frame update
    void Start()
    {
        ShipTransform = GameObject.Find("Ship").GetComponent<Transform>();
        transform.position = (ShipTransform.position - Offset);
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if (GoingUp)
            GoUp(new Vector3(0, Random.Range(MinHeight, MaxHeight), 0));
        else
            GoDown(new Vector3(0, MinHeight, 0));
    }

    //Двигаемся к рандомной высоте
    void GoUp(Vector3 target)
    {
        if (Vector3.Distance(transform.position, target) > 0.05f) 
        {
            transform.position = Vector3.Lerp(transform.position, target, LerpValue * Time.fixedDeltaTime);
            ShipTransform.position = Vector3.Lerp(ShipTransform.position, target + Offset, LerpValue * Time.fixedDeltaTime);
        }
        else
            GoingUp = false;
    }

    //Двигаемся к MinHeight
    void GoDown(Vector3 target)
    {
        if (Vector3.Distance(transform.position, target) > 0.05f) 
        {
            transform.position = Vector3.Lerp(transform.position, target, LerpValue * Time.fixedDeltaTime);
            ShipTransform.position = Vector3.Lerp(ShipTransform.position, target + Offset, LerpValue * Time.fixedDeltaTime);
        }
        else
            GoingUp = true;
    }
}
