using PG3302Eksamen.Model;

namespace PG3302Eksamen.Interfaces;

public interface IBillRepository : IRepository<Bill> {
    IOrderedEnumerable<Bill> GetSortedByDueDateDescending();
    IEnumerable<Bill> GetSortedByStatus(BillStatusEnum status);
    void UpdateBillStatus(int id, BillStatusEnum newStatus);
}