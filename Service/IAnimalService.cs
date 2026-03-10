public interface IAnimalService
{
    public List<Animal> GetAll();
    public Animal? GetById(int Id);
    public Animal Create(Animal animal);
    public bool Feed(int Id, int food);
    public bool Delete(int Id);
}