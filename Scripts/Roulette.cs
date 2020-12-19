using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public static class Roulette
{
    /// <summary>
    /// <para>Принимает в аргументы массив шансов. Возвращает индекс элемента, который выпал. </para>
    /// </summary>
    public static int GetRoulette(double[] chances)
    {
        double total = 0;
        foreach (var element in chances)
        {
            total = total + element;
        }
        double chance = Random.Range(0, 100) + 1;
        double current = 0;
        for (int index = 0; index < chances.Length; index++)
        {
            var pair = chances[index];
            current = current + pair / total * 100;
            if (chance <= current)
            {
                return index;
            }
        }
        return 0;
    }

}
