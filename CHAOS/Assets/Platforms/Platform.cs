using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlatformTypes
{ 
    Basic,
    Spiked,
    Phasing,
    Bouncy
}

public class Platform : MonoBehaviour
{
    private PlatformTypes type = PlatformTypes.Basic;
}
