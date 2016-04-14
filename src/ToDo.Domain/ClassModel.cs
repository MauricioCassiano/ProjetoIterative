
namespace ToDo.Domain
{
    public interface IClassModel
    {
        int Id { get; set; }
    }

    public abstract class ClassModel : IClassModel
    {
        public int Id { get; set; }
    }
}
