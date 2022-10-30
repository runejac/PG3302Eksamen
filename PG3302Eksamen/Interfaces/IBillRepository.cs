using A_Team.Core.Model;

namespace A_Team.Core.Interfaces;

public interface IBillRepository : IRepository<Bill> {
    IOrderedEnumerable<Bill> GetSortedByDueDateDescending();
    List<Bill> GetSortedByStatus();
}