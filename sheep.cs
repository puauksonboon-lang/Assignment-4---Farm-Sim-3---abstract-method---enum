using UnityEngine;


public class Sheep : Animal
{
    public int Wool { get; private set; }

    public override void Init(string newName, FoodType fav = FoodType.GrepaBerry)
    {
        base.Init(newName, fav);
        Wool = 0;
    }

    public override void MakeSound()
    {
        AdjustHappiness(+2);
        Debug.Log($"{Name} Baa! Baa! (Happiness:{Happiness})");
    }

    
    public override string Produce()
    {
        int produced = 0;
        if (Happiness >= 60) { Wool += 1; produced = 1; }
        return $"{Name} produced {produced} wool. Total wool: {Wool}";
    }
}