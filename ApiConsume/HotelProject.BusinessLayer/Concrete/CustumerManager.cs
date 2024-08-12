using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete;

public class CustumerManager : ICustomerService
{
    private readonly ICustomerDal _customerDal;

    public CustumerManager(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }

    public void TDelete(Customer t)
    {
        _customerDal.Delete(t);
    }

    public Customer TGetByID(int id)
    {
        return _customerDal.GetByID(id);
    }

    public List<Customer> TGetList()
    {
        return _customerDal.GetList();
    }

    public void TInsert(Customer t)
    {
        _customerDal.Insert(t);
    }

    public void TUpdate(Customer t)
    {
        _customerDal.Update(t);
    }
}
