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

        Debug.Log("*** Welcome to Happy Farm Sim ***");
        Debug.Log($"= There are {animals.Count} animals living in the Happy Farm =");

        foreach (Animal a in animals)
        {
            a.GetStatus();
            a.Feed(10);                  
            a.Feed(a.PreferedFood, 5);   
            a.MakeSound();
            Debug.Log(a.Produce());
        }

        
        Debug.Log("=== Rotten food test ===");
        cow1.Feed(FoodType.RottenFood, 5);

       
        Debug.Log("=== Animal food test ===");
        chicken1.Feed(FoodType.AnimalFood, 5);

        
        Debug.Log("=== Clamp test ===");
        sheep1.Feed(200); 
        sheep1.GetStatus();
    }
}