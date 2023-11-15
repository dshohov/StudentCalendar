using Models;

namespace StudentCalendar.IRepositories
{
    public interface IGroupRepository
    {
        Task<IQueryable<Group>> GetAll();
        Task<Group> GetGroupById(int idGorup);
    }
}
