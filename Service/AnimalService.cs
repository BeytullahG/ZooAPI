
class AnimalService : IAnimalService
{
    private readonly ZooDbContext _context;
    public AnimalService(ZooDbContext context)
    {
        _context = context;
    }

    public Animal Create(Animal animal)
    {
        _context.Animals.Add(animal);
        _context.SaveChanges();
        return animal;
    }

    public bool Delete(int Id)
    {
        var animal = _context.Animals.FirstOrDefault(x => x.Id == Id);
        if (animal == null) return false;
        else
        {
            _context.Animals.Remove(animal);
        }
        _context.SaveChanges();
        return true;
    }

    public bool Feed(int Id, int food)
    {
        var animal = _context.Animals.FirstOrDefault(x => x.Id == Id);
        if (animal == null) return false;
        else if(animal.Energy + food <= 100)
        {
            animal.Energy += food;
        }
        else animal.Energy = 100;
        _context.SaveChanges();
        return true;
    }

    public List<Animal> GetAll()
    {
        return _context.Animals.ToList();
    }

    public Animal? GetById(int Id)
    {
        return _context.Animals.FirstOrDefault(x => x.Id == Id);
    }
}