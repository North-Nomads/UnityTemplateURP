namespace _Project.Models
{
    public class UserModel
    {
        public int Money { get; private set; }

        public UserModel()
        {
            Money = 10;
        }
        
        public void Add(int amount)
            => Money += amount;
        
        public void Remove(int amount)
            => Money -= amount;
    }
}