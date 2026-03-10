
class AnimalService : IAnimalService
{
    private List<Animal> animals = new List<Animal>();
    public Animal Create(Animal animal)
    {
        animal.Id = animals.Count + 1;
        animals.Add(animal);
        return animal;
    }

    public bool Delete(int Id)
    {
        var animal = animals.FirstOrDefault(x => x.Id == Id);
        if (animal == null) return false;
        else
        {
            animals.Remove(animal);
        }
        return true;
    }

    public bool Feed(int Id, int food)
    {
        var animal = animals.FirstOrDefault(x => x.Id == Id);
        if (animal == null) return false;
        else if(animal.Energy + food <= 100)
        {
            animal.Energy += food;
        }
        else animal.Energy = 100;
        return true;
    }

    public List<Animal> GetAll()
    {
        return animals;
    }

    public Animal? GetById(int Id)
    {
        return animals.FirstOrDefault(x => x.Id == Id);
    }
}