using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public Cow cow1;
    public Chicken chicken1;
    public Sheep sheep1;
    public List<Animal> animals = new List<Animal>();

    void Start()
    {
        cow1.Init("Miltank");
        chicken1.Init("Torchic");
        sheep1.Init("Mareep");

        animals.Add(cow1);
        animals.Add(chicken1);
        animals.Add(sheep1);

        foreach (Animal a in animals)
        {
            a.GetStatus();
            a.Feed(10);                  
            a.Feed(a.PreferedFood, 5);   
            a.MakeSound();
            Debug.Log(a.Produce());      
        }

       
        cow1.Feed(FoodType.RottenFood, 5);
    }
}
