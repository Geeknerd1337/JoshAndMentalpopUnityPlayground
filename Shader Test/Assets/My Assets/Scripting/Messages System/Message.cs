﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Message{

    [TextArea(3,10)]
    public string[] text;
    
	public Message(string[] s)
    {
        s = text;
    }
}