using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHealth : MonoBehaviour
{
    public float NPCHealthPoint = 90;
    public NPCDead deadScript;
    // ������� ���������� ���� ��� ������������� � ���� ������� � ����� "Hands"
    // ����� ������� �� ������� "NPCDead" � ������������� �
    
    private void OnTriggerEnter(Collider other)
    {
        
        deadScript.EmenyDead(other.gameObject);
    }
}
