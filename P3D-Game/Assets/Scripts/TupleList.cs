﻿using System;
using System.Collections.Generic;

public class TupleList<T1, T2> : List<KeyValuePair<T1, T2>> where T1 : IComparable
{
    public void Add(T1 item, T2 item2)
    {
        Add(new KeyValuePair<T1, T2>(item, item2));
    }

    public new void Sort()
    {
        Comparison<KeyValuePair<T1, T2>> c = (a, b) => a.Key.CompareTo(b.Key);
        base.Sort(c);
    }

    public void SortDescending()
    {
        Comparison<KeyValuePair<T1, T2>> c = (a, b) => b.Key.CompareTo(a.Key);
        base.Sort(c);
    }

}