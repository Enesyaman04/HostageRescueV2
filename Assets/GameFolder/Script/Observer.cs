﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Observer
{
    public static UnityEvent<string> OnFinishEvent = new UnityEvent<string>();
}
