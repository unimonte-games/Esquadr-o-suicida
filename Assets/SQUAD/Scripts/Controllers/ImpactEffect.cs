using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    public Animator Anin;
    int Imp;

    public void Impact(float t, int impact)
    {
        Imp = impact;
        Invoke("Effect", t);
    }

    void Effect()
    {
        if(Imp == 0)
        {
            Anin.SetTrigger("Impact1");
        }

        if (Imp == 1)
        {
            Anin.SetTrigger("Impact2");
        }

        if (Imp == 2)
        {
            Anin.SetTrigger("Impact3");
        }


    }



}
