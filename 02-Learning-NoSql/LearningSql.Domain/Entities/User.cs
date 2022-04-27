
namespace LearningSql.Domain.Entities;

public class User : Base
{
    public User()
    {
        this.CreatedAt = DateTime.Now;
    }
    
    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime CreatedAt { get; private set; }
}