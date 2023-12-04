using System.Collections.Generic;
using UnityEngine;
using Reflex.Core;

public class Greeter : IStartable
{
    public Greeter(IEnumerable<string> strings)
    {
        Debug.Log(string.Join(" ", strings));
    }
    
    public void Start()
    {
        
    }
}
