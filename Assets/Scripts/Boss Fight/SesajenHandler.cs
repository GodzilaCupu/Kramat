using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enum_SesajenState
{
    utuh,
    setengah,
    hancur,
}

public class SesajenHandler : MonoBehaviour
{
    [SerializeField] private BossFightManager manager;
    [SerializeField] private int id;
    [SerializeField] private int damageTaken;
    [SerializeField] private int damageMax = 2;
    public bool isDone;

    [SerializeField] private List<GameObject> sesajenType;

    public int ID { get { return id; } }

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<BossFightManager>();
        GetSesajenType();
        isDone = false;
        EventsManager.current.onAttackTrigger += CheckSesajen;
    }

    private void OnDisable()
    {
        EventsManager.current.onAttackTrigger -= CheckSesajen;

    }

    private void Update()
    {
        SetType(damageTaken);   
        
    }

    private void GetSesajenType()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
            sesajenType.Add(gameObject.transform.GetChild(i).gameObject);

        SetType(damageTaken);
    }

    private void SetType(int state)
    {
        if (isDone) return;
        sesajenType[state].SetActive(true);
    }

    private void CheckSesajen(GameObject item)
    {
        if (id != item.GetComponent<SesajenHandler>().ID)
            return;

        if (damageTaken == damageMax)
        {
            isDone = true;
            manager.sesajenCurrentProgres = isDone ? +1 : +0;
            return;
        }
        damageTaken++;
    }
}
