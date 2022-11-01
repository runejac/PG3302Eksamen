using A_Team.Core.Model;

namespace A_Team.Core.Interfaces;

public interface IBillRepository : IRepository<Bill> {
    IOrderedEnumerable<Bill> GetSortedByDueDateDescending();
    IEnumerable<Bill> GetSortedByStatus(BillStatusEnum status);
    void UpdateBillStatus(int id, BillStatusEnum newStatus);
}