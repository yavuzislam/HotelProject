﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete;

public class SubscribeManager : ISubscribeService
{
    private readonly ISubscribeDal _subscribeDal;

    public SubscribeManager(ISubscribeDal subscribeDal)
    {
        _subscribeDal = subscribeDal;
    }

    public int TGetSubscribeCount()
    {
        return _subscribeDal.GetSubscribeCount();
    }

    public void TDelete(Subscribe t)
    {
        _subscribeDal.Delete(t);
    }

    public Subscribe TGetByID(int id)
    {
        return _subscribeDal.GetByID(id);
    }

    public List<Subscribe> TGetList()
    {
        return _subscribeDal.GetList();
    }

    public void TInsert(Subscribe t)
    {
        _subscribeDal.Insert(t);
    }

    public void TUpdate(Subscribe t)
    {
        _subscribeDal.Update(t);
    }
}
