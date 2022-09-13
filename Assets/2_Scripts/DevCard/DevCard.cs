using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDevCard
{
    string cardName {get; set;}
    string cardType {get; set;}

    void MakeCode();

}
