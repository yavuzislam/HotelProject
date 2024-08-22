﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete;

public class WorkLocationManager : IWorkLocationService
{
    private readonly IWorkLocationDal _workLocationDal;

    public WorkLocationManager(IWorkLocationDal workLocationDal)
    {
        _workLocationDal = workLocationDal;
    }

    //public List<WorkLocation> TGetWorkLocationsWithAppUsers()
    //{
    //    return _workLocationDal.GetWorkLocationsWithAppUsers();
    //}

    public void TDelete(WorkLocation t)
    {
        _workLocationDal.Delete(t);
    }

    public WorkLocation TGetByID(int id)
    {
        return _workLocationDal.GetByID(id);
    }

    public List<WorkLocation> TGetList()
    {
        return _workLocationDal.GetList();
    }

    public void TInsert(WorkLocation t)
    {
        _workLocationDal.Insert(t);
    }

    public void TUpdate(WorkLocation t)
    {
        _workLocationDal.Update(t);
    }
}
