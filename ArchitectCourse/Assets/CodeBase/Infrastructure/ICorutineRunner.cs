﻿using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastructure {
    public interface ICorutineRunner {
        Coroutine StartCoroutine(IEnumerator corutine);
    }
}