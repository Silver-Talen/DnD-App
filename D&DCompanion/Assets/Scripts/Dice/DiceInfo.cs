using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceInfo : MonoBehaviour
{
    [SerializeField] GameObject[] m_facePositions;

    GameObject m_die;

    Vector3 m_pastPosition = new Vector3(0.0f, 0.0f, 0.0f);

    private void Start()
    {
        m_die = this.gameObject;
    }

    public bool IsRolling()
    {
        bool isRolling;
        if (m_pastPosition - m_die.transform.position == new Vector3(0.0f, 0.0f, 0.0f))
        {
            isRolling = false;
        }
        else
        {
            isRolling = true;
        }

        m_pastPosition = m_die.transform.position;

        return isRolling;
    }

    public int GetTopFace()
    {
        GameObject topGO = m_facePositions[0];
        topGO.transform.position.Set(0.0f, float.MinValue, 0.0f);
        foreach (GameObject go in m_facePositions)
        {
            if (go.transform.position.y > topGO.transform.position.y) topGO = go;
        }

        int face = int.Parse(topGO.name.Remove(0, 4));

        return face;
    }
}
